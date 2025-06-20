<?php
if (session_status() === PHP_SESSION_NONE) {
    session_start();
}

require_once('app/config/database.php');
require_once('app/models/ProductModel.php');
require_once('app/models/CategoryModel.php');
class ProductController
{
    private $productModel;
    private $db;
    public function __construct()
    {
        $this->db = (new Database())->getConnection();
        $this->productModel = new ProductModel($this->db);
    }
    private function isAdmin()
    {
        return SessionHelper::isAdmin();
    }
    public function index()
    {
        if (!isset($_SESSION['username'])) {
            header('Location: /account/login');
            exit;
        }
        $products = $this->productModel->getProducts();
        include 'app/views/product/list.php';
    }
    public function show($id)
    {
        $product = $this->productModel->getProductById($id);
        if ($product) {
            include 'app/views/product/show.php';
        } else {
            echo "Không thấy sản phẩm.";
        }
    }
    public function add()
    {
        if (!$this->isAdmin()) {
            header('Location: /Product');
            exit;
        }
        include_once 'app/views/product/add.php';
    }
    public function save()
    {
        if (!$this->isAdmin()) {
            header('Location: /Product');
            exit;
        }

        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            try {
                // Validate input
                $errors = [];
                $name = $_POST['name'] ?? '';
                $description = $_POST['description'] ?? '';
                $price = $_POST['price'] ?? '';

                if (empty($name)) {
                    $errors[] = "Vui lòng nhập tên sản phẩm";
                }
                if (empty($description)) {
                    $errors[] = "Vui lòng nhập mô tả sản phẩm";
                }
                if (empty($price) || !is_numeric($price) || $price < 0) {
                    $errors[] = "Vui lòng nhập giá sản phẩm hợp lệ";
                }

                // Process image if uploaded
                $image = "";
                if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                    $image = $this->uploadImage($_FILES['image']);
                }

                if (!empty($errors)) {
                    include 'app/views/product/add.php';
                    return;
                }

                // Add product
                $result = $this->productModel->addProduct(
                    $name,
                    $description,
                    $price,
                    null,
                    $image
                );

                if (is_array($result)) {
                    $errors = $result;
                    include 'app/views/product/add.php';
                } else {
                    $_SESSION['success'] = "Thêm sản phẩm thành công!";
                    header('Location: /Product');
                    exit;
                }
            } catch (Exception $e) {
                $errors = [$e->getMessage()];
                include 'app/views/product/add.php';
            }
        }
    }
    public function edit($id)
    {
        if (!$this->isAdmin()) {
            header('Location: /Product');
            exit;
        }

        $editId = $id;
        $productModel = $this->productModel;
        include 'app/views/product/edit.php';
    }

    public function update()
    {
        if (!$this->isAdmin()) {
            header('Location: /Product');
            exit;
        }

        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            try {
                // Validate input
                $errors = [];
                $id = $_POST['id'] ?? '';
                $name = $_POST['name'] ?? '';
                $description = $_POST['description'] ?? '';
                $price = $_POST['price'] ?? '';

                if (empty($id)) {
                    throw new Exception("ID sản phẩm không hợp lệ");
                }
                if (empty($name)) {
                    $errors[] = "Vui lòng nhập tên sản phẩm";
                }
                if (empty($description)) {
                    $errors[] = "Vui lòng nhập mô tả sản phẩm";
                }
                if (empty($price) || !is_numeric($price) || $price < 0) {
                    $errors[] = "Vui lòng nhập giá sản phẩm hợp lệ";
                }

                // Process image
                $image = $_POST['existing_image'] ?? '';
                if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                    $image = $this->uploadImage($_FILES['image']);
                }

                if (!empty($errors)) {
                    $editId = $id;
                    $productModel = $this->productModel;
                    include 'app/views/product/edit.php';
                    return;
                }

                $result = $this->productModel->updateProduct(
                    $id,
                    $name,
                    $description,
                    $price,
                    null,
                    $image
                );

                if (is_array($result)) {
                    $errors = $result;
                    $editId = $id;
                    $productModel = $this->productModel;
                    include 'app/views/product/edit.php';
                } else {
                    $_SESSION['success'] = "Cập nhật sản phẩm thành công!";
                    header('Location: /Product');
                    exit;
                }
            } catch (Exception $e) {
                $errors = [$e->getMessage()];
                $editId = $_POST['id'] ?? '';
                $productModel = $this->productModel;
                include 'app/views/product/edit.php';
            }
        }
    }

    public function delete($id)
    {
        if (!$this->isAdmin()) {
            header('Location: /Product');
            exit;
        }
        if ($this->productModel->deleteProduct($id)) {
            header('Location: /Product');
        } else {
            echo "Đã xảy ra lỗi khi xóa sản phẩm.";
        }
    }
    
    private function uploadImage($file)
    {
        $target_dir = "uploads/";
        if (!is_dir($target_dir)) {
            mkdir($target_dir, 0777, true);
        }
        $target_file = $target_dir . basename($file["name"]);
        $imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
        $check = getimagesize($file["tmp_name"]);
        if ($check === false) {
            throw new Exception("File không phải là hình ảnh.");
        }
        if ($file["size"] > 10 * 1024 * 1024) {
            throw new Exception("Hình ảnh có kích thước quá lớn.");
        }
        if (!in_array($imageFileType, ["jpg", "jpeg", "png", "gif"])) {
            throw new Exception("Chỉ cho phép các định dạng JPG, JPEG, PNG và GIF.");
        }
        if (!move_uploaded_file($file["tmp_name"], $target_file)) {
            throw new Exception("Có lỗi xảy ra khi tải lên hình ảnh.");
        }
        return $target_file;
    }

    public function addToCart($id)
    {
        $product = $this->productModel->getProductById($id);
        if (!$product) {
            echo "Không tìm thấy sản phẩm.";
            return;
        }
        if (!isset($_SESSION['cart'])) {
            $_SESSION['cart'] = [];
        }
        if (isset($_SESSION['cart'][$id])) {
            $_SESSION['cart'][$id]['quantity']++;
        } else {
            $_SESSION['cart'][$id] = [
                'name' => $product->name,
                'price' => $product->price,
                'quantity' => 1,
                'image' => $product->image
            ];
        }
        header('Location: /Product/cart');
    }

    public function cart()
    {
        $cart = isset($_SESSION['cart']) ? $_SESSION['cart'] : [];
        include 'app/views/product/cart.php';
    }

    public function updateCart()
    {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            $id = $_GET['id'] ?? null;
            $change = $_GET['change'] ?? 0;

            if ($id && isset($_SESSION['cart'][$id])) {
                $newQuantity = $_SESSION['cart'][$id]['quantity'] + $change;

                if ($newQuantity > 0) {
                    $_SESSION['cart'][$id]['quantity'] = $newQuantity;
                    echo json_encode(['success' => true]);
                    return;
                } elseif ($newQuantity <= 0) {
                    unset($_SESSION['cart'][$id]);
                    echo json_encode(['success' => true]);
                    return;
                }
            }
            echo json_encode(['success' => false]);
        }
    }

    public function removeFromCart()
    {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            $id = $_GET['id'] ?? null;

            if ($id && isset($_SESSION['cart'][$id])) {
                unset($_SESSION['cart'][$id]);
                echo json_encode(['success' => true]);
                return;
            }
            echo json_encode(['success' => false]);
        }
    }

    public function checkout()
    {
        $cart = isset($_SESSION['cart']) ? $_SESSION['cart'] : [];
        include 'app/views/product/checkout.php';
    }

    public function processCheckout()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $name = $_POST['name'];
            $phone = $_POST['phone'];
            $address = $_POST['address'];
            $email = $_POST['email'] ?? '';

            // Kiểm tra giỏ hàng
            if (!isset($_SESSION['cart']) || empty($_SESSION['cart'])) {
                echo "Giỏ hàng trống.";
                return;
            }

            // Bắt đầu giao dịch
            $this->db->beginTransaction();
            try {
                // Lưu thông tin đơn hàng
                $query = "INSERT INTO orders (name, phone, address, email) VALUES (:name, :phone, :address, :email)";
                $stmt = $this->db->prepare($query);
                $stmt->bindParam(':name', $name);
                $stmt->bindParam(':phone', $phone);
                $stmt->bindParam(':address', $address);
                $stmt->bindParam(':email', $email);
                $stmt->execute();
                
                $order_id = $this->db->lastInsertId();

                // Lưu chi tiết đơn hàng
                $cart = $_SESSION['cart'];
                foreach ($cart as $product_id => $item) {
                    $query = "INSERT INTO order_details (order_id, product_id, quantity, price) VALUES (:order_id, :product_id, :quantity, :price)";
                    $stmt = $this->db->prepare($query);
                    $stmt->bindParam(':order_id', $order_id);
                    $stmt->bindParam(':product_id', $product_id);
                    $stmt->bindParam(':quantity', $item['quantity']);
                    $stmt->bindParam(':price', $item['price']);
                    $stmt->execute();
                }

                // Xóa giỏ hàng sau khi đặt hàng thành công
                unset($_SESSION['cart']);
                
                // Commit giao dịch
                $this->db->commit();
                
                // Chuyển hướng đến trang xác nhận
                header('Location: /Product/orderConfirmation');
            } catch (Exception $e) {
                // Rollback giao dịch nếu có lỗi
                $this->db->rollBack();
                echo "Đã xảy ra lỗi khi xử lý đơn hàng: " . $e->getMessage();
            }
        }
    }

    public function orderConfirmation()
    {
        include 'app/views/product/orderConfirmation.php';
    }
}
