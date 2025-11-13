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
    public class GroupsService : IGroupsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Группы>> GetAll()
        {
            return await _repositoryWrapper.Группы.FindAll();
        }

        public async Task<Группы> GetById(int id)
        {
            var group = await _repositoryWrapper.Группы
                .FindByCondition(x => x.IdГруппы == id);
            return group.First();
        }

        public async Task Create(Группы model)
        {
            await _repositoryWrapper.Группы.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Группы model)
        {
            _repositoryWrapper.Группы.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var group = await _repositoryWrapper.Группы
                .FindByCondition(x => x.IdГруппы == id);

            _repositoryWrapper.Группы.Delete(group.First());
            _repositoryWrapper.Save();
        }
    }
}