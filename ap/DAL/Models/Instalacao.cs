// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Instalacao : AuditableEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; }

        public Cliente Cliente { get; set; }
        public Endereco EnderecoInstalacao { get; set; }

        public ICollection<Fatura> ListaFatura { get; set; }
    }
}
