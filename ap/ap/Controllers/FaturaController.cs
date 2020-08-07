using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap.ViewModels;
using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace ap.Controllers
{
    [Route("api/[controller]")]
    public class FaturaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FaturaController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allCustomers = _unitOfWork.Faturas.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClienteViewModel>>(allCustomers));
        }
    }
}
