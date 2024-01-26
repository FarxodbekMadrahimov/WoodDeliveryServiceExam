using MediatR;
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
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        private readonly IDeliveryDbContext _context;
        public CreateRequestCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            // AmbulanceInfo? ambulanceInfo = await _context.amulanceInfo.FirstOrDefaultAsync(cancellationToken);

            Requesting info = new Requesting()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Message = request.Message,
            };
            await _context.requests.AddAsync(info, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
