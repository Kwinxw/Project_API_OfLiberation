using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentsService
    {
        Task<List<Студенты>> GetAll();
        Task<Студенты> GetById(int id);
        Task Create(Студенты model);
        Task Update(Студенты model);
        Task Delete(int id);
    }
}
