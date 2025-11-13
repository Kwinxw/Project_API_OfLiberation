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
    public class StudentsService : IStudentsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StudentsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Студенты>> GetAll()
        {
            return await _repositoryWrapper.Студенты.FindAll();
        }

        public async Task<Студенты> GetById(int id)    
        {
            var user = await _repositoryWrapper.Студенты
                .FindByCondition(x => x.IdСтудента == id);
            return user.First();
        }

        public async Task Create(Студенты model)
        {
            await _repositoryWrapper.Студенты.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Студенты model)
        {
            _repositoryWrapper.Студенты.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Студенты
                .FindByCondition(x => x.IdСтудента == id);

            _repositoryWrapper.Студенты.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
