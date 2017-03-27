using System;
using System.Collections.Generic;

namespace ProblemShare.Web.Interface
{
    /// <summary>
    /// Describes the base methods of any business object
    /// </summary>
    /// <typeparam name="TViewModel">The view model type associated with the particular business object</typeparam>
    public interface IBusinessObject<TViewModel>
    {
        void Add(TViewModel item, Guid institutionId);
        bool Save(TViewModel item, Guid institutionId);
        TViewModel Get(Guid id, Guid institutionId);
        ICollection<TViewModel> GetAll(Guid institutionId);
        bool Delete(Guid id, Guid institutionId);
    }
}