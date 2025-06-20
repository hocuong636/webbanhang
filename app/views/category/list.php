<?php include 'app/views/shares/header.php'; ?>
<h1>Danh sách danh mục</h1>
<div class="row mb-3">
    <div class="col">
        <a href="/Category/add" class="btn btn-success">
            <i class="fas fa-plus"></i> Thêm danh mục mới
        </a>
    </div>
</div>

<div class="table-responsive">
    <table class="table table-striped table-hover">
        <thead class="table-light">
            <tr>
                <th scope="col">#</th>
                <th scope="col">Tên danh mục</th>
                <th scope="col">Mô tả</th>
                <th scope="col">Thao tác</th>
            </tr>
        </thead>
        <tbody id="category-list">
            <!-- Danh sách danh mục sẽ được tải từ API và hiển thị tại đây -->
        </tbody>
    </table>
</div>

<?php include 'app/views/shares/footer.php'; ?>
<script>
    document.addEventListener("DOMContentLoaded", function() {
        fetch('/api/category')
            .then(response => response.json())
            .then(data => {
                const categoryList = document.getElementById('category-list');
                data.forEach((category, index) => {
                    const row = document.createElement('tr');
                    row.innerHTML = `
                        <td>${index + 1}</td>
                        <td>${category.name}</td>
                        <td>${category.description}</td>
                        <td>
                            <a href="/Category/edit/${category.id}" class="btn btn-warning btn-sm">
                                <i class="fas fa-edit"></i> Sửa
                            </a>
                            <button class="btn btn-danger btn-sm" onclick="deleteCategory(${category.id})">
                                <i class="fas fa-trash"></i> Xóa
                            </button>
                        </td>
                    `;
                    categoryList.appendChild(row);
                });
            });
    });

    function deleteCategory(id) {
        if (confirm('Bạn có chắc chắn muốn xóa danh mục này?')) {
            fetch(`/api/category/${id}`, {
                    method: 'DELETE'
                })
                .then(response => response.json())
                .then(data => {
                    if (data.message && data.message.includes('success')) {
                        location.reload();
                    } else {
                        alert('Xóa danh mục thất bại');
                    }
                });
        }
    }
</script>