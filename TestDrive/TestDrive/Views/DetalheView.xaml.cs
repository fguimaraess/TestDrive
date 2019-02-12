using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {

        public Veiculo Veiculo { get; set; }
        public string TextoFreioAbs { get { return string.Format("Freio Abs - R$ {0}", Veiculo.FreioAbs); } }
        public string TextoArCondicionado { get { return string.Format("Ar Condicionado - R$ {0}", Veiculo.ArCondicionado); } }
        public string TextoMp3Player { get { return string.Format("Mp3 Player - R$ {0}", Veiculo.Mp3Player); } }

        public bool TemFreioAbs
        {
            get { return Veiculo.TemFreioAbs; }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get { return Veiculo.TemArCondicionado; }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get { return Veiculo.TemMp3Player; }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();

            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}
