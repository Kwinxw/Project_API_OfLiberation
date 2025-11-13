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
    public class LiberationService : ILiberationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LiberationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Освобождения>> GetAll()
        {
            return await _repositoryWrapper.Liberation.FindAll();
        }

        public async Task<Освобождения> GetById(int id)
        {
            var liberation = await _repositoryWrapper.Liberation
                .FindByCondition(x => x.IdОсвобождения == id);
            return liberation.First();
        }

        public async Task Create(Освобождения model)
        {
            await _repositoryWrapper.Liberation.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Освобождения model)
        {
            _repositoryWrapper.Liberation.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var liberation = await _repositoryWrapper.Liberation
                .FindByCondition(x => x.IdОсвобождения == id);

            _repositoryWrapper.Liberation.Delete(liberation.First());
            _repositoryWrapper.Save();
        }
    }
}