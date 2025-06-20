<?php
require_once('app/models/AccountModel.php');
$accountModel = new AccountModel((new Database())->getConnection());
?>
<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cửa hàng thời trang</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet">
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            background-color: #f8f9fa;
        }

        .navbar {
            background-color: #fff !important;
            box-shadow: 0 2px 4px rgba(0, 0, 0, .1);
            padding: 1rem 2rem;
        }

        .navbar-brand {
            font-weight: 700;
            font-size: 1.5rem;
            color: #2c3e50 !important;
        }

        .nav-link {
            font-weight: 500;
            color: #34495e !important;
            margin: 0 10px;
            transition: color 0.3s ease;
        }

        .nav-link:hover {
            color: #3498db !important;
        }

        .nav-item.active .nav-link {
            color: #3498db !important;
        }

        .navbar-toggler {
            border: none;
            padding: 0.5rem;
        }

        .container {
            max-width: 1200px;
            margin: 0 auto;
        }

        .cart-icon {
            position: relative;
        }

        .cart-badge {
            position: absolute;
            top: -8px;
            right: -8px;
            background-color: #e74c3c;
            color: white;
            border-radius: 50%;
            padding: 0.25rem 0.5rem;
            font-size: 0.75rem;
        }
        
        .avatar-img {
            width: 30px;
            height: 30px;
            border-radius: 50%;
            object-fit: cover;
            margin-right: 5px;
        }
        
        .user-info {
            display: flex;
            align-items: center;
        }
    </style>
</head>

<body>
    <nav class="navbar navbar-expand-lg navbar-light">
        <div class="container">
            <a class="navbar-brand" href="/">
                <i class="fas fa-tshirt mr-2"></i>Fashion Store
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="/Product/">
                            <i class="fas fa-list mr-1"></i>Danh sách sản phẩm
                        </a>
                    </li>
                    <?php if (SessionHelper::isAdmin()): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="/Category">
                                <i class="fas fa-list mr-1"></i>Danh sách danh mục
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/Account">
                                <i class="fas fa-list mr-1"></i>Danh sách người dùng
                            </a>
                        </li>
                    <?php endif; ?>
                    <?php if (!SessionHelper::isAdmin()): ?>
                    <li class="nav-item">
                        <a class="nav-link cart-icon" href="/Product/cart">
                            <i class="fas fa-shopping-cart mr-1"></i>Giỏ hàng
                        </a>
                    </li>
                    <?php endif; ?>
                    <li class="nav-item">
                        <?php
                        if (SessionHelper::isLoggedIn()) {
                            $account = $accountModel->getAccountByUsername($_SESSION['username']);
                            echo "<a class='nav-link user-info' href='/account/edit'>";
                            if (!empty($account->image)) {
                                echo "<img src='/uploads/" . htmlspecialchars($account->image) . "' class='avatar-img' alt='Avatar'>";
                            } else {
                                echo "<img src='https://i0.wp.com/sbcf.fr/wp-content/uploads/2018/03/sbcf-default-avatar.png?w=300&ssl=1' class='avatar-img' alt='Default Avatar'>";
                            }
                            if (SessionHelper::isAdmin()){
                                echo "<span>" . $_SESSION['username'] . " (" . SessionHelper::getRole() . ")</span>";
                            } else {
                                echo "<span>" . $_SESSION['username'] . "</span>";
                            }
                            echo "</a>";
                        } else {
                            echo  "<a class='nav-link'href='/account/login'>Đăng nhập</a>";
                        }
                        ?>

                    </li>
                    <li class="nav-item">
                        </a>
                        <?php
                        if (SessionHelper::isLoggedIn()) {
                            echo  "<a class='nav-link'href='/account/logout'>Đăng xuất</a>";
                        }
                        ?>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container mt-4">
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>

</html>