using System;
using System.Collections.Generic;

namespace ProblemShare.Web.Interface
{
    /// <summary>
    /// Describes the base methods of any business object
    /// </summary>
    /// <typeparam name="ViewModelType">The view model type associated with the particuar business object</typeparam>
    public interface IBusinessObject<ViewModelType>
    {
        void Add(ViewModelType item, Guid institutionId);
        bool Save(ViewModelType item, Guid institutionId);
        ViewModelType Get(Guid id, Guid institutionId);
        ICollection<ViewModelType> GetAll(Guid institutionId);
        bool Delete(Guid id, Guid institutionId);
    }
}