using Domain.Interfaces;
using Domain.Models;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TaskTypesRepository : RepositoryBase<ТипыЗаданий>, ITaskTypesRepository
    {
        public TaskTypesRepository(SqlContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}