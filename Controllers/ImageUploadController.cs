using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Image_upload_net_core.Controllers {
    
    [Route("api/[Controller]")]
    [ApiController]

    public class ImageUploadController: ControllerBase 
    {
        public static IWebHostEnvironment _environment;

        public ImageUploadController (IWebHostEnvironment env) {
            //inhit current location / context
            _environment = env;
        }

        [HttpPost]
        public async Task<string> Post([FromForm]FileUploadAPI formFile) {
            try {
                if(formFile.files.Length > 0) {
                    string directoryname = DateTime.UtcNow.ToString("yyyymmdd");
                    if(!Directory.Exists(directoryname + "/")) {
                        Directory.CreateDirectory(directoryname + "/");
                    }
                    using(FileStream fs = System.IO.File.Create(directoryname + "/" + formFile.files.FileName)) {
                        formFile.files.CopyTo(fs);
                        fs.Flush();
                        return directoryname + "/" + formFile.files.FileName;
                    }
                }else{
                    return "no file found";
                }
            }catch(Exception e) {
                return e.Message.ToString();
            }
        }

        [HttpGet]
        public File GetImage(string filename) {
            if(String.IsNullOrWhiteSpace(filename)) return null;
            
            return File(filename);
        }   

    }
}