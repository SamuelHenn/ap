// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Fatura : AuditableEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataLeitura { get; set; }
        public DateTime DataVencimento { get; set; }
        public int NumeroLeitura { get; set; }
        public decimal ValorConta { get; set; }

        public int InstalacaoId { get; set; }


        public Instalacao Instalacao { get; set; }
    }
}
