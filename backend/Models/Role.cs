using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace vohoangthang.Exercise02.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string? role_name { get; set; }
        public string? privileges { get; set; }
        public virtual ICollection<Staff_Account> Staff_Accounts { get; set; }

    }
}