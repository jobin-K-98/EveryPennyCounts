using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPennyCountsLibrary.Models
{
    public class User //not implemented yet
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Password { get; set; } //yeah its a plain text password, we both know this is never going to get implemented

    }
}
