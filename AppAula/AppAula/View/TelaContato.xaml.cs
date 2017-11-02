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
        private Contato _contato = null;
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
                if (this._contato != null)
                {
                    _contato.Nome = this.Nome.Text;
                    _contato.Email = this.Email.Text;
                    _contato.Telefone = this.Telefone.Text;
                    dados.Update(this._contato);
                } else
                {
                    if (this.Nome != null)
                    {
                        this._contato = new Contato
                        {
                            Nome = this.Nome.Text,
                            Email = this.Email.Text,
                            Telefone = this.Telefone.Text
                        };
                        dados.Insert(this._contato);
                    }

                }
                
                LimparCampos();
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void ExcluirClicked(object sender, EventArgs e)
        {
            this._contato = this.Lista.SelectedItem as Contato;
            if (this._contato != null)
            {
                using (var dados = new ContatoRepository())
                {
                    dados.Delete(this._contato);
                    this.Lista.ItemsSource = dados.Listar();
                    LimparCampos();
                }
            }
        }

        protected void VisualizarItemClicked(object sender, EventArgs e)
        {
            this._contato = this.Lista.SelectedItem as Contato;
            if (this._contato != null)
            {
                this.Nome.Text = this._contato.Nome;
                this.Email.Text = this._contato.Email;
                this.Telefone.Text = _contato.Telefone;
            }
        }

        private void LimparCampos()
        {
            this.Nome.Text = "";
            this.Email.Text = "";
            this.Telefone.Text = "";
            this._contato = null;
        }
    }
}