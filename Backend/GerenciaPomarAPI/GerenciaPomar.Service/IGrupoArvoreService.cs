using GerenciaPomar.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Service
{
    public interface IGrupoArvoreService
    {
        void Salvar(GrupoArvore grupoArvore);
    }
}
