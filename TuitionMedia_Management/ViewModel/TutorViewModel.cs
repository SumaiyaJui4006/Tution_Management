using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuitionMedia_Management.ViewModel
{
    public class TutorViewModel
    {
        public int Tutorid { get; set; }
        [Required, StringLength(50)]
        public string Tutorname { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required]
        public HttpPostedFileBase Picture { get; set; }
        public bool Available { get; set; }
    }
            
}