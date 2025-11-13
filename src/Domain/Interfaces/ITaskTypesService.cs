using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITaskTypesService
    {
        Task<List<ТипыЗаданий>> GetAll();
        Task<ТипыЗаданий> GetById(int id);
        Task Create(ТипыЗаданий model);
        Task Update(ТипыЗаданий model);
        Task Delete(int id);
    }
}