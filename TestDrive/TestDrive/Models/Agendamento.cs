using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public Veiculo Veiculo { get; private set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set { dataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get; set; }

        public Agendamento(string nome, string fone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Telefone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }
    }
}