using MediatR;
using Request.Application.Absreactions;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Orders.Commands;
using Wood.Application.Usecases.Requests.Commands;

namespace Wood.Application.Usecases.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDeliveryDbContext _context;
        public CreateOrderCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // AmbulanceInfo? ambulanceInfo = await _context.amulanceInfo.FirstOrDefaultAsync(cancellationToken);

            Order info = new Order()
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
            };
            await _context.order.AddAsync(info, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
