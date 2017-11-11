using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppAula.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAula.AulaControles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageConsultaCep : ContentPage
    {
        public PageConsultaCep()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (txtCep.Text != null && txtCep.Text.Length == 8)
            {
                Cep cep = await Service.ConsultaCepService.BuscaCep(txtCep.Text);
                this.Cidade.Text = cep.localidade.ToString();
                
            }
            else
            {
                lblResultado.Text = "O CEP é invalido";
                lblResultado.TextColor = Color.Red;
            }
        }
    }
}