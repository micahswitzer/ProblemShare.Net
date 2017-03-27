using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemShare.Web.Entities
{
    public class Institution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InstitutionId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Owner { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<File> Files { get; set; }
    }
}