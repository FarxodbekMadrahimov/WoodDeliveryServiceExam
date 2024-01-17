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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUsersCommand, int>
    {
        private readonly IDeliveryDbContext _context;
        public DeleteUserCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            User? @class = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);

            if (@class == null)
                throw new Exception();

            _context.user.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
