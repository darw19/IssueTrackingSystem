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
    public class SingleIssueControllerTest
    {
        [TestMethod]
        public void IssueNotNullParameterGet()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            DateTime testTime = new DateTime(2016, 11, 20, 1, 30, 30);
            mock.Setup(m => m.Issues).Returns(new Issue[] {
                new Issue { Id = 1, Description = "First Issue", UserEmail = "ten@gmail.com", CreatedOn = testTime },
                new Issue { Id = 2, Description = "Second Issue", UserEmail = "tenx@gmail.com", CreatedOn = testTime },
                new Issue { Id = 3, Description = "Third Issue", UserEmail = "three@gmail.com", CreatedOn = testTime }
            });

            SingleIssueController controller = new SingleIssueController(mock.Object);

            //Act
            Issue resultIssue = controller.Issue(1).Model as Issue;

            //Assert
            Assert.AreEqual(1, resultIssue.Id);
            Assert.AreEqual("First Issue", resultIssue.Description);
            Assert.AreEqual("ten@gmail.com", resultIssue.UserEmail);
            Assert.AreEqual(testTime, resultIssue.CreatedOn);            
        }

        [TestMethod]
        public void IssueNullParameterGet()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            mock.Setup(m => m.Issues).Returns(new Issue[] {  });
            SingleIssueController controller = new SingleIssueController(mock.Object);

            //Act
            NullReferenceException expectedExc = null;
            try
            {
                Issue result = controller.Issue((int?)null).Model as Issue;
            } catch (NullReferenceException exc)
            {
                expectedExc = exc;
            }

            Assert.IsNotNull(expectedExc);
            Assert.AreEqual("Attempt to create issue without ID", expectedExc.Message);
        }

        [TestMethod]
        public void IssueNotNullParameterPost()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            SingleIssueController controller = new SingleIssueController(mock.Object);
            DateTime testDate = new DateTime(2016, 11, 20, 6, 55, 2);
            Issue testIssue = new Issue()
            { 
                Id = 1,
                CreatedOn = testDate,
                Title = "TestTitle",
                UserEmail = "TestEmail@email.com",
                Description = "TestDescription", 
                Comments = new Comment[] 
                { 
                    new Comment() { Id = 1, IssueId = 1, Text = "FirstTestComment" },
                    new Comment() { Id = 2, IssueId = 1, Text = "SecondTestComment" } 
                } 
            };

            //Act
            ActionResult result = controller.Issue(testIssue);

            //Assert
            mock.Verify(m => m.SaveIssue(testIssue));
            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void AddCommentGet()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            SingleIssueController controller = new SingleIssueController(mock.Object);
            mock.Setup(m => m.Issues).Returns(new Issue[] {
                new Issue { Id = 1, Description = "First Issue", UserEmail = "ten@gmail.com" },
                new Issue { Id = 2, Description = "Second Issue", UserEmail = "tenx@gmail.com" },
                new Issue { Id = 3, Description = "Third Issue", UserEmail = "three@gmail.com" }
            });

            //Act
            Comment result = controller.AddComment(2).Model as Comment;
 
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.IssueId);
        }

        [TestMethod]
        public void AddCommentPostCreatingNew()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            SingleIssueController controller = new SingleIssueController(mock.Object);
            var testIssues = new Issue[] {
                new Issue { Id = 1, Description = "First Issue", UserEmail = "ten@gmail.com", Title = "First Issue" },
                new Issue { Id = 2, Description = "Second Issue", UserEmail = "tenx@gmail.com", Title = "Second Issue" },
                new Issue { Id = 3, Description = "Third Issue", UserEmail = "three@gmail.com", Title = "Third Issue" }
            };
            mock.Setup(m => m.Issues).Returns(testIssues);
            CommentViewModel testVm = new CommentViewModel()
            {
                UserEmail = "ten@gmail.com",
                Comment = new Comment()
                {
                    Id = 0,
                    IssueId = 2,
                    Text = "This is a test comment"
                }
            };

            //Act
            controller.AddComment(testVm);

            //Assert
            mock.Verify(x => x.SaveIssue(It.Is<Issue>(i => i.Title == testIssues[1].Title && i.Description == testIssues[1].Description
                && i.Id == 2 && i.Comments.First(y => y.Text == "This is a test comment").IssueId == 2
                && i.Comments.First(y => y.Text == "This is a test comment").CommentChanges.ElementAt(0).TypeOfChange == "CREATION"
                && i.Comments.First(y => y.Text == "This is a test comment").CommentChanges.ElementAt(0).Comment 
                == i.Comments.First(y => y.Text == "This is a test comment"))));
        }

        [TestMethod]
        public void IssueAddNew()
        {
            //Arrange
            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();

            SingleIssueController controller = new SingleIssueController(mock.Object);
            Issue newIssue = new Issue() { Description = "TEST_DESC", Title = "TEST_TITLE", UserEmail = "tenx@gmail.com" };

            //Act
            controller.Issue(newIssue);

            //Assert
            mock.Verify(x => x.SaveIssue(It.Is<Issue>(i => i.Description == newIssue.Description && i.Title == newIssue.Title
                                        && i.UserEmail == newIssue.UserEmail)));

        }

        [TestMethod]
        public void TestLogWork()
        {
            //Arrange
            WorkLog wlItem = new WorkLog()
            {
                IssueId = 2,
                MillisecondsLogged = 1,
                TimeOfLogging = new System.DateTime(2016, 11, 11, 11, 11, 0),
                UserId = "test_user_id"
            };

            Mock<IIssueRepository> mock = new Mock<IIssueRepository>();
            SingleIssueController controller = new SingleIssueController(mock.Object);
            var testIssues = new Issue[] {
                new Issue { Id = 1, Description = "First Issue", UserEmail = "ten@gmail.com", Title = "First Issue", WorkLogs = new List<WorkLog>() },
                new Issue { Id = 2, Description = "Second Issue", UserEmail = "tenx@gmail.com", Title = "Second Issue", WorkLogs = new List<WorkLog>() },
                new Issue { Id = 3, Description = "Third Issue", UserEmail = "three@gmail.com", Title = "Third Issue", WorkLogs = new List<WorkLog>() }
            };
            mock.Setup(m => m.Issues).Returns(testIssues);

            //Act
            controller.LogWork(wlItem);

            //Assert
            mock.Verify(x => x.SaveIssue(It.Is<Issue>( i => i.Title == testIssues[1].Title && i.Description == testIssues[1].Description
                            && i.UserEmail == testIssues[1].UserEmail && i.Id == 2
                            && i.WorkLogs.ElementAt(0).IssueId == 2 && i.WorkLogs.ElementAt(0).MillisecondsLogged == 3600000
                            && i.WorkLogs.ElementAt(0).TimeOfLogging == wlItem.TimeOfLogging
                            && i.WorkLogs.ElementAt(0).UserId == wlItem.UserId)));

        }
    }
}
