using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITS.Controllers;
using Moq;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;
using ITS.Models;
using System.Web.Mvc;

namespace ITS.Tests.Controllers
{
    [TestClass]
    public class IssuesControllerTest
    {
        public void IndexTest()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            DateTime testTime = new DateTime(2016, 11, 20, 1, 30, 30);
            mock.Setup(m => m.Issues).Returns(new Issue[] {
                new Issue { Id = 1, Description = "First Issue", UserEmail = "ten@gmail.com", CreatedOn = testTime },
                new Issue { Id = 2, Description = "Second Issue", UserEmail = "tenx@gmail.com", CreatedOn = testTime },
                new Issue { Id = 3, Description = "Third Issue", UserEmail = "three@gmail.com", CreatedOn = testTime }
            });

            IssuesController controller = new IssuesController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
