// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Linq;


namespace ap.ViewModels
{
    public class FaturaViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataLeitura { get; set; }
        public DateTime DataVencimento { get; set; }
        public int NumeroLeitura { get; set; }
        public decimal ValorConta { get; set; }


        public InstalacaoViewModel Instalacao { get; set; }
    }
}
