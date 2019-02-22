using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        readonly AgendamentosUsuarioViewModel ViewModel;
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this.ViewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado",
                async (agendamento) =>
                {
                    if (!agendamento.Confirmado)
                    {
                        var deveReenviar = await DisplayAlert("Reenviar Agendamento", "Deseja reenviar o agendamento?", "Sim", "Não");

                        if (deveReenviar)
                        {
                            AgendamentoService agendamentoService = new AgendamentoService();
                            await agendamentoService.EnviarAgendamento(agendamento);
                            this.ViewModel.AtualizarLista();
                        }
                    }
                });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", 
                async (agendamento) => 
                {
                    await DisplayAlert("Reenviar", "Reenvio com sucesso!", "OK");
                });
            MessagingCenter.Subscribe<Agendamento>(this, "ErroAgendamento",
                async (agendamento) =>
                {
                    await DisplayAlert("Reenviar", "Erro ao reenviar!", "OK");

                });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "ErroAgendamento");
        }
    }
}