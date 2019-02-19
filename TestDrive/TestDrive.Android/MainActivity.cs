using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TestDrive.Media;
using TestDrive.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TestDrive.Droid
{
    [Activity(Label = "TestDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity :
        global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        , ICamera
    {
        static Java.IO.File arquivoImagem;

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            
            arquivoImagem = PegarArquivoImagem();

            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(arquivoImagem));

            var activity = Forms.Context as Activity;

            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File PegarArquivoImagem()
        {
            Java.IO.File arquivoImagem;
            Java.IO.File diretorio = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Imagens");
            if (!diretorio.Exists())
                diretorio.Mkdirs();

            arquivoImagem = new Java.IO.File(diretorio, "MinhaFoto.jpg");

            return arquivoImagem;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            MessagingCenter.Send(arquivoImagem, "TirarFoto");
        }
    }
}