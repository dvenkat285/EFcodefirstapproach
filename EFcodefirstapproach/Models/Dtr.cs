using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcodefirstapproach.Models
{
    public class Dtr
    {
        internal int mtid;

        [Key]
        public int MtId { get; set; }

        [Column("MtrName",TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set;}

        [Column("PowerStatus", TypeName = "varchar(20)")]
        [Required]
        public string Status { get; set;}
        [Required]
        public int? current {  get; set; }
        [Required]
        public int? voltage { get; set; }



    }
}
