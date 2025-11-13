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
    public class QuestsService : IQuestsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public QuestsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Задания>> GetAll()
        {
            return await _repositoryWrapper.Quests.FindAll();
        }

        public async Task<Задания> GetById(int id)
        {
            var quest = await _repositoryWrapper.Quests
                .FindByCondition(x => x.IdЗадания == id);
            return quest.First();
        }

        public async Task Create(Задания model)
        {
            await _repositoryWrapper.Quests.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Задания model)
        {
            _repositoryWrapper.Quests.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var quest = await _repositoryWrapper.Quests
                .FindByCondition(x => x.IdЗадания == id);

            _repositoryWrapper.Quests.Delete(quest.First());
            _repositoryWrapper.Save();
        }

        public async Task<List<Задания>> GetByStudentId(int studentId)
        {
            var quests = await _repositoryWrapper.Quests
                .FindByCondition(q => q.IdОсвобожденияNavigation.IdСтудента == studentId);
            return quests;
        }

        public async Task<List<Задания>> GetByLiberationId(int liberationId)
        {
            var quests = await _repositoryWrapper.Quests
                .FindByCondition(q => q.IdОсвобождения == liberationId);
            return quests;
        }

        public async Task<List<Задания>> GetOverdueQuests()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var quests = await _repositoryWrapper.Quests
                .FindByCondition(q => q.СрокСдачи < today);
            return quests;
        }
    }
}