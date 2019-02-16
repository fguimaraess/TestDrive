using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(
            async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(Login, Senha));
            }, () =>
            {
                return !string.IsNullOrEmpty(Login)
                && !string.IsNullOrEmpty(Senha);
            });
        }
    }
}
