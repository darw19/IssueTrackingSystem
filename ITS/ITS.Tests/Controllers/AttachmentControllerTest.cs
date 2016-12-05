using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;
using ITS.Models;
using ITS.Controllers;
using System.Linq;

namespace ITS.Tests.Controllers
{
    [TestClass]
    public class AttachmentControllerTest
    {
        [TestMethod]
        public void TestUploadFile()
        {
            //Arrange
            List<HttpPostedFileBase> postedFiles = new List<HttpPostedFileBase>();
            int testNumFiles = 4;

            List<MemoryStream> createdStreams = new List<MemoryStream>();
            List<Bitmap> createdBitmaps = new List<Bitmap>();

            List<byte[]> binaryPostedFiles = new List<byte[]>();

            for (int i = 1; i <= testNumFiles; ++i)
            {
                var stream = new MemoryStream();
                createdStreams.Add(stream);
                {
                    var bmp = new Bitmap(i, i);
                    createdBitmaps.Add(bmp);
                    {
                        var graphics = Graphics.FromImage(bmp);
                        graphics.FillRectangle(Brushes.Black, 0, 0, i, i);
                        bmp.Save(stream, ImageFormat.Jpeg);

                        var mockPostedFile = new Mock<HttpPostedFileBase>();
                        mockPostedFile.Setup(pf => pf.InputStream).Returns(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        binaryPostedFiles.Add(stream.ToArray());
                        postedFiles.Add(mockPostedFile.Object);
                    }
                }
            }

            Attachment newAttachment = new Attachment()
            {
                IssueId = 1002,
            };

            var avmMock = new Mock<AttachmentViewModel>();
            avmMock.Setup(x => x.Files).Returns(postedFiles);
            avmMock.Setup(x => x.Attachment).Returns(newAttachment);

            Mock<IAttachmentRepository> mock = new Mock<IAttachmentRepository>();
            AttachmentController controller = new AttachmentController(mock.Object);

            //Act
            controller.UploadFile(avmMock.Object);


            //Assert
            for (int i = 0; i < testNumFiles; ++i)
            {
                mock.Verify(m => m.AddAttachment(It.Is<Attachment>(at => at.IssueId == 1002 && at.BinaryData.SequenceEqual(binaryPostedFiles[i]))));
            }

            //Cleanup
            foreach (var x in createdStreams)
            {
                x.Dispose();
            }

            foreach(var x in createdBitmaps)
            {
                x.Dispose();
            }
        }

        [TestMethod]
        public void TestDeleteAttachment()
        {
            //Arrange
            var repositoryMock = new Mock<IAttachmentRepository>();

            var firstAttachment = new Attachment() {Id = 1, Name = "FIRST ATTACHMENT"};
            var secondAttachment = new Attachment() {Id = 2, Name = "SECOND ATTACHMENT"};
            var thirdAttachment = new Attachment() {Id = 3, Name = "THIRD ATTACHMENT"};

            repositoryMock.Setup(x => x.Attachments).Returns(
                new Attachment[] {
                    firstAttachment,
                    secondAttachment,
                    thirdAttachment
                });

            AttachmentController controller = new AttachmentController(repositoryMock.Object);

            //Act
            controller.DeleteAttachment(2);

            //Assert
            repositoryMock.Verify(x => x.RemoveAttachment(secondAttachment));
        }
    }
}
