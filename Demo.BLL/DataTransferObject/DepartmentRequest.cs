using System.ComponentModel.DataAnnotations;

namespace Demo.BLL.DataTransferObject
{
    public class DepartmentRequest
    {
        [Required(ErrorMessage ="Name Is Required!!")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
