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
using Wood.Application.Usecases.Orders.Commands;
using Wood.Application.Usecases.Requests.Commands;

namespace Wood.Application.Usecases.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IDeliveryDbContext _context;
        public DeleteOrderCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order? @class = await _context.order.FirstOrDefaultAsync(x => x.OrderId == request.Id, cancellationToken);

            // if (@class == null)
            //  throw new Exception();

            _context.order.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
