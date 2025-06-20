<?php
class ProductModel
{
    private $conn;
    private $table_name = "product";
    public function __construct($db)
    {
        $this->conn = $db;
    }
    public function getProducts($search = '', $sort = '', $category_id = null)
    {
        $query = "SELECT p.id, p.name, p.description, p.price, p.image, c.name as category_name
                FROM " . $this->table_name . " p
                LEFT JOIN category c ON p.category_id = c.id
                WHERE 1=1";
        
        if (!empty($search)) {
            $query .= " AND (p.name LIKE :search OR p.description LIKE :search)";
        }
        
        if (!empty($category_id)) {
            $query .= " AND p.category_id = :category_id";
        }

        switch($sort) {
            case 'price_asc':
                $query .= " ORDER BY p.price ASC";
                break;
            case 'price_desc':
                $query .= " ORDER BY p.price DESC";
                break;
            case 'name_asc':
                $query .= " ORDER BY p.name ASC";
                break;
            case 'name_desc':
                $query .= " ORDER BY p.name DESC";
                break;
            default:
                $query .= " ORDER BY p.id DESC";
        }
        $stmt = $this->conn->prepare($query);
        
        if (!empty($search)) {
            $searchParam = "%{$search}%";
            $stmt->bindParam(':search', $searchParam);
        }
        
        if (!empty($category_id)) {
            $stmt->bindParam(':category_id', $category_id);
        }
        
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_OBJ);
        return $result;
    }
    public function getProductById($id)
    {
        $query = "SELECT p.*, c.name as category_name
                FROM " . $this->table_name . " p
                LEFT JOIN category c ON p.category_id = c.id
                WHERE p.id = :id";
        $stmt = $this->conn->prepare($query);
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_OBJ);
        return $result;
    }
    public function addProduct($name, $description, $price, $category_id = null, $image = null)
    {
        $errors = [];
        if (empty($name)) {
            $errors['name'] = 'Tên sản phẩm không được để trống';
        }
        if (empty($description)) {
            $errors['description'] = 'Mô tả không được để trống';
        }
        if (!is_numeric($price) || $price < 0) {
            $errors['price'] = 'Giá sản phẩm không hợp lệ';
        }
        if (count($errors) > 0) {
            return $errors;
        }

        // Get first category as default if category_id is null
        if ($category_id === null) {
            $query = "SELECT id FROM category ORDER BY id ASC LIMIT 1";
            $stmt = $this->conn->prepare($query);
            $stmt->execute();
            $result = $stmt->fetch(PDO::FETCH_OBJ);
            if ($result) {
                $category_id = $result->id;
            } else {
                // Insert a default category if none exists
                $query = "INSERT INTO category (name) VALUES ('Chung')";
                $this->conn->exec($query);
                $category_id = $this->conn->lastInsertId();
            }
        }
        $query = "INSERT INTO " . $this->table_name . " (name, description, price,
category_id, image) VALUES (:name, :description, :price, :category_id, :image)";
        $stmt = $this->conn->prepare($query);
        $name = htmlspecialchars(strip_tags($name));
        $description = htmlspecialchars(strip_tags($description));
        $price = htmlspecialchars(strip_tags($price));
        $category_id = htmlspecialchars(strip_tags($category_id));
        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':price', $price);
        $stmt->bindParam(':category_id', $category_id);
        $stmt->bindParam(':image', $image);
        if ($stmt->execute()) {
            return true;
        }
        return false;
    }
    public function updateProduct(
        $id,
        $name,
        $description,
        $price,
        $category_id = null,
        $image = null
    ) {
        $errors = [];
        if (empty($name)) {
            $errors['name'] = 'Tên sản phẩm không được để trống';
        }
        if (empty($description)) {
            $errors['description'] = 'Mô tả không được để trống';
        }
        if (!is_numeric($price) || $price < 0) {
            $errors['price'] = 'Giá sản phẩm không hợp lệ';
        }
        if (count($errors) > 0) {
            return $errors;
        }

        // Get first category as default if category_id is null
        if ($category_id === null) {
            $query = "SELECT id FROM category ORDER BY id ASC LIMIT 1";
            $stmt = $this->conn->prepare($query);
            $stmt->execute();
            $result = $stmt->fetch(PDO::FETCH_OBJ);
            if ($result) {
                $category_id = $result->id;
            } else {
                // Insert a default category if none exists
                $query = "INSERT INTO category (name) VALUES ('Chung')";
                $this->conn->exec($query);
                $category_id = $this->conn->lastInsertId();
            }
        }

        $query = "UPDATE " . $this->table_name . " SET name=:name,
description=:description, price=:price, category_id=:category_id";

        if ($image !== null) {
            $query .= ", image=:image";
        }
        
        $query .= " WHERE id=:id";
        
        $stmt = $this->conn->prepare($query);
        
        $name = htmlspecialchars(strip_tags($name));
        $description = htmlspecialchars(strip_tags($description));
        $price = htmlspecialchars(strip_tags($price));
        $category_id = htmlspecialchars(strip_tags($category_id));
        
        $stmt->bindParam(':id', $id);
        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':price', $price);
        $stmt->bindParam(':category_id', $category_id);
        
        if ($image !== null) {
            $stmt->bindParam(':image', $image);
        }

        if ($stmt->execute()) {
            return true;
        }
        return false;
    }
    public function deleteProduct($id)
    {
        $query = "DELETE FROM " . $this->table_name . " WHERE id=:id";
        $stmt = $this->conn->prepare($query);
        $stmt->bindParam(':id', $id);
        if ($stmt->execute()) {
            return true;
        }
        return false;
    }
}
