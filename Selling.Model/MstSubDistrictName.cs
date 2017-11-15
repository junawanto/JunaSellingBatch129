using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selling.Model
{
    public class MstSubDistrictName : SellingData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required]
        [Key]
        [Column(TypeName = "Int")]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        public int CityID { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string SubDistrictName { get; set; }

        [Required]
        [Column(TypeName = "Bit")]
        public bool Active { get; set; }
    }
}
