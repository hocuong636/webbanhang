<?php include 'app/views/shares/header.php'; ?>

<div class="container py-5">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Danh sách danh mục</h2>
        <a href="/Category/add" class="btn btn-primary">
            <i class="fas fa-plus-circle mr-2"></i>Thêm danh mục mới
        </a>
    </div>

    <div class="card shadow-sm">
        <div class="card-body">
            <table class="table table-hover">
                <thead class="table-light">
                    <tr>
                        <th>Tên danh mục</th>
                        <th>Mô tả</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($categories as $category): ?>
                    <tr>
                        <td><?php echo htmlspecialchars($category->name, ENT_QUOTES, 'UTF-8'); ?></td>
                        <td><?php echo htmlspecialchars($category->description, ENT_QUOTES, 'UTF-8'); ?></td>
                        <td>
                            <div class="btn-group" role="group">
                                <a href="/Category/edit/<?php echo $category->id; ?>"
                                   class="btn btn-outline-warning btn-sm">
                                    <i class="fas fa-edit mr-1"></i>Sửa
                                </a>
                                <a href="/Category/delete/<?php echo $category->id; ?>"
                                   class="btn btn-outline-danger btn-sm"
                                   onclick="return confirm('Bạn có chắc chắn muốn xóa danh mục này?');">
                                    <i class="fas fa-trash-alt mr-1"></i>Xóa
                                </a>
                            </div>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        </div>
    </div>
</div>

<style>
.btn-group .btn {
    border-radius: 4px;
    margin: 0 2px;
}

.card {
    border: none;
    border-radius: 8px;
}
</style>

<?php include 'app/views/shares/footer.php'; ?>