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

namespace Athmos.Application.UserServices.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IRepository<User> repository;

        public UpdateUserHandler(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user;

            //verificar peticion
            Guard.Against.Null(request, nameof(request));

            //verificar que el usuario no exista
            if (this.repository.Exists(x => x.Id.ToString() != request.Id))
                throw new Exception("El usuario que intenta actualizar no existe");

            //crear y actualizar el usuario
            user = await this.repository.Get(request.Id);
            user.ChangeMainAttributes(name: request.Name, lastname: request.Lastname, edad: request.Edad);

            await this.repository.Update(user);
            return 0;
        }
    }
}
