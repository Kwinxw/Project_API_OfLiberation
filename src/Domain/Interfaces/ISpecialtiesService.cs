using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISpecialtiesService
    {
        Task<List<Специальности>> GetAll();
        Task<Специальности> GetById(int id);
        Task Create(Специальности model);
        Task Update(Специальности model);
        Task Delete(int id);
    }
}