using Domain.Models;

namespace Project.Contracts.Student
{
    public class PostStudentResponse
    {
        public int IdСтудента { get; set; }

        public string Фамилия { get; set; } = null!;

        public string Имя { get; set; } = null!;

        public string? Отчество { get; set; }

        public int IdГруппы { get; set; }

        public string НомерЗачетки { get; set; } = null!;

        public string? Телефон { get; set; }

        public string? Email { get; set; }

        public DateTime? ДатаРегистрации { get; set; }
    }
}
