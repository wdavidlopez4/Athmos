using Athmos.Application.UserServices.GetAllUsers;
using Athmos.Domain.Entities;
using Athmos.Domain.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Athmos.TestUnit.UserTest
{
    [TestClass]
    public class GetAllUsersTest
    {
        
        private readonly Mock<IRepository<User>> repository;

        private readonly Mock<IMapObject> map;

        public GetAllUsersTest(Mock<IRepository<User>> repository, Mock<IMapObject> map)
        {
            this.repository = repository;
            this.map = map;
        }

        /// <summary>
        /// testeamos el Caso de uso con normalidad
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_GetAllUser()
        {
            var request = new GetAllUsersQuery();
            var cancellationToken = new CancellationToken();

            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            List<User> users = new List<User>();
            users.Add(User.Build(id1, "Nombre1", "apellido1", 12, "email1@gmail.com"));
            users.Add(User.Build(id2, "Nombre2", "apellido2", 11, "email2@gmail.com"));

            List<GetAllUsersDTO> usersDTO = new List<GetAllUsersDTO>();
            usersDTO.Add(new GetAllUsersDTO()
            {
                Id = id1.ToString(),
                Name = "Nombre1",
                Lastname = "apellido1",
                Edad = 12,
                Email = "email1@gmail.com"
            });

            usersDTO.Add(new GetAllUsersDTO()
            {
                Id = id2.ToString(),
                Name = "Nombre2",
                Lastname = "apellido2",
                Edad = 11,
                Email = "email2@gmail.com"
            });

            this.repository.Setup(x => x.GetAll())
                .ReturnsAsync(users)
                .Verifiable();

            this.map.Setup(x => x.Map<List<User>, List<GetAllUsersDTO>>(users))
                .Returns(usersDTO)
                .Verifiable();

            var handler = new GetAllUsersHandler(map.Object, repository.Object);

            var dtos = await handler.Handle(request, cancellationToken);

            Assert.AreEqual(dtos, usersDTO);
        }
    }
}
