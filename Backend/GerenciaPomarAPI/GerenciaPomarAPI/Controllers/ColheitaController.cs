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
    public class ColheitaController : CrudController<Colheita>
    {
        public ColheitaController(IGenericService<Colheita> service) : base(service)
        {

        }
    }
}