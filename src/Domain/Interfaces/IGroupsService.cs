using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGroupsService
    {
        Task<List<Группы>> GetAll();
        Task<Группы> GetById(int id);
        Task Create(Группы model);
        Task Update(Группы model);
        Task Delete(int id);
    }
}