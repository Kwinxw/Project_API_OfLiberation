using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILoadService
    {
        Task<List<Нагрузка>> GetAll();
        Task<Нагрузка> GetById(int id);
        Task Create(Нагрузка model);
        Task Update(Нагрузка model);
        Task Delete(int id);
    }
}