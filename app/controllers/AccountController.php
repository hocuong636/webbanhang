<?php
require_once('app/config/database.php');
require_once('app/models/AccountModel.php');
require_once('app/utils/JWTHandler.php');
class AccountController
{
    private $accountModel;
    private $db;
    private $jwtHandler;
    public function __construct()
    {
        $this->db = (new Database())->getConnection();
        $this->accountModel = new AccountModel($this->db);
        $this->jwtHandler = new JWTHandler();
    }

    public function register()
    {
        include_once 'app/views/account/register.php';
    }

    public function login()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $username = $_POST['username'] ?? '';
            $password = $_POST['password'] ?? '';

            if (empty($username) || empty($password)) {
                $error = "Vui lòng nhập đầy đủ thông tin!";
                include_once 'app/views/account/login.php';
                return;
            }
            
            $user = $this->accountModel->getAccountByUsername($username);
            if ($user && password_verify($password, $user->password)) {
                if (session_status() == PHP_SESSION_NONE) {
                    session_start();
                }
                $_SESSION['username'] = $user->username;
                $_SESSION['role'] = $user->role;
                
                // Tạo JWT token cho API
                $token = $this->jwtHandler->encode([
                    'id' => $user->id,
                    'username' => $user->username,
                    'role' => $user->role
                ]);
                
                // Lưu token vào localStorage qua JavaScript
                echo "<script>
                    localStorage.setItem('jwtToken', '$token');
                    window.location.href = '/Product';
                </script>";
                exit;
            } else {
                $error = "Sai tên đăng nhập hoặc mật khẩu!";
                include_once 'app/views/account/login.php';
            }
        } else {
            include_once 'app/views/account/login.php';
        }
    }

    public function save()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $username = $_POST['username'] ?? '';
            $fullName = $_POST['fullname'] ?? '';
            $password = $_POST['password'] ?? '';
            $confirmPassword = $_POST['confirmpassword'] ?? '';
            $email = $_POST['email'] ?? '';
            $phone = $_POST['phone'] ?? '';
            $address = $_POST['address'] ?? '';
            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                $image = $this->uploadImage($_FILES['image']);
            } else {
                $image = "";
            }
            $role = $_POST['role'] ?? 'user';
            $errors = [];
            if (empty($username)) $errors['username'] = "Vui lòng nhập username!";
            if (empty($fullName)) $errors['fullname'] = "Vui lòng nhập fullname!";
            if (empty($password)) $errors['password'] = "Vui lòng nhập password!";
            if ($password != $confirmPassword) $errors['confirmPass'] = "Mật khẩu và xác nhận chưa khớp!";
            if (!in_array($role, ['admin', 'user'])) $role = 'user';
            if ($this->accountModel->getAccountByUsername($username)) {
                $errors['account'] = "Tài khoản này đã được đăng ký!";
            }
            if (count($errors) > 0) {
                include_once 'app/views/account/register.php';
            } else {
                $result = $this->accountModel->save(
                    $username,
                    $fullName,
                    $password,
                    $role,
                    $email,
                    $phone,
                    $address,
                    $image
                );
            }
            if ($result) {
                header('Location: /account');
                exit;
            }
        }
    }

    public function logout()
    {
        session_start();
        unset($_SESSION['username']);
        unset($_SESSION['role']);
        header('Location: /product');
        exit;
    }

    public function checkLogin()
    {
        header('Content-Type: application/json');
        $data = json_decode(file_get_contents("php://input"), true);
        $username = $data['username'] ?? '';
        $password = $data['password'] ?? '';
        $user = $this->accountModel->getAccountByUserName($username);
        if ($user && password_verify($password, $user->password)) {
            $token = $this->jwtHandler->encode([
                'id' => $user->id,
                'username' => $user->username,
                'role' => $user->role
            ]);
            echo json_encode(['token' => $token]);
        } else {
            http_response_code(401);
            echo json_encode(['message' => 'Invalid credentials']);
        }
    }

    public function index()
    {
        if (!isset($_SESSION['role']) || $_SESSION['role'] !== 'admin') {
            header('Location: /product');
            exit;
        }
        $accounts = $this->accountModel->getList();
        if(isset($_SESSION['role']) || $_SESSION['role'] !== 'admin'){
            include 'app/views/account/list.php';
        } else {
            header('Location: /account/login.php');
            exit;
        }
        
    }
    
    public function add()
    {
        if (!isset($_SESSION['role']) || $_SESSION['role'] !== 'admin') {
            header('Location: /product');
            exit;
        }
        include 'app/views/account/add.php';
    }

    public function delete($username)
    {
        if (!isset($_SESSION['role']) || $_SESSION['role'] !== 'admin') {
            header('Location: /product');
            exit;
        }

        if ($this->accountModel->delete($username)) {
            header('Location: /Account');
        } else {
            header('Location: /Account?error=delete');
        }
        exit;
    }

    public function edit()
    {
        if (!isset($_SESSION['username'])) {
            header('Location: /account/login');
            exit;
        }
        
        $username = $_SESSION['username'];
        $account = $this->accountModel->getAccountByUsername($username);
        
        include_once 'app/views/account/edit.php';
    }
    
    public function editUser($id)
    {
        if (!isset($_SESSION['role']) || $_SESSION['role'] !== 'admin') {
            header('Location: /product');
            exit;
        }

        if (!is_numeric($id)) {
            header('Location: /account');
            exit;
        }
        
        $account = $this->accountModel->getAccountById($id);
        if (!$account) {
            header('Location: /account');
            exit;
        }
        
        include_once 'app/views/account/edit_user.php';
    }

    public function update()
    {
        if (!isset($_SESSION['username'])) {
            header('Location: /account/login');
            exit;
        }

        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $username = $_SESSION['username'];
            $fullName = $_POST['fullname'] ?? '';
            $password = $_POST['password'] ?? '';
            $email = $_POST['email'] ?? '';
            $phone = $_POST['phone'] ?? '';
            $address = $_POST['address'] ?? '';
            $image = $_FILES['image'] ?? null;
            $confirmPassword = $_POST['confirmpassword'] ?? '';

            $errors = [];
            if (empty($fullName)) {
                $errors['fullname'] = "Vui lòng nhập họ tên!";
            }

            if (!empty($password) && $password != $confirmPassword) {
                $errors['confirmPass'] = "Mật khẩu và xác nhận chưa khớp!";
            }

            if (!empty($email) && !filter_var($email, FILTER_VALIDATE_EMAIL)) {
                $errors['email'] = "Email không hợp lệ!";
            }

            if (!empty($phone) && !preg_match('/^[0-9]{10,11}$/', $phone)) {
                $errors['phone'] = "Số điện thoại không hợp lệ!";
            }

            $uploadedImage = null;
            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                try {
                    $check = getimagesize($_FILES['image']["tmp_name"]);
                    if ($check === false) {
                        $errors['image'] = "File không phải là hình ảnh.";
                    }
                    if ($_FILES['image']["size"] > 10 * 1024 * 1024) {
                        $errors['image'] = "Hình ảnh có kích thước quá lớn.";
                    }
                    $imageFileType = strtolower(pathinfo($_FILES['image']["name"], PATHINFO_EXTENSION));
                    if (!in_array($imageFileType, ["jpg", "jpeg", "png", "gif"])) {
                        $errors['image'] = "Chỉ cho phép các định dạng JPG, JPEG, PNG và GIF.";
                    }
                } catch (Exception $e) {
                    $errors['image'] = $e->getMessage();
                }
            }

            if (count($errors) > 0) {
                $account = $this->accountModel->getAccountByUsername($username);
                include_once 'app/views/account/edit.php';
            } else {
                if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                    $uploadedImage = $this->uploadImage($_FILES['image']);
                }
                
                $result = $this->accountModel->update(
                    $username,
                    $fullName,
                    !empty($password) ? $password : null,
                    $email ?? null,
                    $phone ?? null,
                    $address ?? null,
                    $uploadedImage
                );

                if ($result) {
                    header('Location: /account');
                    exit;
                }
            }
        }
    }
    private function uploadImage($file)
    {
        $target_dir = "uploads/";
        if (!is_dir($target_dir)) {
            mkdir($target_dir, 0777, true);
        }
        $imageFileType = strtolower(pathinfo($file["name"], PATHINFO_EXTENSION));
        $target_file = $target_dir . uniqid() . "." . $imageFileType;
        
        if (!move_uploaded_file($file["tmp_name"], $target_file)) {
            throw new Exception("Có lỗi xảy ra khi tải lên hình ảnh.");
        }
        
        return basename($target_file);
    }

    public function updateUser()
    {
        if (!isset($_SESSION['role']) || $_SESSION['role'] !== 'admin') {
            header('Location: /product');
            exit;
        }

        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $id = $_POST['id'] ?? '';
            $username = $_POST['username'] ?? '';
            $fullName = $_POST['fullname'] ?? '';
            $password = $_POST['password'] ?? '';
            $email = $_POST['email'] ?? '';
            $phone = $_POST['phone'] ?? '';
            $address = $_POST['address'] ?? '';
            $confirmPassword = $_POST['confirmpassword'] ?? '';

            $errors = [];
            if (empty($fullName)) {
                $errors['fullname'] = "Vui lòng nhập họ tên!";
            }

            if (!empty($password) && $password != $confirmPassword) {
                $errors['confirmPass'] = "Mật khẩu và xác nhận chưa khớp!";
            }

            if (!empty($email) && !filter_var($email, FILTER_VALIDATE_EMAIL)) {
                $errors['email'] = "Email không hợp lệ!";
            }

            if (!empty($phone) && !preg_match('/^[0-9]{10,11}$/', $phone)) {
                $errors['phone'] = "Số điện thoại không hợp lệ!";
            }

            $uploadedImage = null;
            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                try {
                    $check = getimagesize($_FILES['image']["tmp_name"]);
                    if ($check === false) {
                        $errors['image'] = "File không phải là hình ảnh.";
                    }
                    if ($_FILES['image']["size"] > 10 * 1024 * 1024) {
                        $errors['image'] = "Hình ảnh có kích thước quá lớn.";
                    }
                    $imageFileType = strtolower(pathinfo($_FILES['image']["name"], PATHINFO_EXTENSION));
                    if (!in_array($imageFileType, ["jpg", "jpeg", "png", "gif"])) {
                        $errors['image'] = "Chỉ cho phép các định dạng JPG, JPEG, PNG và GIF.";
                    }
                } catch (Exception $e) {
                    $errors['image'] = $e->getMessage();
                }
            }

            if (!is_numeric($id)) {
                header('Location: /account');
                exit;
            }

            if (count($errors) > 0) {
                $account = $this->accountModel->getAccountById($id);
                include_once 'app/views/account/edit_user.php';
            } else {
                if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                    $uploadedImage = $this->uploadImage($_FILES['image']);
                }

                // Kiểm tra xem user có tồn tại không trước khi update
                $account = $this->accountModel->getAccountById($id);
                if (!$account) {
                    header('Location: /account');
                    exit;
                }
                
                $result = $this->accountModel->update(
                    $account->username, // Sử dụng username từ account được tìm thấy
                    $fullName,
                    !empty($password) ? $password : null,
                    $email ?? null,
                    $phone ?? null,
                    $address ?? null,
                    $uploadedImage
                );

                if ($result) {
                    header('Location: /account');
                    exit;
                }
            }
        }
    }
}
