using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IStudentsRepository Студенты { get; }
        ITeachersRepository Преподаватели { get; }
        IGroupsRepository Группы { get; }
        ILoadRepository Нагрузка { get; }
        ISpecialtiesRepository Specialties { get; }
        IQuestsRepository Quests { get; }
        ITaskTypesRepository TaskTypes { get; }
        IReasonsForLiberationRepository ReasonsForLiberation { get; }
        ILiberationRepository Liberation { get; }
        IBranchesRepository Branches { get; }
        IGradeRepository Grade { get; }
        Task Save();
    }
}