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
    public class SpecialtiesService : ISpecialtiesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SpecialtiesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Специальности>> GetAll()
        {
            return await _repositoryWrapper.Specialties.FindAll();
        }

        public async Task<Специальности> GetById(int id)
        {
            var specialty = await _repositoryWrapper.Specialties
                .FindByCondition(x => x.IdСпециальности == id);
            return specialty.First();
        }

        public async Task Create(Специальности model)
        {
            await _repositoryWrapper.Specialties.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Специальности model)
        {
            _repositoryWrapper.Specialties.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var specialty = await _repositoryWrapper.Specialties
                .FindByCondition(x => x.IdСпециальности == id);

            _repositoryWrapper.Specialties.Delete(specialty.First());
            _repositoryWrapper.Save();
        }
    }
}