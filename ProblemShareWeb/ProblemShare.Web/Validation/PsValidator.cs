using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProblemShare.Web.Validation
{
    public class PsEmailAddressAttribute : DataTypeAttribute
    {
        private readonly EmailAddressAttribute _validator = new EmailAddressAttribute();

        public PsEmailAddressAttribute() : base(DataType.EmailAddress)
        {
            this.ErrorMessage = "Not valid, please fix";
        }

        public override bool IsValid(object value)
        {
            return _validator.IsValid(value);
        }
    }
}