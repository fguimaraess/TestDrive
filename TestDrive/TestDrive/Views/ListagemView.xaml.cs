using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            this.Veiculos = new ListagemVeiculos().Veiculos;

            this.BindingContext = this;
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}
