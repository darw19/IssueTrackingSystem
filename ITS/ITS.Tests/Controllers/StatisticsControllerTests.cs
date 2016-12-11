using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS.Domain.Abstract;
using ITS.Domain.Entities;
using ITS.Controllers;
using ITS.Models;
using Moq;

namespace ITS.Tests.Controllers
{
    [TestClass]    
    public class StatisticsControllerTests
    {
        [TestMethod]
        public void TestStatistics()
        {
            //Arrange
            Mock<IIssueRepository> issuesMock = new Mock<IIssueRepository>();
            issuesMock.Setup(x => x.Issues).Returns(new[]
            {
                new Issue() { Id = 1, Description = "First Issue Desc", Title = "First Issue Title" },
                new Issue() { Id = 2, Description = "Second Issue Desc", Title = "Second Issue Title"}
            });

            Mock<IUserRepository> usersMock = new Mock<IUserRepository>();
            usersMock.Setup(x => x.Users).Returns(new[]
            {
                new ApplicationUser() { Name = "First UserName" },
                new ApplicationUser() { Name = "Second UserName" }
            });

            StatisticsController controller = new StatisticsController(issuesMock.Object, usersMock.Object);

            //Act
            var statResult = controller.Statistics();

            //Assert
            for (int i = 0; i < issuesMock.Object.Issues.Count(); ++i)
            {
                var expectedObj = issuesMock.Object.Issues.ElementAt(i);
                var resultObj = (statResult.Model as IssuesViewModel).Issues.ElementAt(i);

                Assert.AreEqual(expectedObj.Id, resultObj.Id);
                Assert.AreEqual(expectedObj.Title, resultObj.Title);
                Assert.AreEqual(expectedObj.Description, resultObj.Description);
            }

            for (int i = 0; i < usersMock.Object.Users.Count(); ++i)
            {
                var expectedObj = usersMock.Object.Users.ElementAt(i);
                var resultObj = (statResult.Model as IssuesViewModel).Users.ElementAt(i);
                Assert.AreEqual(expectedObj.Name, resultObj.Name);
            }
        }
    }
}
