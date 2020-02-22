using System;
using Microsoft.AspNetCore.Http;

namespace Image_upload_net_core
{
    public class FileUploadAPI
    {
        public IFormFile files { get; set; }
    }
}
