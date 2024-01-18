using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
