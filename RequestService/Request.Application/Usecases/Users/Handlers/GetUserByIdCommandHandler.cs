using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Users.Queries;

namespace Wood.Application.Usecases.Users.Handlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IDeliveryDbContext _context;

        public GetUserByIdCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? ambulanceInfo = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);

            if (ambulanceInfo == null)
                throw new Exception();

            return ambulanceInfo;
        }
    }
}
