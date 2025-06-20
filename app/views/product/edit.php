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

.form-control {
    border-radius: 20px;
    padding: 0.75rem 1.2rem;
}

.form-control:focus {
    box-shadow: 0 0 0 0.2rem rgba(52, 152, 219, 0.25);
    border-color: #3498db;
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

.current-image {
    max-width: 200px;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0,0,0,.1);
}

.alert {
    border-radius: 8px;
    margin-bottom: 1.5rem;
}
</style>

<div class="form-container">
    <h1 class="form-title">Sửa sản phẩm</h1>

    <div id="error-messages" class="alert alert-danger" style="display: none;">
        <ul class="mb-0"></ul>
    </div>

    <form id="edit-product-form" enctype="multipart/form-data">
        <input type="hidden" id="product-id" value="<?php echo $editId; ?>">
        
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
            <label for="image">Hình ảnh mới (không bắt buộc)</label>
            <input type="file" class="form-control" id="image" name="image" accept="image/*">
            <input type="hidden" id="existing-image" name="existing_image">
            
            <div id="current-image-container" class="mt-3" style="display: none;">
                <p class="mb-2">Ảnh hiện tại:</p>
                <img id="current-image" src="" alt="" class="current-image">
            </div>
        </div>

        <div class="mt-4">
            <button type="submit" class="btn btn-primary btn-submit">
                <i class="fas fa-save mr-2"></i>Lưu thay đổi
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

        // Load thông tin sản phẩm
        const productId = document.getElementById('product-id').value;
        const productResponse = await fetch(`/api/product/${productId}`, {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });

        if (!productResponse.ok) {
            throw new Error('Không thể tải thông tin sản phẩm');
        }

        const product = await productResponse.json();
        
        document.getElementById('name').value = product.name;
        document.getElementById('description').value = product.description;
        document.getElementById('price').value = product.price;
        document.getElementById('category_id').value = product.category_id;
        document.getElementById('existing-image').value = product.image;

        if (product.image) {
            document.getElementById('current-image-container').style.display = 'block';
            document.getElementById('current-image').src = '/' + product.image;
            document.getElementById('current-image').alt = product.name;
        }
    } catch (error) {
        alert('Có lỗi xảy ra: ' + error.message);
    }
});

document.getElementById('edit-product-form').addEventListener('submit', async function(e) {
    e.preventDefault();

    const token = localStorage.getItem('jwtToken');
    if (!token) {
        alert('Bạn cần đăng nhập lại');
        location.href = '/account/login';
        return;
    }

    const productId = document.getElementById('product-id').value;
    const formData = new FormData(this);

    try {
        const response = await fetch(`/api/product/${productId}`, {
            method: 'POST', // Using POST instead of PUT for file upload
            headers: {
                'Authorization': 'Bearer ' + token
            },
            body: formData
        });

        const result = await response.json();

        if (response.ok) {
            alert('Cập nhật sản phẩm thành công!');
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