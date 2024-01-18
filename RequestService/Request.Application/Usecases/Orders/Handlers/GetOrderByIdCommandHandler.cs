using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Orders.Queries;
using Wood.Application.Usecases.Requests.Queries;
using Wood.Application.Usecases.Users.Queries;

namespace Wood.Application.Usecases.Orders.Handlers
{
    public class GetOrderByIdCommandHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IDeliveryDbContext _context;

        public GetOrderByIdCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order? ambulanceInfo = await _context.order.FirstOrDefaultAsync(x => x.OrderId == request.Id, cancellationToken);

  

            return ambulanceInfo;
        }
    }
}
