using Domain.Models;

namespace Project.Contracts.TaskType
{
    public class GetTaskTypeResponse
    {
        public int IdТипаЗадания { get; set; }

        public string КодЗадания { get; set; } = null!;

        public string Название { get; set; } = null!;

        public string? Описание { get; set; }

        public int МаксБалл { get; set; }
    }
}
