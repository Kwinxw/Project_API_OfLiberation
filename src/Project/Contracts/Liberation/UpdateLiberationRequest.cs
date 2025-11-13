using Domain.Models;

namespace Project.Contracts.Liberation
{
    public class UpdateLiberationRequest
    {
        public int IdОсвобождения { get; set; }

        public int IdСтудента { get; set; }

        public int IdПричины { get; set; }

        public DateOnly ДатаНачала { get; set; }

        public DateOnly ДатаОкончания { get; set; }

        public string? НомерСправки { get; set; }

        public string? КемВыдано { get; set; }

        public string? Примечание { get; set; }

        public DateTime? ДатаСоздания { get; set; }

    }
}
