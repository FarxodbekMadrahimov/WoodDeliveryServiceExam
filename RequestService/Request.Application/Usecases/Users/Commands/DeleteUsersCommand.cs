using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Application.Usecases.Users.Commands
{
    public class DeleteUsersCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

}
