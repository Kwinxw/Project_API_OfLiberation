using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGradeService
    {
        Task<List<Оценки>> GetAll();
        Task<Оценки> GetById(int id);
        Task Create(Оценки model);
        Task Update(Оценки model);
        Task Delete(int id);
    }
}