using Domain.Models;

namespace Project.Contracts.Teachers
{
    public class GetTeacherResponse
    {
        public int IdПреподавателя { get; set; }

        public string Фамилия { get; set; } = null!;

        public string Имя { get; set; } = null!;

        public string? Отчество { get; set; }

        public string? Должность { get; set; }

        public decimal? Ставка { get; set; }
    }
}
