using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Interface
{
    /// <summary>
    /// The base interface for any collection-oriented business object
    /// </summary>
    /// <typeparam name="TCollectionItem">The type representing the collection item's view model</typeparam>
    /// <typeparam name="TParent">NOT USED: The parent view model</typeparam>
    public interface ICollectionBO<TCollectionItem, TParent>
    {
        void AddToCollection(TCollectionItem item, Guid parentId, Guid institutionId);
        bool UpdateItem(TCollectionItem item, Guid institutionId);
        bool RemoveItem(Guid itemId, Guid institutionId);
        TCollectionItem GetItem(Guid itemId, Guid institutionId);
        ICollection<TCollectionItem> GetAllForParent(Guid parentId, Guid institutionId);
    }
}