using Newtonsoft.Json;
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
            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                                     {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string,string>("senha", login.senha)
                    });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");

                HttpResponseMessage resultado = null;
                try
                {
                    resultado = await cliente.PostAsync("/login", camposFormulario);
                }
                catch
                {
                    MessagingCenter.Send(new LoginException(@"Ocorreu um erro de comunicação com o servidor! 
                Verifique sua conexão."), "FalhaLogin");
                }

                if (resultado.IsSuccessStatusCode)
                {
                    var resultString = await resultado.Content.ReadAsStringAsync();
                    var loginUsuario = JsonConvert.DeserializeObject<ResultadoLogin>(resultString);

                    MessagingCenter.Send(loginUsuario.usuario, "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send(new LoginException("Usuário ou senha incorretos!"), "FalhaLogin");
                }
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
