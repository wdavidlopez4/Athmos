using Ardalis.GuardClauses;
using Athmos.Domain.Entities;
using Athmos.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Athmos.Application.UserServices.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IRepository<User> repository;

        public RegisterUserHandler(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user;

            //verificar peticion
            Guard.Against.Null(request, nameof(request));

            //verificar que el usuario no exista
            if (this.repository.Exists(x => x.Email == request.Email))
                throw new Exception("EL usuario ya existe");


            //crear, guardar y retornar
            user = User.Build(id: Guid.NewGuid(), name: request.Name, 
                lastname: request.Lastname, edad: request.Edad, email: request.Email);

            await this.repository.Save(user);

            return 0;
        }
    }
}
