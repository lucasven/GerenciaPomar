using GerenciaPomar.API.Controllers;
using GerenciaPomar.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GerenciaPomar.Tests.API
{
    public class CrudTest
    {
        [Fact]
        public async void SalvarSucesso()
        {
            //arrange
            var entidade = new Especie();
            var mocker = new AutoMocker();

            var crudEspecieController = mocker.CreateInstance<CrudController<Especie>>();

            //act
            var resultado = await crudEspecieController.Salvar(entidade);

            //assert
            Assert.IsType<OkResult>(resultado);
        }

        [Fact]
        public async void ListarSucesso()
        {
            //arrange
            var entidade = new Especie();
            var mocker = new AutoMocker();

            var crudEspecieController = mocker.CreateInstance<CrudController<Especie>>();

            //act
            var resultado = await crudEspecieController.Listar(1, 10);

            //assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async void ExcluirSucesso()
        {
            //arrange
            var entidade = new Especie();
            var mocker = new AutoMocker();

            var crudEspecieController = mocker.CreateInstance<CrudController<Especie>>();

            //act
            var resultado = await crudEspecieController.Excluir(entidade.Codigo);

            //assert
            Assert.IsType<OkResult>(resultado);
        }
    }
}
