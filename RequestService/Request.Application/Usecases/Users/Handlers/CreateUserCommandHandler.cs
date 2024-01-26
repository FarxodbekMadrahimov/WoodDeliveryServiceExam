using MediatR;
using Request.Application.Absreactions;
using Request.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Users.Commands;

namespace Wood.Application.Usecases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int>
    {
        private readonly IDeliveryDbContext _context;
        public CreateUserCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // AmbulanceInfo? ambulanceInfo = await _context.amulanceInfo.FirstOrDefaultAsync(cancellationToken);

            User info = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,

                PhoneNumber = request.PhoneNumber,
                Address  = request.Address,
            };
            await _context.user.AddAsync(info, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
