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
    public class BranchesService : IBranchesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BranchesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Отделения>> GetAll()
        {
            return await _repositoryWrapper.Branches.FindAll();
        }

        public async Task<Отделения> GetById(int id)
        {
            var branch = await _repositoryWrapper.Branches
                .FindByCondition(x => x.IdОтделения == id);
            return branch.First();
        }

        public async Task Create(Отделения model)
        {
            await _repositoryWrapper.Branches.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Отделения model)
        {
            _repositoryWrapper.Branches.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var branch = await _repositoryWrapper.Branches
                .FindByCondition(x => x.IdОтделения == id);

            _repositoryWrapper.Branches.Delete(branch.First());
            _repositoryWrapper.Save();
        }
    }
}