using Domain.Models;

namespace Project.Contracts.Quests
{
    public class CreateQuestsRequest
    {

        public DateOnly ДатаНазначения { get; set; }

        public DateOnly СрокСдачи { get; set; }

        public string Тема { get; set; } = null!;

        public string? Описание { get; set; }


    }
}
