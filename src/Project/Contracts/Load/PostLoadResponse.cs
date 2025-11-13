using Domain.Models;

namespace Project.Contracts.Load
{
    public class PostLoadResponse
    {
        public int IdНагрузки { get; set; }

        public int IdПреподавателя { get; set; }

        public int IdГруппы { get; set; }

        public int Семестр { get; set; }

        public int УчебныйГод { get; set; }

    }
}
