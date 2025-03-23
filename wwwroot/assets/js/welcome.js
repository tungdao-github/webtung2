//////document.addEventListener('DOMContentLoaded', async function () {
//////    const token = localStorage.getItem('token');
//////    // Sau khi login thành công (trong API đăng nhập)
//////    //localStorage.setItem('maSinhVien', response.maSinhVien); // Kiểm tra xem API trả về ID đúng không


//////    //const sinhVienId = localStorage.getItem('maSinhVien');
//////    //console.log("SinhVienId:", sinhVienId);
//////    //console.log(localStorage.getItem('sinhVienId'));
//////    if (!token) {
//////        alert('Vui lòng đăng nhập lại!');
//////        window.location.href = '/index.html';
//////        return;
//////    }


////document.addEventListener("DOMContentLoaded", async function () {
////    const token = localStorage.getItem("token");

////    //console.log("token:", token);
////    const sinhVienId = localStorage.getItem("maSinhVien");
////    //console.log("sinhVienId:", sinhVienId);
////    console.log("Toàn bộ localStorage:", localStorage);
////    if (!token || !sinhVienId) {
////        alert("Bạn chưa đăng nhập!");
////        window.location.href = "/index.html";
////        return;
////    }

////        try {
////            const response = await fetch('http://localhost:5276/api/SinhVien', {
////                method: 'GET',
////                headers: { 'Authorization': `Bearer ${token}` }
////            });

////            if (!response.ok) {
////                throw new Error('Không thể lấy thông tin sinh viên');
////            }

////            const data = await response.json();
////            const student = data.$values[0];
////            // ✅ Sửa lại cách lưu vào localStorage

////            document.getElementById('text_name').textContent = student.tenSinhVien;
////            document.getElementById('student_name').textContent = student.tenSinhVien;
////            document.getElementById('student_id').textContent = student.maSinhVien;
////            document.getElementById('student_class').textContent = student.lop;
////            document.getElementById('student_phone').textContent = student.soDienThoai;
////            document.getElementById('student_birthday').textContent = student.ngaySinh;
////            document.getElementById('Health_insurance').textContent = student.baoHiem;
////            document.getElementById('student_fee').textContent = student.hocPhi;
////            document.getElementById('nation').textContent = student.danToc;
////            document.getElementById('student_gpa').textContent = student.trungBinhTrungTichLuy;
////            document.getElementById('student_cmnd').textContent = student.cccd;
////            document.getElementById('student_failed_credits').textContent = student.soLuongDiemF;
////            document.getElementById('student_gender').textContent = student.gioiTinh ? "nam" : "nu";
////            document.getElementById('student_presence').textContent = student.tinhTrangHocTap;
////            document.getElementById('student_gpa2').textContent = student.trungBinhTrungTichLuy;
////            document.getElementById('student_tongtinchi').textContent = 2;
////            document.getElementById('student_xeploai').textContent = student.xepLoai;

////            document.getElementById('student_somonno').textContent = student.soLuongDiemF;
////            document.getElementById('student_covanhoctap').textContent = student.coVanHocTap;
////            console.log("tungdao");
////            document.getElementById('uploadForm').addEventListener('submit', async function (e) {
////                e.preventDefault();

////                const formData = new FormData();
////                const imageFile = document.getElementById('imageFile').files[0];
////                formData.append('imageFile', imageFile);

////                try {
////                    const response = await fetch('/upload-avatar', {
////                        method: 'POST',
////                        body: formData
////                    });

////                    if (response.ok) {
////                        const data = await response.json();
////                        document.getElementById('avatarImage').src = data.AvatarUrl;
////                    } else {
////                        alert('Upload thất bại!');
////                    }
////                } catch (error) {
////                    console.error('Lỗi:', error);
////                    alert('Đã xảy ra lỗi!');
////                }
////            });

////        } catch (error) {
////            console.log('Lỗi:', error.message);
////            console.error('Lỗi:', error.message);

////        }

////    });
////    try {
////        console.log("sinhVienId:", sinhVienId);
////        // Gọi API để lấy ảnh từ database
////        let response = await fetch(`http://localhost:5276/api/images/${sinhVienId}`, {
////            method: "GET",
////            headers: { "Authorization": `Bearer ${token}` }
////        });

////        if (!response.ok) {
////            throw new Error("Không thể lấy ảnh sinh viên");
////        }

