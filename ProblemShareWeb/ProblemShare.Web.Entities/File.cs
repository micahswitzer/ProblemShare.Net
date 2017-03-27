using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemShare.Web.Entities
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User Owner { get; set; }
        public Guid InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }
    }
}
