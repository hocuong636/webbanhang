<?php include 'app/views/shares/header.php'; ?>

<style>
.form-container {
    background-color: #fff;
    padding: 2rem;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0,0,0,.1);
}

.form-title {
    color: #2c3e50;
    margin-bottom: 1.5rem;
}

.btn-submit {
    background-color: #3498db;
    border: none;
    padding: 0.75rem 2rem;
    border-radius: 20px;
    transition: background-color 0.3s ease;
}

.btn-submit:hover {
    background-color: #2980b9;
}

.btn-back {
    color: #7f8c8d;
    text-decoration: none;
    transition: color 0.3s ease;
}

.btn-back:hover {
    color: #34495e;
    text-decoration: none;
}

.form-control {
    border-radius: 20px;
    padding: 0.75rem 1.2rem;
}

.form-control:focus {
    box-shadow: 0 0 0 0.2rem rgba(52, 152, 219, 0.25);
    border-color: #3498db;
}
</style>

<div class="form-container">
    <h1 class="form-title">Thêm sản phẩm mới</h1>
    
    <div id="error-messages" class="alert alert-danger" style="display: none;">
        <ul class="mb-0"></ul>
    </div>

    <form id="add-product-form" enctype="multipart/form-data">
        <div class="form-group">
            <label for="name">Tên sản phẩm</label>
            <input type="text" class="form-control" id="name" name="name" required>
        </div>

        <div class="form-group">
            <label for="description">Mô tả</label>
            <textarea class="form-control" id="description" name="description" rows="3" required></textarea>
        </div>

        <div class="form-group">
            <label for="price">Giá (VNĐ)</label>
            <input type="number" class="form-control" id="price" name="price" min="0" required>
        </div>

        <div class="form-group">
            <label for="category_id">Danh mục</label>
            <select class="form-control" id="category_id" name="category_id" required>
                <option value="">Chọn danh mục</option>
            </select>
        </div>

        <div class="form-group">
            <label for="image">Hình ảnh</label>
            <input type="file" class="form-control" id="image" name="image" accept="image/*">
            <small class="form-text text-muted">Chọn file ảnh (JPG, PNG, GIF)</small>
        </div>

        <div class="mt-4">
            <button type="submit" class="btn btn-primary btn-submit">
                <i class="fas fa-save mr-2"></i>Lưu sản phẩm
            </button>
            <a href="/Product" class="btn btn-back ml-3">
                <i class="fas fa-arrow-left mr-2"></i>Quay lại
            </a>
        </div>
    </form>
</div>

<script>
document.addEventListener('DOMContentLoaded', async function() {
    const token = localStorage.getItem('jwtToken');
    if (!token) {
        alert('Bạn cần đăng nhập lại');
        location.href = '/account/login';
        return;
    }

    // Load danh mục
    try {
        const response = await fetch('/api/category', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });

        if (!response.ok) {
            throw new Error('Không thể tải danh sách danh mục');
        }

        const categories = await response.json();
        const categorySelect = document.getElementById('category_id');
        
        categories.forEach(category => {
            const option = document.createElement('option');
            option.value = category.id;
            option.textContent = category.name;
            categorySelect.appendChild(option);
        });
    } catch (error) {
        alert('Có lỗi xảy ra khi tải danh mục: ' + error.message);
    }
});

document.getElementById('add-product-form').addEventListener('submit', async function(e) {
    e.preventDefault();

    const token = localStorage.getItem('jwtToken');
    if (!token) {
        alert('Bạn cần đăng nhập lại');
        location.href = '/account/login';
        return;
    }

    const formData = new FormData(this);

    try {
        const response = await fetch('/api/product', {
            method: 'POST',
            headers: {
                'Authorization': 'Bearer ' + token
            },
            body: formData
        });

        const result = await response.json();

        if (response.ok) {
            alert('Thêm sản phẩm thành công!');
            location.href = '/Product';
        } else {
            const errorContainer = document.getElementById('error-messages');
            const errorList = errorContainer.querySelector('ul');
            errorList.innerHTML = '';

            if (result.errors) {
                Object.values(result.errors).forEach(error => {
                    const li = document.createElement('li');
                    li.textContent = error;
                    errorList.appendChild(li);
                });
            } else {
                const li = document.createElement('li');
                li.textContent = result.message || 'Có lỗi xảy ra';
                errorList.appendChild(li);
            }
            errorContainer.style.display = 'block';
        }
    } catch (error) {
        alert('Có lỗi xảy ra: ' + error.message);
    }
});
</script>

<?php include 'app/views/shares/footer.php'; ?>