using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface ICommentRepository
    {

        IEnumerable<Comment> Comments { get; }

        //void SaveProduct(Issue product);

        //Issue DeleteProduct(int productID);
    }
}