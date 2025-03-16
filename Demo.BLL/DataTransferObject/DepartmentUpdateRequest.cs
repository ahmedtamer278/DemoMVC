
namespace Demo.BLL.DataTransferObject
{
    public class DepartmentUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
