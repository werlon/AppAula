using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;

namespace AppAula.Model
{
    class ContatoRepository : IDisposable
    {
        private SQLiteConnection _conexao;

        public ContatoRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLiteConnection(config.Plataforma,   System.IO.Path.Combine(config.DiretorioDB,"bancodedados2.db3"));
            _conexao.CreateTable<Contato>();
        }

        public void Insert(Contato contato)
        {
            _conexao.Insert(contato);
        }

        public void Update(Contato contato)
        {
            _conexao.Update(contato);
        }

        public void Delete(Contato contato)
        {
            _conexao.Delete(contato);
        }

        public List<Contato> Listar()
        {
            return _conexao.Table<Contato>().OrderBy(c => c.Nome).ToList();
        }

        public Contato ObterPorId(int id)
        {
            return _conexao.Table<Contato>().FirstOrDefault(c => c.Id == id);
        }
        
        public void Dispose()
        {
            _conexao.Dispose();
        }
    }

    
}
