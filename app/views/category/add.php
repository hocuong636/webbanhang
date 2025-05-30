<?php include 'app/views/shares/header.php'; ?>

<div class="container py-5">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-body">
                    <h2 class="card-title mb-4">Thêm danh mục mới</h2>
                    
                    <form action="/Category/save" method="POST">
                        <div class="mb-3">
                            <label for="name" class="form-label">Tên danh mục</label>
                            <input type="text"
                                   class="form-control"
                                   id="name"
                                   name="name"
                                   required>
                        </div>
                        
                        <div class="mb-3">
                            <label for="description" class="form-label">Mô tả</label>
                            <textarea class="form-control"
                                      id="description"
                                      name="description"
                                      rows="3"></textarea>
                        </div>
                        
                        <div class="d-flex justify-content-between">
                            <a href="/Category" class="btn btn-outline-secondary">
                                <i class="fas fa-arrow-left mr-1"></i>Quay lại
                            </a>
                            <button type="submit" class="btn btn-primary">
                                <i class="fas fa-save mr-1"></i>Thêm danh mục
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

<style>
.card {
    border: none;
    border-radius: 8px;
}

.card-title {
    font-weight: 500;
}
</style>

<?php include 'app/views/shares/footer.php'; ?>