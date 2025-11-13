
using Domain.Models;

namespace Project.Contracts.Branches
{
    public class GetBranchesResponse
    {

    public int IdОтделения { get; set; }

    public string Название { get; set; } = null!;

    public string? Заведующий { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    }
}