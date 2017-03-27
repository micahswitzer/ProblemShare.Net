using System;

namespace ProblemShare.Web.Models
{
    public class FileViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid OwnerId { get; set; }
    }
}