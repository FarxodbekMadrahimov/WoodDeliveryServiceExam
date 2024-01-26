using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.deliver;
using Wood.Application.Usecases.Orders.Queries;

namespace Wood.Application.Usecases.Orders.Handlers
{
    public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
    {
        private readonly IDeliveryDbContext _context;

        public GetAllOrderCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> result = await _context.order.Include(x => x.User).ToListAsync(cancellationToken);
            if (result == null)
                throw new Exception();
            return result;
        }
    }


}
