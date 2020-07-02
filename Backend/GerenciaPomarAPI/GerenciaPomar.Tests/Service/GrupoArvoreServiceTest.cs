using GerenciaPomar.Core.Models;
using GerenciaPomar.Repository;
using GerenciaPomar.Service;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GerenciaPomar.Tests.Service
{
    public class GrupoArvoreServiceTest
    {
        [Fact]
        public async void SalvarSucesso()
        {
            //arrange
            var entidade = new GrupoArvore()
            {
                Arvores = new List<Arvore>()
            };

            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            entidade.Arvores.Add(new Arvore() { Codigo = guid1 });
            entidade.Arvores.Add(new Arvore() { Codigo = guid2 });

            var mocker = new AutoMocker();

            var grupoArvoreService = mocker.CreateInstance<GrupoArvoreService>();

            IList<Arvore> returned = new List<Arvore>();
            returned.Add(new Arvore() { Codigo = Guid.NewGuid() });
            returned.Add(new Arvore() { Codigo = Guid.NewGuid() });

            mocker.GetMock<IRepositorioBase<Arvore>>()
                .Setup(c => c.BuscarPorCondicao(c => c.GrupoArvoreCodigo == entidade.Codigo))
                .Returns(Task.FromResult(returned));

            mocker.GetMock<IRepositorioBase<Arvore>>()
                .Setup(c => c.BuscarPorCondicao(c => c.Codigo == guid1))
                .Returns(Task.FromResult(returned));

            mocker.GetMock<IRepositorioBase<Arvore>>()
                .Setup(c => c.BuscarPorCondicao(c => c.Codigo == guid2))
                .Returns(Task.FromResult(returned));

            //act
            grupoArvoreService.Salvar(entidade);

            //assert
            mocker.GetMock<IRepositorioBase<GrupoArvore>>().Verify(r => r.Salvar(entidade), Times.Once);
        }
    }
}
