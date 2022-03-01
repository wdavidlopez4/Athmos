using Athmos.Application.UserServices.GetAllUsers;
using Athmos.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Infrastructure.MappObject
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            this.CreateMap<User, GetAllUsersDTO>();
        }
    }
}
