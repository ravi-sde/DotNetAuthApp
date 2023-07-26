using Microsoft.Extensions.Configuration;
using DotNetAuthApp.Core.Repositories.Query.Base;
using DotNetAuthApp.Infrastructure.Data;

namespace DotNetAuthApp.Infrastructure.Repository.Query.Base
{
    public class QueryRepository<T> : DbConnector,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}