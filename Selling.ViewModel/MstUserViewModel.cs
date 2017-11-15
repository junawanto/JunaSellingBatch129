using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.ViewModel
{
    public class MstUserViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column(TypeName = "Int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Password { get; set; }

        [Column(TypeName = "Bit")]
        public bool Active { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string officerCode { get; set; }

        public string officerName{ get; set; }
    }
}
