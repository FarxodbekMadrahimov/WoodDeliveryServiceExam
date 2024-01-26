using MediatR;
using Microsoft.EntityFrameworkCore;
using Request.Application.Absreactions;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
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
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Add any other options you need
            };

            List<Requesting> result = await _context.requests.ToListAsync(cancellationToken);

            if (result == null)
                throw new Exception();

            // Serialize the result to JSON with the configured options
            string serializedResult = JsonSerializer.Serialize(result, jsonSerializerOptions);

            // Deserialize the JSON back to the object to handle object cycles
            result = JsonSerializer.Deserialize<List<Requesting>>(serializedResult, jsonSerializerOptions);

            return result;
        }

    }

}
