using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TaskTypesService : ITaskTypesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TaskTypesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ТипыЗаданий>> GetAll()
        {
            return await _repositoryWrapper.TaskTypes.FindAll();
        }

        public async Task<ТипыЗаданий> GetById(int id)
        {
            var taskType = await _repositoryWrapper.TaskTypes
                .FindByCondition(x => x.IdТипаЗадания == id);
            return taskType.First();
        }

        public async Task Create(ТипыЗаданий model)
        {
            await _repositoryWrapper.TaskTypes.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ТипыЗаданий model)
        {
            _repositoryWrapper.TaskTypes.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var taskType = await _repositoryWrapper.TaskTypes
                .FindByCondition(x => x.IdТипаЗадания == id);

            _repositoryWrapper.TaskTypes.Delete(taskType.First());
            _repositoryWrapper.Save();
        }
    }
}