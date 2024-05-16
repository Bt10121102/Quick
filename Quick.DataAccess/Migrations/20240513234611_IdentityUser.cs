using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quick.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Starters" },
                    { 2, 2, "Salads" },
                    { 3, 3, "Sandwiches" },
                    { 4, 4, "Burgers" },
                    { 5, 5, "Pasta" },
                    { 6, 6, "Dessert" },
                    { 7, 7, "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "A basket of our original unpeeled French fries, crisped to golden perfection.", "", "IMPORTED SKIN-ON FRIES", 5.0 },
                    { 2, 1, "A basket of fresh crunchy fries. With a twist.", "", "CURLY FRIES", 6.0 },
                    { 3, 1, "Our original unpeeled French fries, topped with melted cheese and served with sour cream on the side.", "", "FRIES ‘N’ CHEDDAR", 9.0 },
                    { 4, 1, "Our signature lightly breaded chicken strips that you know and love, served with our famous honey mustard dip.", "", "CHICKEN STRIPS", 9.0 },
                    { 5, 1, "Crispy flour tortilla rolls filled with melted cheese, parsley and garlic, served with salsa fresca on the side.", "", "CHEESE GARLIC ROLLS", 5.0 },
                    { 6, 1, "A soft tortilla shell, grilled to perfection and flavored with our exclusive marinade. Filled with grilled chicken, grilled onions and bell peppers, Edam cheese, crisp Lollo Verde lettuce and our fresh guacamole sauce. Served with sour cream on the side.", "", "CHICKEN TACOS", 7.0 },
                    { 7, 1, "A mouthwatering mix of our buffalo wings, mozzarella sticks, ranch chicken rolls, chicken strips and signature skin-on fries, served with our famous honey mustard and Thousand Island dips.", "", "SUPER SAMPLER", 15.0 },
                    { 8, 1, "Our signature chicken wings, glazed in spicy Buffalo sauce.", "", "BUFFALO WINGS", 10.0 },
                    { 9, 1, "Our signature chicken wings, glazed in sweet and sassy BBQ sauce.", "", "BBQ WINGS", 10.0 },
                    { 10, 1, "Our signature lightly breaded chicken strips that you know and love, served with our famous honey mustard dip.", "", "CHICKEN STRIPS", 9.0 },
                    { 11, 1, "Our classic melt-in-your-mouth mozzarella sticks, served with Thousand Island dip.", "", "MOZZARELLA STICKS", 6.5 },
                    { 12, 2, "Fresh kale topped with juicy flame-grilled shrimp coated with wasabi, sesame seeds, organic quinoa, crunchy\r\npeanuts and dried cranberries. Tossed with sesame balsamic dressing.", "", "KALE SHRIMP WASABI", 13.0 },
                    { 13, 2, "A colorful mix of fresh Lollo Verde lettuce, rocket leaves, basil, avocado and cherry tomatoes. Sprinkled with chia seeds and tossed in our basil vinaigrette dressing.", "", "FIELD GREENS AVOCADO", 6.0 },
                    { 14, 2, "A mix of crisp romaine lettuce, topped with parmesan slices and herbs croutons. Caesar dressing on the side.", "", "CLASSIC CAESAR", 6.0 },
                    { 15, 2, "A mix of crisp romaine lettuce, topped with grilled chicken breast, shredded parmesan and herb croutons. Caesar dressing on the side.", "", "CHICKEN CAESAR", 9.0 },
                    { 16, 2, "Crisp iceberg lettuce and rocket leaves topped with tender grilled chicken, avocado, hard-boiled eggs and parmesan shavings.", "", "CHICKEN AVOCADO", 9.0 },
                    { 17, 2, "Pasta mix topped with cheese, fresh iceberg lettuce, fresh mushrooms and corn.", "", "PASTA ’N’ CHEESE", 8.0 },
                    { 18, 2, "A mix of fresh baby mozzarella, grilled chicken tenders, avocado, cherry tomatoes, basil, fresh lettuce mix and red rocket leaves. Served with basil vinaigrette dressing.", "", "BABY MOZZARELLA ‘N’ CHICKEN", 10.0 },
                    { 19, 3, "Breaded Shrimp, crisp iceberg lettuce, a refreshing cabbage and carrot mix, avocado, crushed peanuts, a sweet chili and vinegar dressing, served in a freshly baked baguette.", "", "CRISPY SHRIMP AVOCADO", 9.0 },
                    { 20, 3, "Grilled chicken, crisp rocket leaves, sautéed fresh mushrooms and onions, melted cheddar cheese, mayo and our signature B.B.B. sauce, served in a freshly baked baguette.", "", "SMOKY CHICKEN", 9.0 },
                    { 21, 3, "Juicy flame-grilled shrimp, Lollo Verde, Texas and guacamole sauce, served in a freshly baked baguette.", "", "SHRIMP GUACAMOLE", 10.0 },
                    { 22, 3, "Grilled chicken breast, edam cheese, avocado, crisp lettuce and garlic home-style sauce, served in freshly baked whole-wheat baguette.", "", "CHICKEN SLIDER", 10.0 },
                    { 23, 4, "Breaded chicken breast dipped in a Korean sauce, topped with a crispy Philly cheese patty, lettuce, Asian coleslaw, and our new special honey mustard sauce.", "", "DOUBLE CRISP", 12.0 },
                    { 24, 4, "Breaded chicken breast topped with our special mild chili melted cheddar, tortilla chips, dill pickles, our garlic mayo and Cuban sauce.", "", "CHEESE ‘N’ CHILI", 10.0 },
                    { 25, 4, "Grilled beef patty topped with sautéed onions, melted cheddar cheese, crisp lettuce, a fresh tomato slice, tangy pickles and our classic sauce.", "", "CLASSIC", 10.0 },
                    { 26, 4, "Your choice of grilled or breaded chicken breast topped with crisp lettuce, a fresh tomato slice, tangy pickles and aioli sauce.", "", "CHICKEN BURGER", 9.0 },
                    { 27, 4, "Tender grilled chicken breast topped with a breaded mozzarella patty, crisp lettuce, a fresh tomato slice, tangy pickles and aioli sauce.", "", "MIGHTY CHICKEN", 14.0 },
                    { 28, 4, "Grilled beef patty topped with grilled onions and green peppers, jalapeños, melted cheddar cheese, crisp lettuce, a fresh tomato slice and hot Cuban sauce.", "", "CUBAN", 9.0 },
                    { 29, 4, "Grilled beef patty topped with melted Swiss cheese, sautéed fresh mushrooms, caramelized onions, arugula and truffle aioli sauce.", "", "SWISS TRUFFLE", 12.0 },
                    { 30, 5, "Penne mixed with tomato sauce and roasted vegetables.", "", "VEGAN PASTA", 9.0 },
                    { 31, 5, "Penne mixed with tomato sauce and our selection of cheeses, topped with parmesan sprinkles and fresh basil.", "", "FOUR CHEESE", 12.0 },
                    { 32, 5, "Tagliatelle in a creamy sauce with a twist of garlic, sautéed fresh mushrooms and grilled chicken, topped with parmesan sprinkles.", "", "CHICKEN PASTA", 11.0 },
                    { 33, 5, "Tagliatelle in a creamy sauce with a twist of garlic and a dash of zingy ginger, mixed cheese, sautéed onions and fresh mushrooms and flame-grilled shrimp, topped with parmesan sprinkles and fresh basil.", "", "SHRIMP PASTA", 12.0 },
                    { 34, 7, "", "", "SOFT DRINKS", 2.0 },
                    { 35, 7, "", "", "MINERAL WATER", 1.0 },
                    { 36, 7, "Your choice of chocolate, vanilla or strawberry.", "", "OLD TIME MILKSHAKE", 6.0 },
                    { 37, 7, "", "", "FRESH ORANGE JUICE", 5.0 },
                    { 38, 6, "Super-sized pancakes topped with chocolate, bananas, Lotus spread and Lotus biscuits, drizzled in a rich chocolate sauce.", "", "LOTUS MADNESS", 5.0 },
                    { 39, 6, "Pancakes soaked in an exquisite banana rum marinade, topped with sautéed bananas and salted caramel. Served with vanilla ice cream, and sprinkled with buttery biscuit crumbs.", "", "BANANA O’ RUM", 6.0 },
                    { 40, 6, "Strawberry cheesecake ice cream drizzled with strawberry sauce, topped with fresh strawberries and buttery biscuit crumbs.", "", "CHEESECAKE SUNDAE EXPLOSION", 8.0 },
                    { 41, 6, "A rich chocolate brownie topped with vanilla ice cream and salted caramel sauce.", "", "BROWNIE TEMPTATION", 5.0 },
                    { 42, 6, "White chocolate, brownies, strawberries, bananas and Digestive crispy pie on top.", "", "CHOCO TACOS", 7.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
