using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        public string Nome
        {
            get { return this.usuario.Nome; }
            set { usuario.Nome = value; }
        }

        public string Email
        {
            get { return usuario.Email; }
            set { usuario.Email = value; }
        }

        public string DataNascimento
        {
            get { return this.usuario.DataNascimento; }
            set { usuario.DataNascimento = value; }
        }

        public string Telefone
        {
            get { return usuario.Telefone; }
            set { usuario.Telefone = value; }
        }

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }


        private readonly Usuario usuario;
        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send(usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send(usuario, "SalvarPerfil");
            });

            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });
        }
    }
}
