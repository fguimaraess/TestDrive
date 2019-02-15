using System;
using System.Net.Http;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Text;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo { get { return Agendamento.Veiculo; } set { Agendamento.Veiculo = value; } }
        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                Agendamento.Nome = value;
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
        const string URL_TO_POST = "https://aluracar.herokuapp.com/salvaragendamento";

        public ICommand AgendarCommand { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
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
            var cliente = new HttpClient();

            var dataHoraAgendamento =
                new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = DataAgendamento
            });
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_TO_POST, conteudo);
            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send(Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send(new ArgumentException(), "ErroAgendamento");
            }
        }
    }
}
