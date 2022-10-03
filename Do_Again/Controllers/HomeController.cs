using Do_Again.Models;
using Do_Again.viewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Do_Again.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IBookrepositry _bookrepositry;
        public HomeController(IBookrepositry bookrepositry, IHostingEnvironment hostingEnvironment)
        {
            _bookrepositry = bookrepositry;
            this.hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            var model = _bookrepositry.GetAllBooks();
            return View(model);
        }

        private string ProcessUploadedFile(CreateBookNew model)
        {
            string uniqueFileName = null;
            if (model.Photopath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "image/Book");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photopath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Photopath.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateBookNew createBookNew = new CreateBookNew();
            createBookNew.categorys = _bookrepositry.GetAllCategory();
            return View(createBookNew);
        }
        [HttpPost]
        public IActionResult Create(CreateBookNew model)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Name = model.Name,
                    Price = model.Price,
                    Photopath = ProcessUploadedFile(model),
                    TypeofbookId = model.TypeOfBookid

                };
                if (book.Photopath == null)
                {
                    book.Photopath = "";
                }
                _bookrepositry.Add(book);
                return RedirectToAction("index");
            }
            return View("index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = _bookrepositry.GetBook(id);
            EditBook edit = new EditBook
            {
                Name = book.Name,
                Price = book.Price,
                //  TypeOfBook = book.TypeOfBook,
                Existing_photo = book.Photopath,
                categorys = _bookrepositry.GetAllCategory(),
            };
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(EditBook model)
        {
            if (ModelState.IsValid)
            {
                Book book = _bookrepositry.GetBook(model.ID);
                book.Name = model.Name;
                book.Price = model.Price;
                book.TypeofbookId = model.TypeOfBookid;
                //           book.TypeOfBook = model.TypeOfBook;
                if (model.Photopath != null)
                {
                    if (model.Existing_photo != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "image/Book", model.Existing_photo);
                        System.IO.File.Delete(filePath);
                    }
                    book.Photopath = ProcessUploadedFile(model);
                }


                _bookrepositry.Update(book);
                return RedirectToAction("index");


            }
            return View();

        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Book book = _bookrepositry.GetBook(id);
            var ctegory = book.TypeofbookId;

            if (book == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            DetailsBook detailsBook = new DetailsBook
            {
                Book = book,
                categorys = _bookrepositry.GetCategory(ctegory),
                Title = "Details Of Book"
            };
            return View(detailsBook);

        }
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> NavCategory(int id)
        {
            {
                IQueryable<Book> book = _bookrepositry.GetbookByCategory(id);
                return View(book);
            }

        }
       [ HttpPost]

        public  IActionResult Delete(int id)
        {
            
            _bookrepositry.Delete(id);
      
           return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Search(string term)
        {
            var result = _bookrepositry.Search(term);

            return View("Index", result);
        }
    }
    }
