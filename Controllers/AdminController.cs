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

namespace WebApplication2.Controllers
{
    [AuthorizeRole(1)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public AdminController(SinhVienDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-excel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Vui lòng chọn file Excel.");

            var students = new List<Sinhvien>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                        return BadRequest("File Excel không có dữ liệu.");

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var maSinhVien = worksheet.Cells[row, 1].Text;
                        if (string.IsNullOrEmpty(maSinhVien)) continue;

                        var existingStudent = await _context.Sinhviens.FindAsync(maSinhVien);

                        if (existingStudent != null)
                        {
                            existingStudent.TenSinhVien = worksheet.Cells[row, 2].Text;
                            existingStudent.GioiTinh = worksheet.Cells[row, 3].Text;
                            existingStudent.NgaySinh = DateTime.TryParse(worksheet.Cells[row, 4].Text, out var ngaySinh) ? ngaySinh : existingStudent.NgaySinh;
                            existingStudent.SoDienThoai = worksheet.Cells[row, 5].Text;
                            existingStudent.Cccd = worksheet.Cells[row, 6].Text;
                            existingStudent.DanToc = worksheet.Cells[row, 7].Text;
                            existingStudent.Lop = worksheet.Cells[row, 8].Text;
                            existingStudent.BaoHiem = ulong.TryParse(worksheet.Cells[row, 9].Text, out var baoHiem) ? baoHiem : existingStudent.BaoHiem;
                            existingStudent.HocPhi = decimal.TryParse(worksheet.Cells[row, 10].Text, out var hocPhi) ? hocPhi : existingStudent.HocPhi;
                            existingStudent.TrungBinhTrungTichLuy = float.TryParse(worksheet.Cells[row, 11].Text, out var tbtt) ? tbtt : existingStudent.TrungBinhTrungTichLuy;
                            existingStudent.SoLuongDiemF = int.TryParse(worksheet.Cells[row, 12].Text, out var diemF) ? diemF : existingStudent.SoLuongDiemF;
                            existingStudent.TinhTrangHocTap = worksheet.Cells[row, 13].Text;
                        }
                        else
                        {
                            var student = new Sinhvien
                            {
                                MaSinhVien = maSinhVien,
                                TenSinhVien = worksheet.Cells[row, 2].Text,
                                GioiTinh = worksheet.Cells[row, 3].Text,
                                NgaySinh = DateTime.TryParse(worksheet.Cells[row, 4].Text, out var ns) ? ns : null,
                                SoDienThoai = worksheet.Cells[row, 5].Text,
                                Cccd = worksheet.Cells[row, 6].Text,
                                DanToc = worksheet.Cells[row, 7].Text,
                                Lop = worksheet.Cells[row, 8].Text,
                                BaoHiem = ulong.TryParse(worksheet.Cells[row, 9].Text, out var bh) ? bh : (ulong?)null,
                                HocPhi = decimal.TryParse(worksheet.Cells[row, 10].Text, out var hp) ? hp : (decimal?)null,
                                TrungBinhTrungTichLuy = float.TryParse(worksheet.Cells[row, 11].Text, out var tbt) ? tbt : (float?)null,
                                SoLuongDiemF = int.TryParse(worksheet.Cells[row, 12].Text, out var sf) ? sf : (int?)null,
                                TinhTrangHocTap = worksheet.Cells[row, 13].Text
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            await _context.Sinhviens.AddRangeAsync(students);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Import thành công", Total = students.Count });
        }
    }
}
