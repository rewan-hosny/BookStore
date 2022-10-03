using Microsoft.EntityFrameworkCore.Migrations;

namespace Do_Again.Migrations
{
    public partial class catogry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Book_MovieId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Book_bookId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "book");

            migrationBuilder.RenameColumn(
                name: "TypeOfBook",
                table: "book",
                newName: "TypeofbookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TypeOfBook",
                columns: table => new
                {
                    TypeofbookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_catogry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfBook", x => x.TypeofbookId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_book_BookId",
                table: "OrderItems",
                column: "BookId",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_book_bookId",
                table: "ShoppingCartItems",
                column: "bookId",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_book_BookId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_book_bookId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "TypeOfBook");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Book");

            migrationBuilder.RenameColumn(
                name: "TypeofbookId",
                table: "Book",
                newName: "TypeOfBook");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Book_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Book_bookId",
                table: "ShoppingCartItems",
                column: "bookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
