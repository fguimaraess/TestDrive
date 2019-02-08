using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); } }
    }

    public partial class MainPage : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 50000 },
                new Veiculo { Nome = "HB20 S", Preco = 40000}
            };

            this.BindingContext = this;
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;

            DisplayAlert("Test Drive",
                string.Format("Você selecionou o modelo {0}, de valor {1}", veiculo.Nome, veiculo.PrecoFormatado),
                "Ok"
                );
        }
    }
}
