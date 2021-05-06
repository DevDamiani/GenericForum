using GenericForum.Logic.Services;
using GenericForum.Model.Interfaces.Repositories;
using Xunit;
using Moq;
using AutoMapper;
using GenericForum.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using GenericForum.Model.Request;

namespace GenericForum.Domain.Services.Test
{

    
    public class ClientServiceHandlerTests
    {

        [Theory]
        [InlineData("Bacana")]
        [InlineData("Queijo")]
        [InlineData("amigo")]
        public void UserNameIsTakenTest(string name)
        {
            //Arrage
            var mockRepo = new Mock<IClientRepository>();
            mockRepo
                .Setup(r => r.GetByUserName(It.IsAny<string>()))
                .Returns(ListClient().FirstOrDefault(c => c.UserName == name));

            var mockMapper = new Mock<IMapper>();

            var service = new ClientServiceHandler(mockRepo.Object, mockMapper.Object);

            var test = new ClientUserNameRequest() { UserName = name };

            var expect = ListClient().FirstOrDefault(c => c.UserName == name) == null ? false : true ;

            //act
            var result = service.UserNameIsTaken(test);

            //assert
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
