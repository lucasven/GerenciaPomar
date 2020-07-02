using GerenciaPomar.Core.Models;
using GerenciaPomar.Repository;
using GerenciaPomar.Service;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GerenciaPomar.Tests.Service
{
    public class GenericServiceTest
    {
        [Fact]
        public async void BuscarPorCondicaoSucesso()
        {
            //arrange
            var mocker = new AutoMocker();

            var especieGenericService = mocker.CreateInstance<GenericService<Especie>>();

            Expression<Func<Especie, bool>> funcao = c => c.Codigo == Guid.Empty;
            
            IList<Especie> returned = new List<Especie>();

            mocker.GetMock<IRepositorioBase<Especie>>()
                .Setup(c => c.BuscarPorCondicao(funcao))
                .Returns(Task.FromResult(returned));

            //act
            var resultado = await especieGenericService.BuscarPorCondicao(funcao);

            //assert
            Assert.IsType<List<Especie>>(resultado);
        }

        [Fact]
        public async void BuscarTodosSucesso()
        {
            //arrange
            var mocker = new AutoMocker();

            var especieGenericService = mocker.CreateInstance<GenericService<Especie>>();

            IList<Especie> returned = new List<Especie>();

            mocker.GetMock<IRepositorioBase<Especie>>()
                .Setup(c => c.BuscarTodos())
                .Returns(Task.FromResult(returned));

            //act
            var resultado = await especieGenericService.BuscarTodos();

            //assert
            Assert.IsType<List<Especie>>(resultado);
        }

        [Fact]
        public async void BuscarTodosPaginadoSucesso()
        {
            //arrange
            var mocker = new AutoMocker();

            var especieGenericService = mocker.CreateInstance<GenericService<Especie>>();

            IList<Especie> returned = new List<Especie>();
            int pagina = 1, total = 10;

            mocker.GetMock<IRepositorioBase<Especie>>()
                .Setup(c => c.BuscarTodos(pagina, total))
                .Returns(Task.FromResult(returned));

            //act
            var resultado = await especieGenericService.BuscarTodos(pagina, total);

            //assert
            Assert.IsType<List<Especie>>(resultado);
        }
    }
}
