using FluentAssertions;
using Projeto.Presentation.Api.Tests.Contexts;
using Projeto.Presentation.Api.Tests.Factories;
using Projeto.Presentation.Api.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Presentation.Api.Tests.Scenarios
{
    public class LoginTest
    {
        private readonly TestContext testContext;
        private readonly string endpointUsuario;
        private readonly string endpointLogin;
        private readonly string errorAccessDenied;

        public LoginTest()
        {
            testContext = new TestContext();

            endpointUsuario = "/api/Usuario";
            endpointLogin = "/api/Login";

            errorAccessDenied = "Usuário não foi encontrado.";
        }

        [Fact]
        public async Task Login_Post_ReturnsOk()
        {
            #region Passo 1 -  Criar uma conta de usuário

            var usuario = UsuarioFactory.CreateUsuario;

            var requestCreate = ServicesUtil.CreateRequestContent(usuario);
            var responseCreate = await testContext.Client.PostAsync(endpointUsuario,requestCreate);

            responseCreate.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #region Passo 2 - Autenticar o usuário

            var auth = LoginFactory.CreateAuth(usuario.Login, usuario.Senha);

            var requestLogin = ServicesUtil.CreateRequestContent(auth);
            var responseLogin = await testContext.Client.PostAsync(endpointLogin, requestLogin);

            responseLogin.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

        }

        [Fact]
        public async Task Login_Post_ReturnsBadRequest()
        {
            var auth = LoginFactory.CreateAuth(string.Empty, string.Empty);

            var request = ServicesUtil.CreateRequestContent(auth);
            var response = await testContext.Client.PostAsync(endpointLogin, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Login_Post_ReturnsInternalServerError()
        {
            var auth = LoginFactory.CreateAuth("usertest", "test123");

            var request = ServicesUtil.CreateRequestContent(auth);
            var response = await testContext.Client.PostAsync(endpointLogin, request);

            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            var message = ServicesUtil.ReadResponseMessage(response);
            message.Should().Be(errorAccessDenied);
        }
    }
}
