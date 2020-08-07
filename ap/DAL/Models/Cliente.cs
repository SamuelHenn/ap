// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cliente : AuditableEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNacimento { get; set; }
        public int EnderecoCobrancaId { get; set; }

        public Endereco EnderecoCobranca { get; set; }

        public ICollection<Instalacao> ListaInstalacao { get; set; }
    }
}
