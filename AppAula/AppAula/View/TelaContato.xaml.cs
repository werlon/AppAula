using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAula.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAula.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaContato : ContentPage
    {
        public TelaContato()
        {
            InitializeComponent();
            this.listarTudo();
        }

        private void listarTudo()
        {
            using (var dados = new ContatoRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            var contato = new Contato
            {
                Nome = this.Nome.Text,
                Email = this.Email.Text,
                Telefone = this.Telefone.Text
            };

            using (var dados = new ContatoRepository())
            {
                dados.Insert(contato);
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void RemoverClicked(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

            //this.Lista.SelectedItem;
            this.listarTudo();
        }
    }
}