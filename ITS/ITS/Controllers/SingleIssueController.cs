﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;
using ITS.Models;
using System.IO;

namespace ITS.Controllers
{
    public class SingleIssueController : Controller
    {
        private IIssueRepository m_Repository;
        public SingleIssueController(IIssueRepository repository)
        {
            this.m_Repository = repository;
        }

        private Issue getCurrentIssue(int? issueId)
        {
            //TODO: Used for debugging - remove 
            if (issueId != null)
            {
                return m_Repository.Issues.First(x => (x.Id == issueId));
            } else
            {
                throw new NullReferenceException("Attempt to create issue without ID");
            }
        }

        [HttpGet] 
        public ViewResult Issue(int? issueId)
        {
            return View(getCurrentIssue(issueId));
        }

        [HttpPost]
        public ActionResult Issue(Issue issue)
        {
            m_Repository.SaveIssue(issue);
            return RedirectToAction("Index", "Issues");
        }

        [HttpGet]
        public ViewResult AddComment(int? issueId)
        {
            Comment newComment = new Comment();
            newComment.IssueId = issueId;
            return View(newComment);
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel commentVM)
        {
            bool creatingNewComment = commentVM.Comment.Id == 0;
            Issue currentIssue = getCurrentIssue(commentVM.Comment.IssueId);
            CommentChange currentChange = new CommentChange()
            {
                UserEmail = commentVM.UserEmail,
                NewValue = commentVM.Comment.Text,
                TimeOfChange = System.DateTime.Now,
                TypeOfChange = creatingNewComment ? "CREATION" : "MODIFICATION",
            };

            //If this is a new comment
            if (creatingNewComment)
            {
                currentChange.Comment = commentVM.Comment;
                commentVM.Comment.CommentChanges.Add(currentChange);
                currentIssue.Comments.Add(commentVM.Comment);
            }
            else 
            {
                Comment commentToUpdate = currentIssue.Comments.First(x => x.Id == commentVM.Comment.Id);
                currentChange.Comment = commentToUpdate;
                currentChange.CommentId = commentToUpdate.Id;
                commentToUpdate.CommentChanges.Add(currentChange);
                commentToUpdate.Text = commentVM.Comment.Text;
            }
            m_Repository.SaveIssue(currentIssue);
            return RedirectToAction("Issue", "SingleIssue", new { issueId = commentVM.Comment.IssueId });
        }

        [HttpGet]
        public ViewResult UploadFile()
        {
            //AttachmentViewModel avm = new AttachmentViewModel();
            //avm.Attachment.IssueId = issueId;
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(AttachmentViewModel attachment)
        {
            //newAttachment.BinaryData
            Issue currentIssue = getCurrentIssue(attachment.Attachment.IssueId);

            if (ModelState.IsValid)
            {
               

                foreach (var file in attachment.Files)
                {
                    Attachment newAttachment = new Attachment();
                    newAttachment.IssueId = attachment.Attachment.IssueId;
                    newAttachment.Name = file.FileName;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        file.InputStream.CopyTo(memoryStream);
                        newAttachment.BinaryData = memoryStream.ToArray();
                    }
                    currentIssue.Attachments.Add(newAttachment);
                }
                               
            }
            m_Repository.SaveIssue(currentIssue);         
            return RedirectToAction("Issue", "SingleIssue", new { attachment.Attachment.IssueId });
        }

        [HttpGet]
        public ActionResult DownloadFile(int ?currentIssueId, int ?fileId)
        {
            if (fileId != null && currentIssueId != null)
            {
                Attachment fileToDownload = getCurrentIssue(currentIssueId).Attachments.First(x => x.Id == fileId);
                return File(fileToDownload.BinaryData, System.Net.Mime.MediaTypeNames.Application.Octet, fileToDownload.Name);
            } else
            {
                throw new NullReferenceException("Attempt to download invalid file");
            }
        }
    }
}