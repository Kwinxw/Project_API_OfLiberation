using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBranchesService
    {
        Task<List<Отделения>> GetAll();
        Task<Отделения> GetById(int id);
        Task Create(Отделения model);
        Task Update(Отделения model);
        Task Delete(int id);
    }
}