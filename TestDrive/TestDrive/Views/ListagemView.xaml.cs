﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }
        readonly Usuario usuario;

        public ListagemView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (veiculoSelecionado) =>
                {
                    Navigation.PushAsync(new DetalheView(veiculoSelecionado, usuario));
                });

            await this.ViewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
