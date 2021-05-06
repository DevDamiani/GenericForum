using GenericForum.Logic.Services;
using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Helpers;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Request;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericForum.Domain.Services.Test
{
    public class AuthServiceHandlerTests
    {
        [Theory]
        [InlineData("Usuario" , "Vamos2021 Agora!")]
        [InlineData("te", "123")]
        [InlineData("Usuario", "Vamos2021")]
        [InlineData("mascara", "123 456 789 mascara")]
        public void AuthClient_IfIsValidReturnTokenElseNull(string user, string password)
        {
            //arrage
            var mockRepo = new Mock<IClientRepository>();
            mockRepo
                .Setup(r => r.ValidClient(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ListClient().FirstOrDefault(c => c.UserName == user && c.Password == password));

            var mockToken = new Mock<ITokenHelper>();
            mockToken.Setup(t => t.GenerateToken(It.IsAny<ClientEntity>())).Returns($"{user + password}");

            var service = new AuthServiceHandler(mockRepo.Object, mockToken.Object);

            var expectClient = ListClient().FirstOrDefault(c => c.UserName == user && c.Password == password);
            var expect = expectClient != null ? $"{expectClient.UserName + expectClient.Password}" : null;

            //act
            var result = service.AuthClient(new ClientLoginRequest() { UserName = user, Password = password });

            //assert
            mockRepo.Verify(r => r.ValidClient(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            if(expectClient != null) mockToken.Verify(r => r.GenerateToken(It.IsAny<ClientEntity>()), Times.Once);
            Assert.Equal(expect, result);

        }



        private List<ClientEntity> ListClient()
        {
            return new List<ClientEntity>() 
            {
                new ClientEntity() { UserName = "Usuario", Password = "Vamos2021 Agora!" },
                new ClientEntity() { UserName = "Queijo", Password = "numeros1234" },
                new ClientEntity() { UserName = "Caneca", Password = "123vamos2000" },
                new ClientEntity() { UserName = "mascara", Password = "123 456 789 mascara" },

            };
        }
    }
}
