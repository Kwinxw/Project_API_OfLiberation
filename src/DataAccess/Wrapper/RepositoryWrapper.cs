using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Wrapper;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SqlContext _repoContext;
        private IStudentsRepository _user;
        private ITeachersRepository _преподаватель;
        private IGroupsRepository _group;
        private ILoadRepository _нагрузка;
        private ISpecialtiesRepository _specialties;
        private IQuestsRepository _quests;
        private ITaskTypesRepository _taskTypes;
        private IReasonsForLiberationRepository _reasonsForLiberation;
        private ILiberationRepository _liberation;
        private IBranchesRepository _branches;
        private IGradeRepository _grade;
        public IStudentsRepository Студенты
        {
            get
            {
                if (_user == null)
                {
                    _user = new StudentsRepository(_repoContext);
                }
                return _user;
            }
        }

        public IGroupsRepository Группы
        {
            get
            {
                if (_group == null)
                {
                    _group = new GroupsRepository(_repoContext);
                }
                return _group;
            }
        }

        public ITeachersRepository Преподаватели
        {
            get
            {
                if (_преподаватель == null)
                {
                    _преподаватель = new TeachersRepository(_repoContext);
                }
                return _преподаватель;
            }
        }

        public ILoadRepository Нагрузка
        {
            get
            {
                if (_нагрузка == null)
                {
                    _нагрузка = new LoadRepository(_repoContext);
                }
                return _нагрузка;
            }
        }

        public ISpecialtiesRepository Specialties
        {
            get
            {
                if (_specialties == null)
                {
                    _specialties = new SpecialtiesRepository(_repoContext);
                }
                return _specialties;
            }
        }

        public IQuestsRepository Quests
        {
            get
            {
                if (_quests == null)
                {
                    _quests = new QuestsRepository(_repoContext);
                }
                return _quests;
            }
        }

        public ITaskTypesRepository TaskTypes
        {
            get
            {
                if (_taskTypes == null)
                {
                    _taskTypes = new TaskTypesRepository(_repoContext);
                }
                return _taskTypes;
            }
        }

        public IReasonsForLiberationRepository ReasonsForLiberation
        {
            get
            {
                if (_reasonsForLiberation == null)
                {
                    _reasonsForLiberation = new ReasonsForLiberationRepository(_repoContext);
                }
                return _reasonsForLiberation;
            }
        }

        public ILiberationRepository Liberation
        {
            get
            {
                if (_liberation == null)
                {
                    _liberation = new LiberationRepository(_repoContext);
                }
                return _liberation;
            }
        }

        public IBranchesRepository Branches
        {
            get
            {
                if (_branches == null)
                {
                    _branches = new BranchesRepository(_repoContext);
                }
                return _branches;
            }
        }

        public IGradeRepository Grade
        {
            get
            {
                if (_grade == null)
                {
                    _grade = new GradeRepository(_repoContext);
                }
                return _grade;
            }
        }

        public RepositoryWrapper(SqlContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}