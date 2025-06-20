<?php include 'app/views/shares/header.php'; ?>
<h1>Danh sách sản phẩm</h1>
<div class="row mb-3">
    <div class="col">
        <a href="/Product/add" class="btn btn-success">Thêm sản phẩm mới</a>
    </div>
</div>

<div class="row" id="product-list">
    <!-- Danh sách sản phẩm sẽ được tải từ API và hiển thị tại đây -->
</div>
<?php include 'app/views/shares/footer.php'; ?>
<script>
    document.addEventListener("DOMContentLoaded", function() {
        fetch('/api/product')
            .then(response => response.json())
            .then(data => {
                const productList = document.getElementById('product-list');
                data.forEach(product => {
                    const productItem = document.createElement('div');
                    productItem.className = 'col-md-4 mb-4';
                    productItem.innerHTML = `
                        <div class="card h-100">
                            <img src="${product.image ? '/' + product.image : '/uploads/default-product.jpg'}"
                                class="card-img-top" alt="${product.name}"
                                style="height: 200px; object-fit: cover;">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <a href="/Product/show/${product.id}" class="text-decoration-none">
                                        ${product.name}
                                    </a>
                                </h5>
                                <p class="card-text text-truncate">${product.description}</p>
                                <p class="card-text">
                                    <strong>Giá:</strong> ${new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(product.price)}
                                </p>
                                <p class="card-text"><small class="text-muted">Danh mục: ${product.category_name}</small></p>
                            </div>
                            <div class="card-footer bg-transparent border-top-0">
                                <a href="/Product/edit/${product.id}" class="btn btn-warning btn-sm">
                                    <i class="fas fa-edit"></i> Sửa
                                </a>
                                <button class="btn btn-danger btn-sm" onclick="deleteProduct(${product.id})">
                                    <i class="fas fa-trash"></i> Xóa
                                </button>
                            </div>
                        </div>
                    `;
                    productList.appendChild(productItem);
                });
            });
    });

    function deleteProduct(id) {
        if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này?')) {
            fetch(`/api/product/${id}`, {
                    method: 'DELETE'
                })
                .then(response => response.json())
                .then(data => {
                    if (data.message && data.message.includes('success')) {
                        location.reload();
                    } else {
                        alert('Xóa sản phẩm thất bại');
                    }
                });
        }
    }
</script>