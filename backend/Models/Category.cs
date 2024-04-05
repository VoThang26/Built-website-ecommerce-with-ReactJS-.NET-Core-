using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vohoangthang.Exercise02.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid? parent_id { get; set; }
        public string category_name { get; set; }
        public string? category_description { get; set; }
        public string? icon { get; set; }
        public string? image { get; set; }
        public string? placeholder { get; set; }
        public bool active { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        public virtual ICollection<Category> InverseParent { get; } = new List<Category>();
        public virtual Category? Parent { get; set; }
        public virtual Staff_Account CreatedBy { get; set; }
        public virtual Staff_Account UpdatedBy { get; set; }
    }
}
