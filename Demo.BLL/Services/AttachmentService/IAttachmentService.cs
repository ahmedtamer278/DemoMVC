namespace Demo.BLL.Services.AttachmentService
{
    public interface IAttachmentService
    {
        string? UPload(IFormFile file, string foldername);
        bool Delete(string fileName);
    }
}
