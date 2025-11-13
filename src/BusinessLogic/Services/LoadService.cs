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
    public class LoadService : ILoadService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LoadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Нагрузка>> GetAll()
        {
            return await _repositoryWrapper.Нагрузка.FindAll();
        }

        public async Task<Нагрузка> GetById(int id)
        {
            var нагрузка = await _repositoryWrapper.Нагрузка
                .FindByCondition(x => x.IdНагрузки == id);
            return нагрузка.First();
        }

        public async Task Create(Нагрузка model)
        {
            await _repositoryWrapper.Нагрузка.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Нагрузка model)
        {
            _repositoryWrapper.Нагрузка.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var нагрузка = await _repositoryWrapper.Нагрузка
                .FindByCondition(x => x.IdНагрузки == id);

            _repositoryWrapper.Нагрузка.Delete(нагрузка.First());
            _repositoryWrapper.Save();
        }
    }
}