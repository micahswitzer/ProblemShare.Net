using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemShare.Web.Entities
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public Guid InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User Author { get; set; }
        public Guid? FileId { get; set; }
        [ForeignKey("FileId")]
        public virtual File File { get; set; }
    }
}