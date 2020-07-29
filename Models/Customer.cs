using System;

namespace ConsoleBankApplication.Models
{
    internal class Customer
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private string Password { get; set; }

        public Customer(Guid ID, string name, string email, string password)
        {
            this.ID = ID;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}