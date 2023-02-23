using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuitionMedia_Management.Models
{
    [MetadataType(typeof(Qualificationmetadata))]
    public partial class Qualification { }
    public partial class Qualificationmetadata
    {
        public int QualificationId { get; set; }
        [Required, StringLength(50, MinimumLength = 1)]    
        public string Degree { get; set; }
        [Required]
        public int PassingYear { get; set; }
        [Required, StringLength(30, MinimumLength = 1)]
        public string Result { get; set; }
        [Required, StringLength(50, MinimumLength = 1)]
        public string Institute { get; set; }
        [Required]
        public int Tutorid { get; set; }
    }
}