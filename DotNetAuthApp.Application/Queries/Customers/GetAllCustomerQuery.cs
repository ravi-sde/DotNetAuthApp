using MediatR;
using DotNetAuthApp.Core.Entities;
using DotNetAuthApp.Core.Repositories.Query;

namespace DotNetAuthApp.Application.Queries.Customers
{
    // Customer query with List<Customer> response
    public record GetAllCustomerQuery : IRequest<List<Customer>>
    {

    }

    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllCustomerHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return (List<Customer>)await _customerQueryRepository.GetAllAsync();
        }
    }
}

