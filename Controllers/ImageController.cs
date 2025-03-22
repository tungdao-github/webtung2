using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WebApplication2.Contexts;
using WebApplication2.Middleware;
using WebApplication2.Models;
[Route("api/images")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly SinhVienDbContext _context;

    public ImagesController(SinhVienDbContext context)
    {
        _context = context;
    }

    //[HttpGet("get-images")]
    //public IActionResult GetImages()
    //{
    //    var images = _context.Images
    //        .Select(i => new { i.Id, i.ImageUrl, i.Description })
    //        .ToList();

    //    return Ok(images);
    //}
    [HttpPost("add-image")]
    public IActionResult AddImage([FromBody] ImageModel image)
    {
        _context.Images.Add(image);
        _context.SaveChanges();
        return Ok(new { message = "Ảnh đã được thêm!" });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            return NotFound();
        }
        return Ok(image);
    }

    [HttpGet("bysinhvien/{sinhVienId}")]
    public async Task<IActionResult> GetImagesBySinhVien(string sinhVienId)
    {
        var images = await _context.Images
                                   .Where(i => i.SinhVienId == sinhVienId)
                                   .OrderByDescending(i => i.CreatedAt)
                                   .ToListAsync();

        if (images == null || images.Count == 0)
            return NotFound(new { message = "Không tìm thấy ảnh nào cho sinh viên này." });

        return Ok(images);
    }

}
