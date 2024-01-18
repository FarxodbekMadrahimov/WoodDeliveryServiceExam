using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Requests.Commands
{
    public class DeleteRequestCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
