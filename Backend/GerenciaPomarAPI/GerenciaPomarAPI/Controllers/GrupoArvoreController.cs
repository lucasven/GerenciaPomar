using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaPomar.Core.Models;
using GerenciaPomar.Service;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaPomar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoArvoreController : CrudController<GrupoArvore>
    {
        private readonly IGrupoArvoreService service;

        public GrupoArvoreController(IGenericService<GrupoArvore> baseService, IGrupoArvoreService service) : base(baseService)
        {
            this.service = service;
        }

        [HttpPost]
        public override async Task<IActionResult> Salvar([FromBody] GrupoArvore entidade)
        {
            try
            {
                service.Salvar(entidade);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}