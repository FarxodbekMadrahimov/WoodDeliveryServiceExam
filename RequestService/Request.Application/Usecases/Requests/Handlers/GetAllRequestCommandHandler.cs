using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Application.Usecases.Requests.Queries;
using Wood.Application.Usecases.Users.Queries;

namespace Wood.Application.Usecases.Requests.Handlers
{
    public class GetAllRequestCommandHandler : IRequestHandler<GetAllRequestQuery, IEnumerable<Requesting>>
    {
        private readonly IDeliveryDbContext _context;

        public GetAllRequestCommandHandler (IDeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Requesting>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            List<Requesting> result = await _context.requests.ToListAsync(cancellationToken);
            if (result == null)
                throw new Exception();
            return result;
        }
    }

}
