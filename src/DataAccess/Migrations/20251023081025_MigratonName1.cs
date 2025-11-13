using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigratonName1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Отделения",
                columns: table => new
                {
                    ID_отделения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Заведующий = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Отделени__A935EBC47FF3FA16", x => x.ID_отделения);
                });

            migrationBuilder.CreateTable(
                name: "Преподаватели",
                columns: table => new
                {
                    ID_преподавателя = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Отчество = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Должность = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ставка = table.Column<decimal>(type: "decimal(4,2)", nullable: true, defaultValueSql: "((1.0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Преподав__5C1E636A9010CB9A", x => x.ID_преподавателя);
                });

            migrationBuilder.CreateTable(
                name: "Причины_Освобождения",
                columns: table => new
                {
                    ID_причины = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Код_причины = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Макс_дней = table.Column<int>(type: "int", nullable: false),
                    Требует_справку = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ПричиныО__518A6CA02682A811", x => x.ID_причины);
                });

            migrationBuilder.CreateTable(
                name: "Типы_Заданий",
                columns: table => new
                {
                    ID_типа_задания = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Код_задания = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Макс_балл = table.Column<int>(type: "int", nullable: false, defaultValue: 5)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ТипыЗада__AA5324F39E0A8232", x => x.ID_типа_задания);
                });

            migrationBuilder.CreateTable(
                name: "Специальности",
                columns: table => new
                {
                    ID_специальности = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Код_специальности = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Название = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ID_отделения = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Специаль__AB8BFED36633350D", x => x.ID_специальности);
                    table.ForeignKey(
                        name: "FK__Специальн__ID_от__3C69FB99",
                        column: x => x.ID_отделения,
                        principalTable: "Отделения",
                        principalColumn: "ID_отделения");
                });

            migrationBuilder.CreateTable(
                name: "Группы",
                columns: table => new
                {
                    ID_группы = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ID_специальности = table.Column<int>(type: "int", nullable: false),
                    Курс = table.Column<int>(type: "int", nullable: false),
                    Год_поступления = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Группы__7EC7037D9B754A1C", x => x.ID_группы);
                    table.ForeignKey(
                        name: "FK__Группы__ID_специ__412EB0B6",
                        column: x => x.ID_специальности,
                        principalTable: "Специальности",
                        principalColumn: "ID_специальности");
                });

            migrationBuilder.CreateTable(
                name: "Нагрузка",
                columns: table => new
                {
                    ID_нагрузки = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_преподавателя = table.Column<int>(type: "int", nullable: false),
                    ID_группы = table.Column<int>(type: "int", nullable: false),
                    Семестр = table.Column<int>(type: "int", nullable: false),
                    Учебный_год = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Нагрузка__5784711A82DFB935", x => x.ID_нагрузки);
                    table.ForeignKey(
                        name: "FK__Нагрузка__ID_гру__6754599E",
                        column: x => x.ID_группы,
                        principalTable: "Группы",
                        principalColumn: "ID_группы");
                    table.ForeignKey(
                        name: "FK__Нагрузка__ID_пре__66603565",
                        column: x => x.ID_преподавателя,
                        principalTable: "Преподаватели",
                        principalColumn: "ID_преподавателя");
                });

            migrationBuilder.CreateTable(
                name: "Студенты",
                columns: table => new
                {
                    ID_студента = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Отчество = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_группы = table.Column<int>(type: "int", nullable: false),
                    Номер_зачетки = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Телефон = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Дата_регистрации = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Студенты__520B7B76874D27D1", x => x.ID_студента);
                    table.ForeignKey(
                        name: "FK__Студенты__ID_гру__45F365D3",
                        column: x => x.ID_группы,
                        principalTable: "Группы",
                        principalColumn: "ID_группы");
                });

            migrationBuilder.CreateTable(
                name: "Освобождения",
                columns: table => new
                {
                    ID_освобождения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_студента = table.Column<int>(type: "int", nullable: false),
                    ID_причины = table.Column<int>(type: "int", nullable: false),
                    Дата_начала = table.Column<DateOnly>(type: "date", nullable: false),
                    Дата_окончания = table.Column<DateOnly>(type: "date", nullable: false),
                    Номер_справки = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Кем_выдано = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Примечание = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Освобожд__6A05CE556E5CD89C", x => x.ID_освобождения);
                    table.ForeignKey(
                        name: "FK__Освобожде__ID_пр__4E88ABD4",
                        column: x => x.ID_причины,
                        principalTable: "Причины_Освобождения",
                        principalColumn: "ID_причины");
                    table.ForeignKey(
                        name: "FK__Освобожде__ID_ст__4D94879B",
                        column: x => x.ID_студента,
                        principalTable: "Студенты",
                        principalColumn: "ID_студента");
                });

            migrationBuilder.CreateTable(
                name: "Задания",
                columns: table => new
                {
                    ID_задания = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_освобождения = table.Column<int>(type: "int", nullable: false),
                    ID_типа_задания = table.Column<int>(type: "int", nullable: false),
                    Дата_назначения = table.Column<DateOnly>(type: "date", nullable: false),
                    Срок_сдачи = table.Column<DateOnly>(type: "date", nullable: false),
                    Тема = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Задания__D3DD242A3E9D8E9C", x => x.ID_задания);
                    table.ForeignKey(
                        name: "FK__Задания__ID_осво__571DF1D5",
                        column: x => x.ID_освобождения,
                        principalTable: "Освобождения",
                        principalColumn: "ID_освобождения");
                    table.ForeignKey(
                        name: "FK__Задания__ID_типа__5812160E",
                        column: x => x.ID_типа_задания,
                        principalTable: "Типы_Заданий",
                        principalColumn: "ID_типа_задания");
                });

            migrationBuilder.CreateTable(
                name: "Оценки",
                columns: table => new
                {
                    ID_оценки = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_задания = table.Column<int>(type: "int", nullable: false),
                    Балл = table.Column<int>(type: "int", nullable: false),
                    Дата_сдачи = table.Column<DateOnly>(type: "date", nullable: false),
                    Комментарий = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Преподаватель = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Дата_оценки = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Оценки__7491505F506D2039", x => x.ID_оценки);
                    table.ForeignKey(
                        name: "FK__Оценки__ID_задан__5EBF139D",
                        column: x => x.ID_задания,
                        principalTable: "Задания",
                        principalColumn: "ID_задания");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Группы_ID_специальности",
                table: "Группы",
                column: "ID_специальности");

            migrationBuilder.CreateIndex(
                name: "UQ__Группы__38DA8035B4795D03",
                table: "Группы",
                column: "Название",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Задания_ID_освобождения",
                table: "Задания",
                column: "ID_освобождения");

            migrationBuilder.CreateIndex(
                name: "IX_Задания_ID_типа_задания",
                table: "Задания",
                column: "ID_типа_задания");

            migrationBuilder.CreateIndex(
                name: "IX_Нагрузка_ID_группы",
                table: "Нагрузка",
                column: "ID_группы");

            migrationBuilder.CreateIndex(
                name: "UQ__Нагрузка__036905DA55B07A86",
                table: "Нагрузка",
                columns: new[] { "ID_преподавателя", "ID_группы", "Семестр", "Учебный_год" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Освобождения_ID_причины",
                table: "Освобождения",
                column: "ID_причины");

            migrationBuilder.CreateIndex(
                name: "IX_Освобождения_ID_студента",
                table: "Освобождения",
                column: "ID_студента");

            migrationBuilder.CreateIndex(
                name: "UQ__Отделени__38DA8035BF01208B",
                table: "Отделения",
                column: "Название",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Оценки__D3DD242B0C03EA45",
                table: "Оценки",
                column: "ID_задания",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ПричиныО__0DE9769C97695664",
                table: "Причины_Освобождения",
                column: "Код_причины",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Специальности_ID_отделения",
                table: "Специальности",
                column: "ID_отделения");

            migrationBuilder.CreateIndex(
                name: "UQ__Специаль__042110197325F23D",
                table: "Специальности",
                column: "Код_специальности",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Студенты_ID_группы",
                table: "Студенты",
                column: "ID_группы");

            migrationBuilder.CreateIndex(
                name: "UQ__Студенты__93450139A08F91DC",
                table: "Студенты",
                column: "Номер_зачетки",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ТипыЗада__C9CDA979A6907137",
                table: "Типы_Заданий",
                column: "Код_задания",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Нагрузка");

            migrationBuilder.DropTable(
                name: "Оценки");

            migrationBuilder.DropTable(
                name: "Преподаватели");

            migrationBuilder.DropTable(
                name: "Задания");

            migrationBuilder.DropTable(
                name: "Освобождения");

            migrationBuilder.DropTable(
                name: "Типы_Заданий");

            migrationBuilder.DropTable(
                name: "Причины_Освобождения");

            migrationBuilder.DropTable(
                name: "Студенты");

            migrationBuilder.DropTable(
                name: "Группы");

            migrationBuilder.DropTable(
                name: "Специальности");

            migrationBuilder.DropTable(
                name: "Отделения");
        }
    }
}
