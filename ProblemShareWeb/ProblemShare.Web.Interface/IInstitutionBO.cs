using System;

namespace ProblemShare.Web.Interface
{
    public interface IInstitutionBO
    {
        Guid Create(Guid ownerId, string name);
        bool Delete(Guid id); // Dangerous, don't use for now
        void UpdateName(Guid id, string name);
        string GetName(Guid id);
    }
}