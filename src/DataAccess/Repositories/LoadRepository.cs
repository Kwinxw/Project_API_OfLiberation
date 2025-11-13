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
    public class LoadRepository : RepositoryBase<Нагрузка>, ILoadRepository
    {
        public LoadRepository(SqlContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}