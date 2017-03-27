using ProblemShare.Web.Entities;

namespace ProblemShare.Web.Business
{
    public abstract class BO
    {
        internal PSContext Context => new PSContext("ProblemShareDB");
    }
}