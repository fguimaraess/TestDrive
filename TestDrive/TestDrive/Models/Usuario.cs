using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}
