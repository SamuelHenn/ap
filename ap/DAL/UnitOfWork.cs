// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IClienteRepository _clientes;
        IInstalacaoRepository _instalacoes;
        IFaturaRepository _faturas;
        IEnderecoRepository _enderecos;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public IClienteRepository Clientes
        {
            get
            {
                if (_clientes == null)
                    _clientes = new ClienteRepository(_context);

                return _clientes;
            }
        }



        public IInstalacaoRepository Instalacoes
        {
            get
            {
                if (_instalacoes == null)
                    _instalacoes = new InstalacaoRepository(_context);

                return _instalacoes;
            }
        }



        public IFaturaRepository Faturas
        {
            get
            {
                if (_faturas == null)
                    _faturas = new FaturaRepository(_context);

                return _faturas;
            }
        }

        public IEnderecoRepository Enderecos
        {
            get
            {
                if (_enderecos == null)
                    _enderecos = new EnderecoRepository(_context);

                return _enderecos;
            }
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
