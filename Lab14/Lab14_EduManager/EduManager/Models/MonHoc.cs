using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduManager.Models
{
    /// <summary>
    /// Entity ung voi bang MONHOC trong co so du lieu EduManagerDB.
    /// </summary>
    [Table("MONHOC")]
    public class MonHoc
    {
        /// <summary>Ma mon hoc (khoa chinh), vi du: COMP1019.</summary>
        [Key]
        [MaxLength(10)]
        public string MaMonHoc { get; set; } = string.Empty;

        /// <summary>Ten mon hoc, vi du: Lap trinh tren Windows.</summary>
        [Required]
        [MaxLength(100)]
        public string TenMonHoc { get; set; } = string.Empty;

        /// <summary>So tin chi, hop le trong khoang 1 den 6.</summary>
        public int SoTinChi { get; set; } = 1;

        /// <summary>True: con su dung; False: ngung su dung.</summary>
        public bool TrangThai { get; set; } = true;
    }
}
