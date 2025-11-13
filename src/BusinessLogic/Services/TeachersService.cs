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
    public class ПреподавателиService : ITeachersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ПреподавателиService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Преподаватели>> GetAll()
        {
            return await _repositoryWrapper.Преподаватели.FindAll();
        }

        public async Task<Преподаватели> GetById(int id)
        {
            var преподаватель = await _repositoryWrapper.Преподаватели
                .FindByCondition(x => x.IdПреподавателя == id);
            return преподаватель.First();
        }

        public async Task Create(Преподаватели model)
        {
            await _repositoryWrapper.Преподаватели.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Преподаватели model)
        {
            _repositoryWrapper.Преподаватели.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var преподаватель = await _repositoryWrapper.Преподаватели
                .FindByCondition(x => x.IdПреподавателя == id);

            _repositoryWrapper.Преподаватели.Delete(преподаватель.First());
            _repositoryWrapper.Save();
        }
    }
}