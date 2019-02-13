using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo { get { return Agendamento.Veiculo; } set { Agendamento.Veiculo = value; } }
        public string Nome { get { return Agendamento.Nome; } set { Agendamento.Nome = value; } }
        public string Telefone { get { return Agendamento.Telefone; } set { Agendamento.Telefone = value; } }
        public string Email { get { return Agendamento.Email; } set { Agendamento.Email = value; } }
        public DateTime DataAgendamento { get { return Agendamento.DataAgendamento; } set { Agendamento.DataAgendamento = value; } }
        public TimeSpan HoraAgendamento { get { return Agendamento.HoraAgendamento; } set { Agendamento.HoraAgendamento = value; } }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
        }
    }
}
