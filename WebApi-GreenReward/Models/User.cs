using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenReward.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public User(string name, string cpf, string email, string senha)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Senha = senha;
        }
    }
}