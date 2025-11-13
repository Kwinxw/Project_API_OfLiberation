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
    public class SpecialtiesRepository : RepositoryBase<Специальности>, ISpecialtiesRepository
    {
        public SpecialtiesRepository(SqlContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}