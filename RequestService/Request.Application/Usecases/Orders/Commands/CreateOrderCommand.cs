using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wood.Domain.Dtos.OrderDto;

namespace Wood.Application.Usecases.Orders.Commands
{
    public class CreateOrderCommand : OrdersDto , IRequest<int>
    {
    }
}