////        let data = await response.json();
////        let iframe = document.getElementById("avatarFrame");
////        if (iframe) {
////            iframe.src = data.imageUrl;
////            console.log("Đã gán ảnh vào iframe:", data.imageUrl);
////        } else {
////            console.error("Không tìm thấy thẻ iframe với ID 'avatarFrame'");
////        }
////        // Cập nhật iframe với link ảnh từ Google Drive
////        //let iframe = document.getElementById("avatarFrame");
////        //iframe.src = data.imageUrl;
////        console.log("Image URL:", data.imageUrl);
////        console.log("Dữ liệu từ API:", data);
////    } catch (error) {
////        console.error("Lỗi khi tải ảnh:", error);
////    }
////});

//document.addEventListener("DOMContentLoaded", async function () {
//    const token = localStorage.getItem("token");
//    var sinhVienId = localStorage.getItem("maSinhVien");

//    console.log("Toàn bộ localStorage:", localStorage);

//    if (!token || !sinhVienId) {
//        alert("Bạn chưa đăng nhập!");
//        window.location.href = "/index.html";
//        return;
//    }

//    try {
//        // 📌 Gọi API lấy thông tin sinh viên
//        const response = await fetch('http://localhost:5276/api/SinhVien', {
//            method: 'GET',
//            headers: { 'Authorization': `Bearer ${token}` }
//        });

//        if (!response.ok) {
//            throw new Error('Không thể lấy thông tin sinh viên');
//        }

//        const data = await response.json();
//        const student = data.$values[0];
//        localStorage.setItem("maSinhVien", student.maSinhVien);
//        console.log("Toàn bộ localStorage2:", localStorage);
//        sinhVienId = localStorage.getItem("maSinhVien");
//        console.log("mã SinhVienId:", sinhVienId);
//        // 🏷️ Gán thông tin sinh viên vào HTML
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
//        document.getElementById('student_gender').textContent = student.gioiTinh ? "Nam" : "Nữ";
//        document.getElementById('student_presence').textContent = student.tinhTrangHocTap;
//        document.getElementById('student_gpa2').textContent = student.trungBinhTrungTichLuy;
//        document.getElementById('student_tongtinchi').textContent = 2;
//        document.getElementById('student_xeploai').textContent = student.xepLoai;
//        document.getElementById('student_somonno').textContent = student.soLuongDiemF;
//        document.getElementById('student_covanhoctap').textContent = student.coVanHocTap;

//        console.log("Đã tải thông tin sinh viên thành công.");

//        // 📌 Gọi API để lấy ảnh sinh viên
//        await loadStudentImage(sinhVienId, token);

//    } catch (error) {
//        console.error('Lỗi:', error.message);
//    }

//    // 📌 Xử lý upload ảnh
//    document.getElementById('uploadForm').addEventListener('submit', async function (e) {
//        e.preventDefault();

//        const formData = new FormData();
//        const imageFile = document.getElementById('imageFile').files[0];
//        formData.append('imageFile', imageFile);

//        try {
//            const response = await fetch('/upload-avatar', {
//                method: 'POST',
//                body: formData
//            });

//            if (response.ok) {
//                const data = await response.json();
//                document.getElementById('avatarImage').src = data.AvatarUrl;
//            } else {
//                alert('Upload thất bại!');
//            }
//        } catch (error) {
//            console.error('Lỗi:', error);
//            alert('Đã xảy ra lỗi khi upload ảnh!');
//        }
//    });
//});

//// 🎯 Hàm lấy ảnh sinh viên
//async function loadStudentImage(sinhVienId, token) {
//    try {
//        console.log("Đang lấy ảnh cho sinh viên:", sinhVienId);
//        console.log("sinhVienId từ localStorage:", localStorage.getItem("maSinhVien"));
//        let response = await fetch(`http://localhost:5276/api/images/${sinhVienId}`, {
//            method: "GET",
//            headers: { "Authorization": `Bearer ${token}` }
//        });

//        if (!response.ok) {
//            throw new Error("Không thể lấy ảnh sinh viên");
//        }

//        let data = await response.json();
//        console.log("Dữ liệu ảnh từ API:", data);

//        // 🖼️ Hiển thị ảnh vào iframe
//        let iframe = document.getElementById("avatarFrame");
//        if (iframe) {
//            iframe.src = fixGoogleDriveUrl(data.imageUrl);

//            console.log("Đã gán ảnh vào iframe:", data.imageUrl);
//        } else {
//            console.error("Không tìm thấy thẻ iframe với ID 'avatarFrame'");
//        }
//    } catch (error) {
//        console.error("Lỗi khi tải ảnh:", error);
//    }
//}

//// 🔧 Hàm chuyển đổi link Google Drive (nếu dùng ảnh từ Drive)
//function fixGoogleDriveUrl(url) {
//    if (url.includes("drive.google.com")) {
//        let fileId = url.match(/[-\w]{25,}/);
//        if (fileId) {
//            return `https://drive.google.com/uc?export=view&id=${fileId[0]}`;
//        }
//    }
//    return url;
//}


