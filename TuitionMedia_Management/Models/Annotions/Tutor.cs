using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuitionMedia_Management.Models
{
    [MetadataType(typeof(TutorMetadata))]
    public partial class Tutor { }
    public partial class TutorMetadata
    {
        public int Tutorid { get; set; }
        [Required, StringLength(50)]
        public string Tutorname { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime JoinDate { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(500)]
        public string Picture { get; set; }
        public Nullable<bool> Available { get; set; }

    }
}