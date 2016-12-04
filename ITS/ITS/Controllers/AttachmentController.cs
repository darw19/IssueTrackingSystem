using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Domain.Abstract;
using ITS.Domain.Entities;
using ITS.Models;
using System.IO;

namespace ITS.Controllers
{
    public class AttachmentController : Controller
    {
        private IAttachmentRepository m_Repository;
        public AttachmentController(IAttachmentRepository repository)
        {
            this.m_Repository = repository;
        }

        private Attachment getAttachmentById(int attachmentId)
        {
            return m_Repository.Attachments.First(x => x.Id == attachmentId);
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(AttachmentViewModel attachment)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in attachment.Files)
                {
                    if (file != null)
                    {
                        Attachment newAttachment = new Attachment();
                        newAttachment.IssueId = attachment.Attachment.IssueId;
                        newAttachment.Name = file.FileName;
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            file.InputStream.CopyTo(memoryStream);
                            newAttachment.BinaryData = memoryStream.ToArray();
                        }
                        m_Repository.AddAttachment(newAttachment);
                    }
                    else
                    {
                        //TODO: Handle null files 
                    }
                }
            }
            return RedirectToAction("Issue", "SingleIssue", new { attachment.Attachment.IssueId });
        }

        public ActionResult DeleteAttachment(int attachmentId)
        {
            Attachment requestedAttachment = getAttachmentById(attachmentId);
            int issueId = requestedAttachment.IssueId ?? 0;
            //TODO: Checks if attachment exists
            m_Repository.RemoveAttachment(requestedAttachment);
            return RedirectToAction("Issue", "SingleIssue", new { issueId = issueId });
        }
    }
}