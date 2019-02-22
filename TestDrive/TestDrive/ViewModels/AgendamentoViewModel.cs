using System;
using System.Net.Http;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Text;
using TestDrive.Data;
using TestDrive.Services;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Agendamento Agendamento { get; set; }

        private string modelo;
        public string  Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        private decimal preco;
        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                this.Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get { return Agendamento.Telefone; }
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public DateTime DataAgendamento { get { return Agendamento.DataAgendamento; } set { Agendamento.DataAgendamento = value; } }
        public TimeSpan HoraAgendamento { get { return Agendamento.HoraAgendamento; } set { Agendamento.HoraAgendamento = value; } }

        public ICommand AgendarCommand { get; set; }

        public AgendamentoViewModel(Veiculo veiculo, Usuario usuario)
        {
            this.Agendamento = new Agendamento(usuario.Nome, usuario.Telefone, usuario.Email, veiculo.Nome, veiculo.Preco);
            
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send(this.Agendamento, "Agendamento");
            }, () => //Can Execute?
            {
                return !string.IsNullOrEmpty(this.Nome)
                && !string.IsNullOrEmpty(this.Telefone)
                && !string.IsNullOrEmpty(this.Email);
            });
        }

        public async void SalvarAgendamento()
        {
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.Agendamento);
        }

    }

    
}
