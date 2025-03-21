//document.addEventListener('DOMContentLoaded', async function () {
//    const token = localStorage.getItem('token');
//    if (!token) {
//        alert('Vui lòng đăng nhập lại!');
//        window.location.href = '/index.html';
//        return;
//    }

//    try {
//        const response = await fetch('http://localhost:5276/api/SinhVien', {
//            method: 'GET',
//            headers: { 'Authorization': `Bearer ${token}` }
//        });

//        if (!response.ok) {
//            throw new Error('Không thể lấy thông tin sinh viên');
//        }

//        const data = await response.json();
//        const student = data.$values[0];
        
//        document.getElementById('text_name').textContent = student.tenSinhVien;
//        document.getElementById('student_name').textContent = student.tenSinhVien;
//        document.getElementById('student_id').textContent = student.maSinhVien;
//        document.getElementById('student_class').textContent = student.lop;
//        document.getElementById('student_phone').textContent = student.soDienThoai;
//        document.getElementById('student_birthday').textContent = student.ngaySinh; 
//        document.getElementById('Health_insurance').textContent = student.baoHiem; 
//        document.getElementById('student_fee').textContent = student.hocPhi; 
//        document.getElementById('nation').textContent = student.danToc;
//        document.getElementById('student_gpa').textContent = student.trungBinhTrungTichLuy; 
//        document.getElementById('student_cmnd').textContent = student.cccd;
//        document.getElementById('student_failed_credits').textContent = student.soLuongDiemF; 
//        document.getElementById('student_gender').textContent = student.gioiTinh ? "nam" : "nu";
//        document.getElementById('student_presence').textContent = student.tinhTrangHocTap;
//        document.getElementById('student_gpa2').textContent = student.trungBinhTrungTichLuy;
//        document.getElementById('student_tongtinchi').textContent = 2;
//        document.getElementById('student_xeploai').textContent = student.xepLoai;

//        document.getElementById('student_somonno').textContent = student.soLuongDiemF;
//        document.getElementById('student_covanhoctap').textContent = student.coVanHocTap;
//        console.log("tungdao");
//        document.getElementById('uploadForm').addEventListener('submit', async function (e) {
//            e.preventDefault();

//            const formData = new FormData();
//            const imageFile = document.getElementById('imageFile').files[0];
//            formData.append('imageFile', imageFile);

//            try {
//                const response = await fetch('/upload-avatar', {
//                    method: 'POST',
//                    body: formData
//                });

//                if (response.ok) {
//                    const data = await response.json();
//                    document.getElementById('avatarImage').src = data.AvatarUrl;
//                } else {
//                    alert('Upload thất bại!');
//                }
//            } catch (error) {
//                console.error('Lỗi:', error);
//                alert('Đã xảy ra lỗi!');
//            }
//        });

//    } catch (error) {
//        console.error('Lỗi:', error.message);
//    }

//});

document.addEventListener("DOMContentLoaded", async function () {
    try {
        const response = await fetch("http://localhost:5276/api/images/get-images");
        if (!response.ok) throw new Error("Không thể tải danh sách ảnh!");

        const images = await response.json();
        const gallery = document.getElementById("imageGallery");

        images.forEach(img => {
            const imgElement = document.createElement("img");
            imgElement.src = img.DisplayUrl;
            imgElement.alt = "Ảnh từ Google Drive";
            imgElement.style.width = "200px";
            imgElement.style.margin = "10px";
            gallery.appendChild(imgElement);
        });
    } catch (error) {
        console.error("Lỗi:", error);
    }
});