document.addEventListener("DOMContentLoaded", async function () {
    console.log("tungdao");
    const token = localStorage.getItem("token");
    let sinhVienId = localStorage.getItem("maSinhVien");
    console.log(token);
    console.log(sinhVienId);
    console.log("Toàn bộ localStorage:", localStorage);
    
    if (!token || !sinhVienId) {
       alert("Bạn chưa đăng nhập!");
        //alert("Bạn chưa đăng nhập!", localStorage);
        window.location.href = "/index.html";
        return;
    }

    try {
        // 📌 Gọi API lấy thông tin sinh viên
        const response = await fetch('https://localhost:44380/api/SinhVien', {
            method: 'GET',
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (!response.ok) {
            throw new Error('Không thể lấy thông tin sinh viên');
        }

        const data = await response.json();
        const student = data.$values[0];
        localStorage.setItem("maSinhVien", student.maSinhVien);
        sinhVienId = student.maSinhVien;

        // 🏷️ Gán thông tin sinh viên vào HTML
        document.getElementById('text_name').textContent = student.tenSinhVien;
        document.getElementById('student_name').textContent = student.tenSinhVien;
        document.getElementById('student_id').textContent = student.maSinhVien;
        document.getElementById('student_class').textContent = student.lop;
        document.getElementById('student_phone').textContent = student.soDienThoai;
        document.getElementById('student_birthday').textContent = student.ngaySinh;
        document.getElementById('Health_insurance').textContent = student.baoHiem;
        document.getElementById('student_fee').textContent = student.hocPhi;
        document.getElementById('nation').textContent = student.danToc;
        document.getElementById('student_gpa').textContent = student.trungBinhTrungTichLuy;
        document.getElementById('student_cmnd').textContent = student.cccd;
        document.getElementById('student_failed_credits').textContent = student.soLuongDiemF;
        document.getElementById('student_gender').textContent = student.gioiTinh ? "Nam" : "Nữ";
        document.getElementById('student_presence').textContent = student.tinhTrangHocTap;
        document.getElementById('student_gpa2').textContent = student.trungBinhTrungTichLuy;
        document.getElementById('student_xeploai').textContent = student.xepLoai;
        document.getElementById('student_somonno').textContent = student.soLuongDiemF;
        document.getElementById('student_covanhoctap').textContent = student.coVanHocTap;

        console.log("Đã tải thông tin sinh viên thành công.");

        // 📌 Gọi API để lấy ảnh sinh viên
        await loadStudentImage(sinhVienId, token);

    } catch (error) {
        console.error('Lỗi:', error.message);
    }

    // 📌 Xử lý upload ảnh
    document.getElementById('uploadForm').addEventListener('submit', async function (e) {
        e.preventDefault();

        const formData = new FormData();
        const imageFile = document.getElementById('imageFile').files[0];
        formData.append('imageFile', imageFile);

        try {
            const response = await fetch('/upload-avatar', {
                method: 'POST',
                body: formData
            });

            if (response.ok) {
                const data = await response.json();
                document.getElementById('avatarImage').src = data.AvatarUrl;
            } else {
                alert('Upload thất bại!');
            }
        } catch (error) {
            console.error('Lỗi:', error);
            alert('Đã xảy ra lỗi khi upload ảnh!');
        }
    });
});

// 🎯 Hàm lấy ảnh sinh viên
async function loadStudentImage(sinhVienId, token) {
    try {
        console.log("Đang lấy ảnh cho sinh viên:", sinhVienId);

        let response = await fetch(`https://localhost:44380/api/images/bysinhvien/${sinhVienId}`, {
            method: "GET",
            headers: { "Authorization": `Bearer ${token}` }
        });

        if (!response.ok) {
            throw new Error("Không thể lấy ảnh sinh viên");
        }

        let data = await response.json();
        console.log("Dữ liệu ảnh từ API:", data);

        // 🖼️ Hiển thị ảnh trong thẻ <img>
        let avatarImg = document.getElementById("avatarImage");
        avatarImg.src = data.$values[0].imageUrl; // Đặt đường dẫn ảnh
        avatarImg.style.display = "block"; // Hiển thị ảnh nếu bị ẩn

        console.log("Đã gán ảnh vào thẻ img:", data.$values[0].imageUrl);
    } catch (error) {
        console.error("Lỗi khi tải ảnh:", error);

        // Nếu có lỗi, hiển thị ảnh mặc định
        let avatarImg = document.getElementById("avatarImage");
        avatarImg.src = "/images/logo.png"; // Đặt đường dẫn ảnh mặc định
        avatarImg.style.display = "block";
    }
}


