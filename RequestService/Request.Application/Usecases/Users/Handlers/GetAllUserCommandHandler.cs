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
    public class GetAllUserCommandHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IDeliveryDbContext _context;

        public GetAllUserCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> result = await _context.user
                .Include(x => x.Product)
                .ThenInclude(x => x.Orders)
                .ToListAsync(cancellationToken);
            if (result == null)
                throw new Exception();
            return result;
        }
    }

}
