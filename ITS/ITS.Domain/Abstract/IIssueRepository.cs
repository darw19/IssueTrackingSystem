using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IIssueRepository
    {

        IEnumerable<Issue> Issues { get; }
        void SaveIssue(Issue issue);

        //Issue DeleteProduct(int productID);
    }
}