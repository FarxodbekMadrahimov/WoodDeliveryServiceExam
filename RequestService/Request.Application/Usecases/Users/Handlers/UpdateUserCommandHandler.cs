using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IDeliveryDbContext _context;

        public UpdateUserCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);
            if (user == null)
                throw new Exception();

            user.UserId = request.Id;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Address = request.Address;



            _context.user.Update(user);
            int result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}