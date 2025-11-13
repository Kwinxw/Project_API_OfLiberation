using Domain.Models;

namespace Project.Contracts.Student
{
    public class CreateStudentRequest
    {
        public string Фамилия { get; set; } = null!;

        public string Имя { get; set; } = null!;

        public string? Отчество { get; set; }

        public string НомерЗачетки { get; set; } = null!;

        public string? Телефон { get; set; }

        public string? Email { get; set; }

    }
}
