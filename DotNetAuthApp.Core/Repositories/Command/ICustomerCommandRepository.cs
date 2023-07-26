using DotNetAuthApp.Core.Entities;
using DotNetAuthApp.Core.Repositories.Command.Base;

namespace DotNetAuthApp.Core.Repositories.Command
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {

    }
}