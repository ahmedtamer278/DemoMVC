namespace Demo.BLL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        private List<string> _allowedExtensions = [".png",".jpeg"];
        private const int MaxSize = 2_097_152;
        public string? UPload(IFormFile file, string foldername)
        {
            var extensions = Path.GetExtension(file.FileName);
            if (!_allowedExtensions.Contains(extensions)) return null;

            if (file.Length > MaxSize) return null;

            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", foldername);
            var filename =$"{Guid.NewGuid()}{extensions}";
            var filepath = Path.Combine(folderpath, filename);
            using var stream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(stream);
            return filename;
            
        }

        public bool Delete(string fileName)
        {
            if (!File.Exists(fileName)) return false;
            File.Delete(fileName); 
            return true;
        }
    }
}
