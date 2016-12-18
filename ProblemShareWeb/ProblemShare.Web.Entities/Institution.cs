﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Entities
{
    public class Institution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InstitutionId { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
