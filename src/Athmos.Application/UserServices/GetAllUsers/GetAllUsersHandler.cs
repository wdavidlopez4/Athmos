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

namespace Athmos.Application.UserServices.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDTO>>
    {
        private readonly IMapObject mapObject;

        private readonly IRepository<User> repository;

        public GetAllUsersHandler(IMapObject mapObject, IRepository<User> repository)
        {
            this.mapObject = mapObject;
            this.repository = repository;
        }

        public async Task<List<GetAllUsersDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users;

            //verificar peticion
            Guard.Against.Null(request, nameof(request));

            //obtener usuarios, mapear y retornar
            users = await this.repository.GetAll();

            return this.mapObject.Map<List<User>, List<GetAllUsersDTO>>(users);
        }
    }
}
