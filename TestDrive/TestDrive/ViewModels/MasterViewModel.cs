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
        public ICommand SalvarPerfilCommand { get; private set; }


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

            SalvarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send(usuario, "SalvarPerfil");
            });
        }
    }
}
