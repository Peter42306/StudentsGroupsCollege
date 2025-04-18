using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentsGroupsCollege.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "CollegeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CollegeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeGroups_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CollegeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CollegeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CollegeGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_CollegeGroups_CollegeGroupId",
                        column: x => x.CollegeGroupId,
                        principalTable: "CollegeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.TeacherId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Specialized in engineering and computer science", "Technical Academy" },
                    { 2, "Focuses on maritime and logistics education", "Marine University" },
                    { 3, "IT oriented academy", "IT Step Academy" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur.", "Mathematical Analysis" },
                    { 2, "Ut enim ad minim veniam quis nostrud exercitation ullamco.", "Linear Algebra" },
                    { 3, "Duis aute irure dolor in reprehenderit in voluptate velit esse.", "Marine Navigation" },
                    { 4, "Excepteur sint occaecat cupidatat non proident sunt culpa.", "Ship Management" },
                    { 5, "Sed ut perspiciatis unde omnis iste natus error.", "International Logistics" },
                    { 6, "Lorem ipsum dolor sit amet adipiscing elit sed.", "Corporate Finance" },
                    { 7, "Ut labore et dolore magna aliqua enim ad.", "Discrete Mathematics" },
                    { 8, "Consectetur adipiscing elit sed do eiusmod tempor.", "Marketing Strategies" },
                    { 9, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Business Ethics" },
                    { 10, "Nisi ut aliquip ex ea commodo consequat laboris.", "Computational Models" }
                });

            migrationBuilder.InsertData(
                table: "CollegeGroups",
                columns: new[] { "Id", "CollegeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur  deserunt mollit minim veniam, quis anim id est adipiscing elit.", "ENG-101" },
                    { 2, 1, "Sed do eiusmod tempor incididunt ut labore et dolore.", "ENG-102" },
                    { 3, 2, "Ut enim ad minim veniam, quis nostrudi rure dolor in exercitation.", "CS-201" },
                    { 4, 2, "Duis aute irure dolor in reprehenderit in voluptate.", "NAV-101" },
                    { 5, 2, "Excepteur sint  occaecat cupidatat non proident sunt.", "LOG-202" },
                    { 6, 2, "Culpa qui officia deserunt mollit anim id est laborum.", "MAR-203" },
                    { 7, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "BUS-101" },
                    { 8, 3, "Nisi ut aliquip ex ea commodo consequat minim veniam, quis nostrud ullamco laboris.", "MKT-202" },
                    { 9, 3, "Tempor incididunt ut labore et dolore magna aliqua.", "FIN-303" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CollegeId", "Description", "Name", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet consectetur adipiscing elit sed.", "Tatiana Morozova", 0 },
                    { 2, 1, "Ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi.", "Andrei Sokolov", 1 },
                    { 3, 1, "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.", "Irina Vlasova", 2 },
                    { 4, 1, "Excepteur sint occaecat cupidatat non proident sunt in culpa.", "Yulia Antonova", 3 },
                    { 5, 1, "Eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Oksana Petrova", 4 },
                    { 6, 1, "Reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", "Vladimir Ivanov", 5 },
                    { 7, 2, "Consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore.", "Natalia Belkina", 0 },
                    { 8, 2, "Nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo.", "Sergey Zhukov", 1 },
                    { 9, 2, "Ut aliquip ex ea commodo consequat duis aute irure dolor.", "Elena Voronova", 2 },
                    { 10, 2, "Sunt in culpa qui officia deserunt mollit anim id est laborum.", "Igor Romanov", 3 },
                    { 11, 2, "Lorem ipsum dolor sit amet consectetur adipiscing elit.", "Tatiana Miroshnichenko", 4 },
                    { 12, 2, "Voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint.", "Pavel Ershov", 5 },
                    { 13, 3, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem.", "Olga Kuzmina", 0 },
                    { 14, 3, "Accusantium doloremque laudantium totam rem aperiam eaque ipsa.", "Dmitry Pavlov", 1 },
                    { 15, 3, "Quis autem vel eum iure reprehenderit qui in ea.", "Svetlana Koroleva", 2 },
                    { 16, 3, "Voluptas nulla pariatur at vero eos et accusamus.", "Kirill Trofimov", 3 },
                    { 17, 3, "Ut enim ad minima veniam quis nostrum exercitationem ullam.", "Anastasia Fedorova", 4 },
                    { 18, 3, "Laboriosam nisi ut aliquid ex ea commodi consequatur.", "Oleg Grigoriev", 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CollegeId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 1, "Dr. Marina Volkova", "Professor" },
                    { 2, 1, "Mr. Sergey Belov", "Lecturer" },
                    { 3, 1, "Ms. Yana Petrova", "Senior Lecturer" },
                    { 4, 1, "Mrs. Svetlana Orlova", "Associate Professor" },
                    { 5, 2, "Dr. Ivan Denisov", "Professor" },
                    { 6, 2, "Mr. Yuri Zverev", "Lecturer" },
                    { 7, 2, "Ms. Anastasia Rybakova", "Senior Lecturer" },
                    { 8, 2, "Mrs. Alina Golubeva", "Associate Professor" },
                    { 9, 2, "Mr. Viktor Lavrov", "Instructor" },
                    { 10, 3, "Dr. Elena Koroleva", "Professor" },
                    { 11, 3, "Mr. Artem Tarasov", "Lecturer" },
                    { 12, 3, "Ms. Irina Fedorova", "Senior Lecturer" },
                    { 13, 3, "Mrs. Galina Mikhailova", "Associate Professor" },
                    { 14, 3, "Mr. Nikolai Alekseev", "Instructor" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CollegeGroupId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Anna Petrova" },
                    { 2, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia.", "Dmitry Ivanov" },
                    { 3, 1, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Maria Sokolova" },
                    { 4, 1, "Enim ad minim veniam quis nostrud exercitation ullamco laboris nisi.", "Kirill Smirnov" },
                    { 5, 1, "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.", "Elena Orlova" },
                    { 6, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit.", "Sergey Kozlov" },
                    { 7, 2, "Voluptatem accusantium doloremque laudantium, totam rem aperiam.", "Natalia Volkova" },
                    { 8, 2, "Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae.", "Alexey Egorov" },
                    { 9, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "Irina Baranova" },
                    { 10, 2, "Exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Anton Vinogradov" },
                    { 11, 3, "Sit amet, consectetur adipiscing elit, sed do eiusmod tempor.", "Olga Dmitrieva" },
                    { 12, 3, "Cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non.", "Vadim Nikitin" },
                    { 13, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.", "Ekaterina Filippova" },
                    { 14, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit.", "Maxim Lebedev" },
                    { 15, 4, "Velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum.", "Svetlana Andreeva" },
                    { 16, 4, "Fugiat quo voluptas nulla pariatur. At vero eos et accusamus.", "Pavel Frolov" },
                    { 17, 4, "Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis.", "Yulia Romanova" },
                    { 18, 4, "Nisi ut aliquid ex ea commodi consequatur. Quis autem vel eum.", "Nikita Sorokin" },
                    { 19, 4, "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet.", "Tatiana Belova" },
                    { 20, 4, "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit laboriosam.", "Egor Semenov" },
                    { 21, 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Larisa Mironova" },
                    { 22, 5, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque.", "Roman Gusev" },
                    { 23, 5, "Accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo.", "Elizaveta Pavlova" },
                    { 24, 5, "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe.", "Stepan Makarov" },
                    { 25, 6, "Sed ut perspiciatis unde omnis iste natus error sit.", "Irina Kalinina" },
                    { 26, 6, "Ut enim ad minima veniam quis nostrum exercitationem ullam.", "Yaroslav Markov" },
                    { 27, 6, "Corporis suscipit laboriosam nisi ut aliquid ex ea commodi consequatur.", "Diana Nikiforova" },
                    { 28, 6, "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit laboriosam.", "Alexandr Vasiliev" },
                    { 29, 6, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit.", "Galina Kuznetsova" },
                    { 30, 6, "Et harum quidem rerum facilis est et expedita distinctio.", "Igor Fedotov" },
                    { 31, 7, "Nam libero tempore cum soluta nobis est eligendi optio cumque nihil.", "Maria Stepanova" },
                    { 32, 7, "Commodi consequatur quis autem vel eum iure reprehenderit.", "Boris Lebedev" },
                    { 33, 7, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut.", "Kseniya Zaitseva" },
                    { 34, 7, "Consequatur aut perferendis doloribus asperiores repellat.", "Denis Abramov" },
                    { 35, 7, "Ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit.", "Victoria Ermakova" },
                    { 36, 8, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse.", "Oksana Zueva" },
                    { 37, 8, "Et harum quidem rerum facilis est et expedita distinctio.", "Andrei Krylov" },
                    { 38, 9, "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus.", "Natalia Bobrova" },
                    { 39, 9, "Itaque earum rerum hic tenetur a sapiente delectus ut aut.", "Vladimir Ignatov" },
                    { 40, 9, "Nisi ut aliquid ex ea commodi consequatur quis autem vel.", "Alina Safonova" },
                    { 41, 9, "Vel illum qui dolorem eum fugiat quo voluptas nulla pariatur.", "Stanislav Rodionov" },
                    { 42, 9, "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet consectetur.", "Anastasia Belaya" },
                    { 43, 9, "Sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt.", "Grigory Eliseev" },
                    { 44, 9, "Cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non.", "Ekaterina Nikitina" },
                    { 45, 9, "Ut enim ad minima veniam quis nostrum exercitationem ullam.", "Artur Kuzmin" }
                });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "TeacherId", "Notes" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 1, null },
                    { 2, 2, null },
                    { 7, 3, null },
                    { 10, 4, null },
                    { 3, 5, null },
                    { 4, 6, null },
                    { 5, 7, null },
                    { 5, 8, null },
                    { 4, 9, null },
                    { 6, 10, null },
                    { 8, 11, null },
                    { 8, 12, null },
                    { 9, 13, null },
                    { 9, 14, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollegeGroups_CollegeId",
                table: "CollegeGroups",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CollegeId",
                table: "Staffs",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeGroupId",
                table: "Students",
                column: "CollegeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CollegeId",
                table: "Teachers",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");
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
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CollegeGroups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Colleges");
        }
    }
}
