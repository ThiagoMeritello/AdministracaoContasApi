﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdministracaoContas.Api.ViewModels;
using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdministracaoContas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : MainController
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IDespesaService _despesaService;
        private readonly IMapper _mapper;

        public DespesaController(INotificador notificador,
            IDespesaRepository despesaRepository,
            IDespesaService despesaService,
            IMapper mapper) : base(notificador)
        {
            _despesaRepository = despesaRepository;
            _despesaService = despesaService;
            _mapper = mapper;
        }

        [Route("ObterTodos")]
        [HttpGet]
        public async Task<IEnumerable<DespesaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DespesaViewModel>>(await _despesaRepository.ObterTodos());
        }

        [HttpGet]
        [Route("ObterPorId/{id:guid}")]
        public async Task<ActionResult<DespesaViewModel>> ObterPorId(Guid id)
        {
            var despesaViewModel = await ObterDespesa(id);

            if (despesaViewModel == null) return NotFound();

            return despesaViewModel;
        }

        [HttpGet]
        [Route("ObterPorIdDespesaParcelada/{id:guid}")]
        public async Task<ActionResult<DespesaViewModel>> ObterPorIdDespesaParcelada(Guid id)
        {
            var despesaViewModel = _mapper.Map<DespesaViewModel>(await _despesaRepository.ObterPorIdDespesaParcelada(id));
            
            if (despesaViewModel == null) return NotFound();

            return despesaViewModel;
        }

        [HttpGet]
        [Route("ObterPorDespesasFiltro/{mes:int}/{ano:int}")]
        public async Task<ActionResult<IList<DespesaViewModel>>> ObterPorDespesasFiltro(int mes, int ano, int? codigoFormaPagamento)
        {
            var despesaViewModel = _mapper.Map<List<DespesaViewModel>>(await _despesaRepository.ObterPorDespesasFiltro(mes, ano, codigoFormaPagamento));
            
            if (despesaViewModel == null) return NotFound();

            return despesaViewModel;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult<DespesaViewModel>> Adicionar(DespesaViewModel despesaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _despesaService.Adicionar(_mapper.Map<Despesa>(despesaViewModel));

            return CustomResponse(despesaViewModel);
        }

        [HttpPut]
        [Route("Atualizar/{id:guid}")]
        public async Task<ActionResult<DespesaViewModel>> Atualizar(Guid id, DespesaViewModel despesaViewModel)
        {
            if (id != despesaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomResponse();
            }

            var despesaAtualizada = await ObterDespesa(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            despesaAtualizada.DataCompra = despesaViewModel.DataCompra;
            despesaAtualizada.Loja = despesaViewModel.Loja;
            despesaAtualizada.Produto = despesaViewModel.Produto;
            despesaAtualizada.Valor = despesaViewModel.Valor;
            despesaAtualizada.FormaPagamento = despesaViewModel.FormaPagamento;
            despesaAtualizada.Parcela = despesaViewModel.Parcela;
            despesaAtualizada.DataPagamento = despesaViewModel.DataPagamento;

            await _despesaService.Atualizar(_mapper.Map<Despesa>(despesaViewModel));

            return CustomResponse(despesaViewModel);
        }

        [HttpDelete]
        [Route("Excluir/{id:guid}")]
        public async Task<ActionResult<DespesaViewModel>> Excluir(Guid id)
        {
            var despesa = await ObterDespesa(id);

            if (despesa == null) return NotFound();

            await _despesaService.Remover(id);

            return CustomResponse(despesa);
        }

        private async Task<DespesaViewModel> ObterDespesa(Guid id)
        {
            return _mapper.Map<DespesaViewModel>(await _despesaRepository.ObterPorId(id));
        }
    }
}
