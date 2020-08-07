// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ap.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNacimento { get; set; }

        public EnderecoViewModel EnderecoCobranca { get; set; }

        public ICollection<InstalacaoViewModel> ListaInstalacao { get; set; }
    }




    public class CustomerViewModelValidator : AbstractValidator<ClienteViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(register => register.Nome).NotEmpty().WithMessage("Customer name cannot be empty");
        }
    }
}
