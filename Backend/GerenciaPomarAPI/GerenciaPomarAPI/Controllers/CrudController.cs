using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaPomar.Core.Models;
using GerenciaPomar.Service;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaPomar.API.Controllers
{
    public class CrudController<T> : Controller where T : EntidadeBase
    {
        private readonly IGenericService<T> service;

        public CrudController(IGenericService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Listar(int pagina, int total)
        {
            return Ok(await service.BuscarTodos(pagina, total));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Salvar([FromBody] T entidade)
        {
            service.Salvar(entidade);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Guid codigo)
        {
            service.Excluir(codigo);
            return Ok();
        }
    }
}