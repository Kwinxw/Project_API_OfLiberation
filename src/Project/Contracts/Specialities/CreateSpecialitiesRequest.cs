using Domain.Models;

namespace Project.Contracts.Specialities
{
    public class CreateSpecialitiesRequest
    {

        public string КодСпециальности { get; set; } = null!;

        public string Название { get; set; } = null!;


    }
}
