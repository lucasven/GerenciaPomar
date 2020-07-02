using GerenciaPomar.API.Controllers;
using GerenciaPomar.Core.Models;
using GerenciaPomar.Service;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GerenciaPomar.Tests.API
{
    public class GrupoArvoreTest
    {
        [Fact]
        public async void SalvarSucesso()
        {
            //arrange
            var entidade = new GrupoArvore();
            var mocker = new AutoMocker();

            var grupoArvoreController = mocker.CreateInstance<GrupoArvoreController>();

            //act
            var resultado = await grupoArvoreController.Salvar(entidade);

            //assert
            Assert.IsType<OkResult>(resultado);
        }
    }
}
