using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Application.UserServices.GetAllUsers
{
    public class GetAllUsersDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }
    }
}
