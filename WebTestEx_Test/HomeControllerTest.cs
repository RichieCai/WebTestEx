using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebTestEx.Context;
using WebTestEx.Controllers;
using WebTestEx.Interface;
using WebTestEx.Models.Data;

namespace WebTestEx_Test
{
    public class HomeControllerTest
    {
        private readonly Mock<ILogger<HomeController>> _loggerMock;
        //private readonly Mock<ILoggerFactory> _loggerFactory;
        private readonly Mock<dbCustomDbSampleContext> _dbMock;
        private readonly Mock<IHomeService> _homeServiceMock;
        public HomeControllerTest()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _dbMock= new Mock<dbCustomDbSampleContext>();
            _homeServiceMock = new Mock<IHomeService>();
        }
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new HomeController(_loggerMock.Object,_dbMock.Object,_homeServiceMock.Object);

            // Act
            var result = controller.Index() ;

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Student_ReturnsViewResultWithModel()
        {
            // Arrange
            var controller = new HomeController(_loggerMock.Object, _dbMock.Object, _homeServiceMock.Object);
            _homeServiceMock.Setup(x => x.Student()).ReturnsAsync(new List<Student>() );

            // Act
            var result = await controller.Student();

            // Assert
            var viewResult=Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);
            Assert.IsType<List<Student>>(viewResult.Model);
        }
    }
}