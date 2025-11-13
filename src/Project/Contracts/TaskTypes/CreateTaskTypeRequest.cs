using Domain.Models;

namespace Project.Contracts.TaskType
{
    public class CreateTaskTypeRequest
    {

        public string КодЗадания { get; set; } = null!;

        public string Название { get; set; } = null!;

        public string? Описание { get; set; }

        public int МаксБалл { get; set; }

    }
}
