﻿using System;
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
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();

            this.Veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}
