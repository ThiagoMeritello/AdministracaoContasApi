using AdministracaoContas.Api.ViewModels;
using AdministracaoContas.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdministracaoContas.Api.Controllers
{
    [Route("api/FormaPagamento")]
    [ApiController]
    public class FormaPagamentoController : MainController
    {
        private readonly IFormaPagamentoService _formaPagamentoService;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        private readonly IMapper _mapper;

        public FormaPagamentoController(INotificador notificador,
             IFormaPagamentoService formaPagamentoService,
             IFormaPagamentoRepository formaPagamentoRepository,
             IMapper _mapper) : base(notificador)
        {
            _formaPagamentoService = formaPagamentoService;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public async Task<IEnumerable<FormaPagamentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FormaPagamentoViewModel>>(await _formaPagamentoRepository.ObterTodos());
        }

    }
}
