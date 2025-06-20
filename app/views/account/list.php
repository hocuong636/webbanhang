<?php include 'app/views/shares/header.php'; ?>

<div class="container py-5">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Danh sách người dùng</h2>
        <a href="/Account/add" class="btn btn-primary">
            <i class="fas fa-plus-circle mr-2"></i>Thêm người dùng mới
        </a>
    </div>

    <div class="card shadow-sm">
        <div class="card-body">
            <table class="table table-hover">
                <thead class="table-light">
                    <tr>
                        <th>Tên đăng nhập</th>
                        <th>Họ tên</th>
                        <th>Email</th>
                        <th>Số điện thoại</th>
                        <th>Vai trò</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($accounts as $account): ?>
                    <tr>
                        <td><?php echo htmlspecialchars($account->username, ENT_QUOTES, 'UTF-8'); ?></td>
                        <td><?php echo htmlspecialchars($account->fullname, ENT_QUOTES, 'UTF-8'); ?></td>
                        <td><?php echo htmlspecialchars($account->email ?? '', ENT_QUOTES, 'UTF-8'); ?></td>
                        <td><?php echo htmlspecialchars($account->phone ?? '', ENT_QUOTES, 'UTF-8'); ?></td>
                        <td>
                            <span class="badge <?php echo $account->role === 'admin' ? 'bg-danger' : 'bg-info'; ?>">
                                <?php echo htmlspecialchars($account->role, ENT_QUOTES, 'UTF-8'); ?>
                            </span>
                        </td>
                        <td>
                            <div class="btn-group" role="group">
                                <?php if ($_SESSION['role'] === 'admin'): ?>
                                    <?php if ($account->username !== $_SESSION['username']): ?>
                                        <a href="/Account/editUser/<?php echo $account->id; ?>"
                                           class="btn btn-outline-warning btn-sm">
                                            <i class="fas fa-edit mr-1"></i>Sửa
                                        </a>
                                    <?php else: ?>
                                        <a href="/Account/edit"
                                           class="btn btn-outline-warning btn-sm">
                                            <i class="fas fa-edit mr-1"></i>Sửa
                                        </a>
                                    <?php endif; ?>
                                    <?php if ($account->role !== 'admin'): ?>
                                        <a href="/Account/delete/<?php echo $account->username; ?>"
                                           class="btn btn-outline-danger btn-sm"
                                           onclick="return confirm('Bạn có chắc chắn muốn xóa người dùng này?');">
                                            <i class="fas fa-trash-alt mr-1"></i>Xóa
                                        </a>
                                    <?php endif; ?>
                                <?php endif; ?>
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

.badge {
    padding: 0.5em 1em;
}
</style>

<?php include 'app/views/shares/footer.php'; ?>