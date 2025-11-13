using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeachersService
    {
        Task<List<Преподаватели>> GetAll();
        Task<Преподаватели> GetById(int id);
        Task Create(Преподаватели model);
        Task Update(Преподаватели model);
        Task Delete(int id);
    }
}