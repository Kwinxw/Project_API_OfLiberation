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
    public class ReasonsForLiberationService : IReasonsForLiberationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReasonsForLiberationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ПричиныОсвобождения>> GetAll()
        {
            return await _repositoryWrapper.ReasonsForLiberation.FindAll();
        }

        public async Task<ПричиныОсвобождения> GetById(int id)
        {
            var reason = await _repositoryWrapper.ReasonsForLiberation
                .FindByCondition(x => x.IdПричины == id);
            return reason.First();
        }

        public async Task Create(ПричиныОсвобождения model)
        {
            await _repositoryWrapper.ReasonsForLiberation.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ПричиныОсвобождения model)
        {
            _repositoryWrapper.ReasonsForLiberation.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var reason = await _repositoryWrapper.ReasonsForLiberation
                .FindByCondition(x => x.IdПричины == id);

            _repositoryWrapper.ReasonsForLiberation.Delete(reason.First());
            _repositoryWrapper.Save();
        }
    }
}