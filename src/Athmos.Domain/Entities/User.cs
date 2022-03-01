using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string Lastname { get; private set; }

        public int Edad { get; private set; }

        public string Email { get; private set; }

        /// <summary>
        /// for ef
        /// </summary>
        private User():base()
        {

        }

        private User(Guid id, string name, string lastname, int edad, string email): base(id)
        {
            Name = Guard.Against.NullOrEmpty( name, nameof(name));
            Lastname = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
            Edad = Guard.Against.NegativeOrZero(edad, nameof(edad));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
        }

        public static User Build(Guid id, string name, string lastname, int edad, string email)
        {
            return new User(id, name, lastname, edad, email);
        }

        public void ChangeMainAttributes(string name, string lastname, int edad)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Lastname = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
            Edad = Guard.Against.NegativeOrZero(edad, nameof(edad));
        }
    }
}
