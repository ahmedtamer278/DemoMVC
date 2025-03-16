namespace Demo.BLL.DataTransferObject
{
    public class DepartmentRequest
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
