using Domain.Models;

namespace Project.Contracts.Specialities
{
    public class GetSpecialitiesResponse
    {
        public int IdСпециальности { get; set; }

        public string КодСпециальности { get; set; } = null!;

        public string Название { get; set; } = null!;

        public int IdОтделения { get; set; }

    }
}
