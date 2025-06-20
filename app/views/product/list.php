<?php include 'app/views/shares/header.php'; ?>

<style>
.page-header {
    background-color: #fff;
    padding: 2rem;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0,0,0,.1);
    margin-bottom: 2rem;
}

.card {
    border: none;
    box-shadow: 0 2px 4px rgba(0,0,0,.1);
    transition: transform 0.3s ease;
}

.card:hover {
    transform: translateY(-5px);
}

.card-img-top {
    height: 250px;
    object-fit: cover;
    border-top-left-radius: 8px;
    border-top-right-radius: 8px;
}

.card-body {
    padding: 1.5rem;
}

.card-title {
    font-size: 1.2rem;
    font-weight: 600;
    margin-bottom: 1rem;
}

.card-title a {
    color: #2c3e50;
    text-decoration: none;
}

.card-title a:hover {
    color: #3498db;
}

.card-text {
    color: #666;
    margin-bottom: 0.5rem;
}

.price {
    color: #e74c3c;
    font-size: 1.2rem;
    font-weight: 600;
}

.category-badge {
    display: inline-block;
    padding: 0.25rem 0.75rem;
    background-color: #f1f1f1;
    color: #666;
    border-radius: 20px;
    font-size: 0.9rem;
}

.btn-group {
    margin-top: 1rem;
}

.btn-group .btn {
    margin-right: 0.5rem;
    border-radius: 20px;
    padding: 0.5rem 1rem;
}
</style>

<div class="page-header">
    <div class="d-flex justify-content-between align-items-center">
        <h1 class="mb-0">Danh sách sản phẩm</h1>
        <?php if (SessionHelper::isAdmin()): ?>
            <a href="/Product/add" class="btn btn-primary">
                <i class="fas fa-plus mr-1"></i>Thêm sản phẩm mới
            </a>
        <?php endif; ?>
    </div>
</div>

<div id="product-list" class="row">
    <!-- Danh sách sản phẩm sẽ được tải từ API -->
</div>

<script>
async function loadProducts() {
    const token = localStorage.getItem('jwtToken');
    if (!token) {
        alert('Bạn cần đăng nhập lại');
        location.href = '/account/login';
        return;
    }

    try {
        const response = await fetch('/api/product', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });

        if (!response.ok) {
            throw new Error('Không thể tải danh sách sản phẩm');
        }

        const products = await response.json();
        const productList = document.getElementById('product-list');
        productList.innerHTML = '';

        products.forEach(product => {
            const productItem = document.createElement('div');
            productItem.className = 'col-md-4 mb-4';
            productItem.innerHTML = `
                <div class="card h-100">
                    <img src="${product.image ? '/' + product.image : '/uploads/default-product.jpg'}"
                         class="card-img-top" alt="${product.name}">
                         
                    <div class="card-body">
                        <h5 class="card-title">
                            <a href="/Product/show/${product.id}">
                                ${product.name}
                            </a>
                        </h5>
                        <p class="card-text text-truncate">
                            ${product.description}
                        </p>
                        <p class="price">
                            ${new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(product.price)}
                        </p>
                        <span class="category-badge">
                            <i class="fas fa-tag mr-1"></i>
                            ${product.category_name}
                        </span>

                        <div class="btn-group">
                            ${!<?php echo SessionHelper::isAdmin() ? 'true' : 'false'; ?> ? `
                                <a href="/Product/addToCart/${product.id}" class="btn btn-outline-primary btn-sm">
                                    <i class="fas fa-cart-plus mr-1"></i>Thêm vào giỏ
                                </a>
                            ` : ''}

                            ${<?php echo SessionHelper::isAdmin() ? 'true' : 'false'; ?> ? `
                                <a href="/Product/edit/${product.id}" class="btn btn-outline-warning btn-sm">
                                    <i class="fas fa-edit mr-1"></i>Sửa
                                </a>
                                <button onclick="deleteProduct(${product.id})" class="btn btn-outline-danger btn-sm">
                                    <i class="fas fa-trash mr-1"></i>Xóa
                                </button>
                            ` : ''}
                        </div>
                    </div>
                </div>
            `;
            productList.appendChild(productItem);
        });
    } catch (error) {
        alert('Có lỗi xảy ra: ' + error.message);
    }
}

async function deleteProduct(id) {
    if (!confirm('Bạn có chắc chắn muốn xóa sản phẩm này?')) {
        return;
    }

    const token = localStorage.getItem('jwtToken');
    if (!token) {
        alert('Bạn cần đăng nhập lại');
        location.href = '/account/login';
        return;
    }

    try {
        const response = await fetch(`/api/product/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });

        const result = await response.json();

        if (response.ok) {
            alert('Xóa sản phẩm thành công!');
            loadProducts(); // Tải lại danh sách
        } else {
            alert(result.message || 'Xóa sản phẩm thất bại');
        }
    } catch (error) {
        alert('Có lỗi xảy ra: ' + error.message);
    }
}

// Tải danh sách sản phẩm khi trang được load
document.addEventListener('DOMContentLoaded', loadProducts);
</script>

<?php include 'app/views/shares/footer.php'; ?>