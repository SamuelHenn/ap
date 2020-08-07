// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;


namespace ap.ViewModels
{
    public class InstalacaoViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ClienteViewModel Cliente { get; set; }
        public EnderecoViewModel EnderecoInstalacao { get; set; }

        public ICollection<FaturaViewModel> ListaFatura { get; set; }
    }
}
