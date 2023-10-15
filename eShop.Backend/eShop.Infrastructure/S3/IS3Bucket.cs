using eShop.Models.DTO;

namespace eShop.Infrastructure.S3
{
    public interface IS3Bucket
    {
        Task<(Stream, string)> GetFileAsync(string fileName);
        Task<UploadedFileDTO> UploadFileAsync(Stream fileStream, string fileName);
    }
}