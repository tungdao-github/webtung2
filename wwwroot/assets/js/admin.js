
document.getElementById('submitExcel').addEventListener('click', async function () { 
    const token = localStorage.getItem('token');
    var formData = new FormData();
    formData.append('file', file);

    fetch('http://localhost:5276/api/SinhVien/import-excel', {
        method: 'POST',
        headers: {
            "Authorization": `Bearer ${token}`
        },
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            alert('Tải lên thành công:', data);
            // Thực hiện các hành động khác sau khi tải lên thành công
        })
        .catch(error => {
            alert('loi khi tai len')
            console.error('Lỗi khi tải lên:', error);
            // Xử lý lỗi khi tải lên
        });
});