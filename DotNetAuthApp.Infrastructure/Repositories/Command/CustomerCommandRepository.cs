using DotNetAuthApp.Core.Entities;
using DotNetAuthApp.Core.Repositories.Command;
using DotNetAuthApp.Infrastructure.Data;
using DotNetAuthApp.Infrastructure.Repository.Command.Base;

namespace DotNetAuthApp.Infrastructure.Repository.Command
{

    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(DotNetAuthAppContext context) : base(context)
        {

        }
    }
}