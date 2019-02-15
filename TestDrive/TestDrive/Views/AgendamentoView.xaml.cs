using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
               async (AgendamentoCallback) =>
                {
                    var confirma = await DisplayAlert("Salvar Agendamento",
                        "Deseja mesmo enviar o agendamento?",
                        "Sim", "Não");

                    if (confirma)
                    {
                        this.ViewModel.SalvarAgendamento();
                        //DisplayAlert("Agendamento",
                        //        string.Format(@"
                        //        Veiculo: {0}
                        //        Nome: {1}
                        //        Telefone: {2}
                        //        Email: {3}
                        //        Data Agendamento: {4}
                        //        Hora Agendamento: {5}",
                        //        ViewModel.Agendamento.Veiculo.Nome,
                        //        ViewModel.Agendamento.Nome,
                        //        ViewModel.Agendamento.Telefone,
                        //        ViewModel.Agendamento.Email,
                        //        ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                        //        ViewModel.Agendamento.HoraAgendamento),
                        //        "Ok");
                    }
                });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                (res) =>
                {
                    DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "OK");
                });
            MessagingCenter.Subscribe<ArgumentException>(this, "ErroAgendamento",
                (res) =>
                {
                    DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente mais tarde!", "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ErroAgendamento");
        }
    }
}