using Domain.Models;

namespace Project.Contracts.Grade
{
    public class CreateGradeRequest
    {

        public int Балл { get; set; }

        public DateOnly ДатаСдачи { get; set; }

        public string? Комментарий { get; set; }

        public string Преподаватель { get; set; } = null!;

        public DateTime? ДатаОценки { get; set; }

    }
}