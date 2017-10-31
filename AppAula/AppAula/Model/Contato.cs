using SQLite.Net.Attributes;

namespace AppAula.Model
{
    [Table("Contato")]
    class Contato
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }


        public override string ToString()
        {
            return string.Format("Id=[{0}],Nome={1}, Email={2}, Telefone={3}", Id, Nome, Email, Telefone);
        }
    }
}
