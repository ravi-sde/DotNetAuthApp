using DotNetAuthApp.Core.Entities;
using DotNetAuthApp.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetAuthApp.Core.Repositories.Query
{
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Int64 id);
        Task<Customer> GetCustomerByEmail(string email);
    }
}