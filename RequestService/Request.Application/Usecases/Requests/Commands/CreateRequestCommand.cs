using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Requests.Commands
{
    public class CreateRequestCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
