using Domain.Models;

namespace Project.Contracts.Groups
{
    public class PostGroupsRequest
{

    public int IdГруппы { get; set; }

    public string Название { get; set; } = null!;

    public int IdСпециальности { get; set; }

    public int Курс { get; set; }

    public int ГодПоступления { get; set; }

}
}
