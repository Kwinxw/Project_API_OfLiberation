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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Имя))
            {
                throw new ArgumentException(nameof(model.Имя));
            }

            await _repositoryWrapper.Студенты.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Студенты model)
        {
            await _repositoryWrapper.Студенты.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Студенты
                .FindByCondition(x => x.IdСтудента == id);

            await _repositoryWrapper.Студенты.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}
