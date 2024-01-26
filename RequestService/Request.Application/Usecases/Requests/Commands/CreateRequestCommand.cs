using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Requests.Commands
{
    public class CreateRequestCommand : Request.Domain.Entitites.Request.Requesting, IRequest<int>
    {
        
       
    }
}
