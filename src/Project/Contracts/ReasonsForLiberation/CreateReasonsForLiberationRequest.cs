using Domain.Models;

namespace Project.Contracts.ReasonsForLiberation
{
    public class CreateReasonsForLiberationRequest
    {

        public string КодПричины { get; set; } = null!;

        public string Название { get; set; } = null!;

        public int МаксДней { get; set; }

        public bool? ТребуетСправку { get; set; }


    }
}
