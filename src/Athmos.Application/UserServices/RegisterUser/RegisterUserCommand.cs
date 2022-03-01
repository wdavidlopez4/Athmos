using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Application.UserServices.RegisterUser
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }
    }
}
