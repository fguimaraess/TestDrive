using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async System.Threading.Tasks.Task FazerLogin(Login login)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                                         {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string,string>("senha", login.senha)
                    });

                    cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");

                    var resultado = await cliente.PostAsync("/login", camposFormulario);

                    if (resultado.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send(new Usuario(), "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send(new LoginException("Usuário ou senha incorretos!"), "FalhaLogin");
                    }
                }
            }
            catch
            {
                MessagingCenter.Send(new LoginException(@"Ocorreu um erro de comunicação com o servidor! 
                Verifique sua conexão."), "FalhaLogin");
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
