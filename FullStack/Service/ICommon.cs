using FullStack.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FullStack.Services
{
    public interface ICommon
    {
        string UploadedFile(IFormFile ProfilePicture);
        Tuple<byte[], string> GetDownloadDetails(Int64 id);
        Task<AttachmentFile> AddAttachmentFile(IFormFile _IFormFile);
    }
}
