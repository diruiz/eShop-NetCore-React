using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using eShop.Models.DTO;
using Microsoft.Extensions.Configuration;

namespace eShop.Infrastructure.S3;

public class S3Bucket : IS3Bucket
{
    private readonly string bucketName;
    private readonly string region;
    private readonly IAmazonS3 _s3Client;
    private readonly IConfiguration configuration;
    public S3Bucket(IAmazonS3 s3Client, IConfiguration config)
    {
        _s3Client = s3Client;
        configuration = config;
        bucketName = configuration["AWS:BucketName"];
        region = configuration["AWS:Region"];
    }
    public async Task<(Stream, string)> GetFileAsync(string fileName)
    {

        var response = await _s3Client.GetObjectAsync(bucketName, fileName);

        using var reader = new StreamReader(response.ResponseStream);
        var fileContent = await reader.ReadToEndAsync();

        return (response.ResponseStream, response.Headers.ContentType);
    }

    public async Task<UploadedFileDTO> UploadFileAsync(Stream fileStream, string fileName)
    {
        var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
        if (!bucketExists)
        {
            var bucketRequest = new PutBucketRequest()
            {
                BucketName = bucketName,
                UseClientRegion = true,
            };
            await _s3Client.PutBucketAsync(bucketRequest);
        }

        string keyName = $"{DateTime.UtcNow:yyyy-MM-dd-hhmmss}-{fileName}";

        var objectRequest = new PutObjectRequest()
        {
            BucketName = bucketName,
            Key = keyName,
            InputStream = fileStream,
            StorageClass = S3StorageClass.Standard
        };

        var s3Response = await _s3Client.PutObjectAsync(objectRequest);

        return new UploadedFileDTO()
        {
            FileName = keyName,
            FileUrl = $"https://{bucketName}.s3.{region}.amazonaws.com/{keyName}"
        }; 
    }
}
