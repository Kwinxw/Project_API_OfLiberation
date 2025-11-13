using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQuestsService
    {
        Task<List<Задания>> GetAll();
        Task<Задания> GetById(int id);
        Task Create(Задания model);
        Task Update(Задания model);
        Task Delete(int id);
        Task<List<Задания>> GetByStudentId(int studentId);
        Task<List<Задания>> GetByLiberationId(int liberationId);
        Task<List<Задания>> GetOverdueQuests();
    }
}