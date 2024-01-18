using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Requests.Commands;
using Wood.Application.Usecases.Users.Commands;

namespace Wood.Application.Usecases.Requests.Handlers
{
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, int>
    {
        private readonly IDeliveryDbContext _context;
        public DeleteRequestCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            Requesting? @class = await _context.requests.FirstOrDefaultAsync(x => x.RequestId == request.Id, cancellationToken);

           // if (@class == null)
              //  throw new Exception();

            _context.requests.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }

}
