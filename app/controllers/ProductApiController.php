<?php
require_once('app/config/database.php');
require_once('app/models/ProductModel.php');
require_once('app/models/CategoryModel.php');
require_once('app/utils/JWTHandler.php');

class ProductApiController
{
    private $productModel;
    private $db;
    private $jwtHandler;
    public function __construct()
    {
        $this->db = (new Database())->getConnection();
        $this->productModel = new ProductModel($this->db);
        $this->jwtHandler = new JWTHandler();
    }

    private function authenticate()
    {
        $headers = apache_request_headers();
        if (isset($headers['Authorization'])) {
            $authHeader = $headers['Authorization'];
            $arr = explode(" ", $authHeader);
            $jwt = $arr[1] ?? null;
            if ($jwt) {
                return $this->jwtHandler->decode($jwt);
            }
        }
        return null;
    }

    private function isAdmin()
    {
        $userData = $this->authenticate();
        return $userData && isset($userData['role']) && $userData['role'] === 'admin';
    }

    public function index()
    {
        $userData = $this->authenticate();
        if ($userData) {
            header('Content-Type: application/json');
            $products = $this->productModel->getProducts();
            echo json_encode($products);
        } else {
            http_response_code(401);
            echo json_encode(['message' => 'Unauthorized']);
        }
    }

    public function show($id)
    {
        header('Content-Type: application/json');
        $product = $this->productModel->getProductById($id);
        if ($product) {
            echo json_encode($product);
        } else {
            http_response_code(404);
            echo json_encode(['message' => 'Product not found']);
        }
    }

    public function store()
    {
        header('Content-Type: application/json');

        if (!$this->isAdmin()) {
            http_response_code(403);
            echo json_encode(['message' => 'Đăng nhập admin đi hẹ hẹ']);
            return;
        }

        $name = $_POST['name'] ?? '';
        $description = $_POST['description'] ?? '';
        $price = $_POST['price'] ?? '';
        $category_id = $_POST['category_id'] ?? null;

        // Xử lý upload ảnh
        $image = null;
        if (isset($_FILES['image']) && $_FILES['image']['error'] === UPLOAD_ERR_OK) {
            $uploadDir = 'uploads/';
            if (!file_exists($uploadDir)) {
                mkdir($uploadDir, 0777, true);
            }

            $imageFileType = strtolower(pathinfo($_FILES['image']['name'], PATHINFO_EXTENSION));
            $newFileName = uniqid() . '.' . $imageFileType;
            $targetFile = $uploadDir . $newFileName;

            if (move_uploaded_file($_FILES['image']['tmp_name'], $targetFile)) {
                $image = $targetFile;
            } else {
                http_response_code(400);
                echo json_encode(['message' => 'Failed to upload image']);
                return;
            }
        }

        $result = $this->productModel->addProduct(
            $name,
            $description,
            $price,
            $category_id,
            $image
        );

        if (is_array($result)) {
            http_response_code(400);
            echo json_encode(['errors' => $result]);
        } else {
            http_response_code(201);
            echo json_encode(['message' => 'Product created successfully']);
        }
    }

    public function update($id)
    {
        header('Content-Type: application/json');

        if (!$this->isAdmin()) {
            http_response_code(403);
            echo json_encode(['message' => 'Đăng nhập admin đi hẹ hẹ']);
            return;
        }

        $name = $_POST['name'] ?? '';
        $description = $_POST['description'] ?? '';
        $price = $_POST['price'] ?? '';
        $category_id = $_POST['category_id'] ?? null;

        // Giữ lại ảnh cũ
        $image = $_POST['existing_image'] ?? '';

        // Xử lý upload ảnh mới nếu có
        if (isset($_FILES['image']) && $_FILES['image']['error'] === UPLOAD_ERR_OK) {
            $uploadDir = 'uploads/';
            if (!file_exists($uploadDir)) {
                mkdir($uploadDir, 0777, true);
            }

            $imageFileType = strtolower(pathinfo($_FILES['image']['name'], PATHINFO_EXTENSION));
            $newFileName = uniqid() . '.' . $imageFileType;
            $targetFile = $uploadDir . $newFileName;

            if (move_uploaded_file($_FILES['image']['tmp_name'], $targetFile)) {
                // Xóa ảnh cũ nếu có
                if ($image && file_exists($image)) {
                    unlink($image);
                }
                $image = $targetFile;
            } else {
                http_response_code(400);
                echo json_encode(['message' => 'Failed to upload image']);
                return;
            }
        }

        $result = $this->productModel->updateProduct(
            $id,
            $name,
            $description,
            $price,
            $category_id,
            $image
        );

        if (is_array($result)) {
            http_response_code(400);
            echo json_encode(['errors' => $result]);
        } else if ($result === true) {
            echo json_encode(['message' => 'Product updated successfully']);
        } else {
            http_response_code(400);
            echo json_encode(['message' => 'Product update failed']);
        }
    }

    public function destroy($id)
    {
        header('Content-Type: application/json');

        if (!$this->isAdmin()) {
            http_response_code(403);
            echo json_encode(['message' => 'Đăng nhập admin đi hẹ hẹ']);
            return;
        }

        // Xóa ảnh trước khi xóa sản phẩm
        $product = $this->productModel->getProductById($id);
        if ($product && $product->image && file_exists($product->image)) {
            unlink($product->image);
        }

        $result = $this->productModel->deleteProduct($id);
        if ($result) {
            echo json_encode(['message' => 'Product deleted successfully']);
        } else {
            http_response_code(400);
            echo json_encode(['message' => 'Product deletion failed']);
        }
    }
}
