using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public Usuario Usuario { get; set; }
        public DetalheView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();

            this.Veiculo = veiculo;
            this.Usuario = usuario;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "ProximoCommand", 
                (veiculoCallback) =>
                {
                    Navigation.PushAsync(new AgendamentoView(veiculoCallback, Usuario));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "ProximoCommand");
        }
    }
}
