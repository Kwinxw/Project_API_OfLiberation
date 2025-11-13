using Domain.Models;

namespace Project.Contracts.Quests
{
    public class GetQuestsResponse
    {
        public int IdЗадания { get; set; }

        public int IdОсвобождения { get; set; }

        public int IdТипаЗадания { get; set; }

        public DateOnly ДатаНазначения { get; set; }

        public DateOnly СрокСдачи { get; set; }

        public string Тема { get; set; } = null!;

        public string? Описание { get; set; }

    }
}
