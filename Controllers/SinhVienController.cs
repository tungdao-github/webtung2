using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Models;
using OfficeOpenXml;
namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SinhVienController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public SinhVienController(SinhVienDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("import-excel")]
        //[Consumes("multipart/form-data")]
        public async Task<IActionResult> ImportExcel([FromForm]IFormFile file)
        {
           
            if (file == null || file.Length == 0)
                return BadRequest("Vui lòng chọn file Excel.");

            var students = new List<Sinhvien>();
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
                            existingStudent.XepLoai = worksheet.Cells[row, 14].Text;
                            existingStudent.CoVanHocTap = worksheet.Cells[row, 15].Text;
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
                                TinhTrangHocTap = worksheet.Cells[row, 13].Text,
                                XepLoai = worksheet.Cells[row, 14].Text,
                                CoVanHocTap = worksheet.Cells[row, 15].Text
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

        [HttpPost]
        public IActionResult CreateSinhVien([FromBody] Sinhvien sinhvien)
        {
            _context.Sinhviens.Add(sinhvien);
            _context.SaveChanges();
            return Ok(new { message = "Thêm sinh viên thành công!" });
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] Sinhvien sinhVien)
        {
            if (sinhVien == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            await _context.Sinhviens.AddAsync(sinhVien);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Thêm sinh viên thành công!" });
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;

                if (string.IsNullOrEmpty(maSinhVien))
                {
                    return Unauthorized(new { Message = "Ma sinh vien don't exists" });
                }
                var sinhvien = await _context.Sinhviens
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.MaSinhVien,
                        d.TenSinhVien,
                        d.GioiTinh,
                        d.NgaySinh,
                        d.SoDienThoai,
                        d.Cccd,
                        d.DanToc,
                        d.Lop,
                        d.BaoHiem,
                        d.HocPhi,
                        d.TrungBinhTrungTichLuy,
                        d.SoLuongDiemF,
                        d.TinhTrangHocTap,
                        d.XepLoai,
                        d.CoVanHocTap
                    })
                    .ToListAsync();
                return Ok(sinhvien);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}