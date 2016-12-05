using System;

namespace ProblemShare.Web.Interface
{
    /// <summary>
    /// Describes the base methods of any business object
    /// </summary>
    /// <typeparam name="ViewModelType">The view model type associated with the particuar business object</typeparam>
    public interface IBusinessObject<ViewModelType>
    {
        Guid Save(ViewModelType document, Guid institutionId);
        ViewModelType Load(Guid id);
        bool Delete(Guid id, Guid institutionId);
    }
}