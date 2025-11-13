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
    public class GradeService : IGradeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Оценки>> GetAll()
        {
            return await _repositoryWrapper.Grade.FindAll();
        }

        public async Task<Оценки> GetById(int id)
        {
            var grade = await _repositoryWrapper.Grade
                .FindByCondition(x => x.IdОценки == id);
            return grade.First();
        }

        public async Task Create(Оценки model)
        {
            await _repositoryWrapper.Grade.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Оценки model)
        {
            _repositoryWrapper.Grade.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var grade = await _repositoryWrapper.Grade
                .FindByCondition(x => x.IdОценки == id);

            _repositoryWrapper.Grade.Delete(grade.First());
            _repositoryWrapper.Save();
        }
    }
}