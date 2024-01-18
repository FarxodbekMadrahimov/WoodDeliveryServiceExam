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
    public class GetRequestByIdCommandHandler : IRequestHandler<GetRequestByIdQuery, Requesting>
    {
        private readonly IDeliveryDbContext _context;

        public GetRequestByIdCommandHandler(IDeliveryDbContext context)
        {
            _context = context;
        }

        async Task<Requesting> IRequestHandler<GetRequestByIdQuery, Requesting>.Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            Requesting? ambulanceInfo = await _context.requests.FirstOrDefaultAsync(x => x.RequestId == request.Id, cancellationToken);

            if (ambulanceInfo == null)
                throw new Exception();

            return ambulanceInfo;
        }
    }


    
}
