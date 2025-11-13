using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILiberationService
    {
        Task<List<Освобождения>> GetAll();
        Task<Освобождения> GetById(int id);
        Task Create(Освобождения model);
        Task Update(Освобождения model);
        Task Delete(int id);
    }
}