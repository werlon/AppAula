using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppAula.AulaControles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAula
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaPrincipal : ContentPage
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void AulaControles_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Aula Xamarin","Bem vindo","OK");
        }

        private void DatePickerMenu_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageDatePicker());
        }

        private void TelaContato_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppAula.View.TelaContato());
        }

        private void Reload_Activated(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PageReload());
        }

        private void TextoEditor_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageTexto());
        }

        private void PagePicker_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagePicker());
        }

        private void ConsultaCep_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageConsultaCep());
        }
    }
}