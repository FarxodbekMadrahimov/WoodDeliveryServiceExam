using MediatR;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Orders.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Order>>
    {
    }
}
