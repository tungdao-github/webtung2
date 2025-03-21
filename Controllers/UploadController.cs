using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication4.Models; // Import model

[Route("api/upload")]
[ApiController]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    // 📌 API UPLOAD CHUNG
    [HttpPost("file")]
    [Consumes("multipart/form-data")] // ⚠️ Quan trọng để Swagger hiểu request
    public IActionResult UploadFile([FromForm] UploadFileModel model)
    {
        if (model.File == null || model.File.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var filePath = Path.Combine(_environment.WebRootPath, "uploads", model.File.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            model.File.CopyTo(stream);
        }

        return Ok(new { Message = "File uploaded successfully!", FileName = model.File.FileName });
    }

    // 📌 API UPLOAD AVATAR
    [HttpPost("avatar")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadAvatar([FromForm] UploadFileModel model)
    {
        if (model.File == null || model.File.Length == 0)
        {
            return BadRequest(new { message = "Vui lòng chọn file hợp lệ." });
        }

        // Kiểm tra định dạng ảnh hợp lệ (JPG, PNG, JPEG)
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(model.File.FileName).ToLower();

        if (!allowedExtensions.Contains(fileExtension))
        {
            return BadRequest(new { message = "Chỉ chấp nhận file JPG, JPEG, PNG." });
        }

        string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        string fileName = Guid.NewGuid().ToString() + fileExtension;
        string filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.File.CopyToAsync(stream);
        }

        string fileUrl = $"/uploads/{fileName}";
        return Ok(new { url = fileUrl });
    }
}
