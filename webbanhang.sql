-- --------------------------------------------------------
-- Máy chủ:                      127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Phiên bản:           12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for my_store
CREATE DATABASE IF NOT EXISTS `my_store` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `my_store`;

-- Dumping structure for table my_store.account
CREATE TABLE IF NOT EXISTS `account` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `address` text,
  `image` varchar(255) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('admin','user') DEFAULT 'user',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table my_store.account: ~2 rows (approximately)
INSERT INTO `account` (`id`, `username`, `fullname`, `email`, `phone`, `address`, `image`, `password`, `role`) VALUES
	(1, 'hqc', 'hqc', 'abcmnpmx@gmail.com', '0123456787', '123456', '68426d0538d92.jpg', '$2y$10$mPSWoaSfyFd.jOoiGnrdJ.JFcWAi4VAww7NbgCTgzBsXioZEkflKm', 'admin'),
	(2, 'hocuong', 'ho quoc cuong', 'hocuong@gmail.com', '0123456789', '123456,d', '68425303beb8c.jpg', '$2y$10$mPSWoaSfyFd.jOoiGnrdJ.JFcWAi4VAww7NbgCTgzBsXioZEkflKm', 'user');

-- Dumping structure for table my_store.category
CREATE TABLE IF NOT EXISTS `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table my_store.category: ~7 rows (approximately)
INSERT INTO `category` (`id`, `name`, `description`) VALUES
	(18, 'Áo unisex', 'Các loại áo phù hợp cho cả nam và nữ như áo thun basic, áo hoodie.'),
	(19, 'Quần unisex', 'Các loại quần mang phong cách trung tính như jogger, quần thun, quần short unisex.'),
	(20, 'Áo nam', 'Các loại áo dành cho nam giới như áo sơ mi, áo thun, áo khoác.'),
	(21, 'Áo nữ', 'Các loại áo thời trang cho nữ như áo kiểu, áo sơ mi, áo thun.'),
	(22, 'Quần nam', 'Các loại quần dành cho nam như quần jeans, quần tây, quần short.'),
	(24, 'Đầm & Váy', 'Các loại đầm và váy thời trang dành cho nữ.'),
	(26, 'Phụ kiện', 'Phụ kiện thời trang như túi xách, kính mát, nón, dây nịt.');

-- Dumping structure for table my_store.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `address` text NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table my_store.orders: ~3 rows (approximately)
INSERT INTO `orders` (`id`, `name`, `phone`, `address`, `created_at`, `email`) VALUES
	(1, 'Hqc', '0123456789', '123', '2025-05-30 01:50:31', NULL),
	(2, 'hẹ hẹ', '0123456789', '123', '2025-05-30 03:14:14', 'ho@gmail.com'),
	(3, 'Áo unisex', '0123456789', '123', '2025-05-30 04:26:29', 'ho@gmail.com');

-- Dumping structure for table my_store.order_details
CREATE TABLE IF NOT EXISTS `order_details` (
  `id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `order_details_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table my_store.order_details: ~2 rows (approximately)
INSERT INTO `order_details` (`id`, `order_id`, `product_id`, `quantity`, `price`) VALUES
	(3, 2, 2, 2, 180000.00),
	(4, 3, 1, 2, 190000.00);

-- Dumping structure for table my_store.product
CREATE TABLE IF NOT EXISTS `product` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` text,
  `price` decimal(10,2) NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `category_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table my_store.product: ~11 rows (approximately)
INSERT INTO `product` (`id`, `name`, `description`, `price`, `image`, `category_id`) VALUES
	(1, 'Serenity Tee', 'Serenity Tee Dark BLue', 190000.00, 'uploads/Dark-blue-scaled.png', 18),
	(2, 'Basic Baby Tee', 'Basic Baby Tee White', 180000.00, 'uploads/4-1.jpg', 21),
	(3, 'Hindless Layered Sweat Pants', 'Hindless Layered Sweat Pants Grey', 229000.00, 'uploads/Grey-scaled.png', 19),
	(4, 'Pleated Short', 'Pleated Short Black', 220000.00, 'uploads/Black-2-scaled.png', 24),
	(5, 'Metal Hoodie', 'Metal Hoodie Grey', 299000.00, 'uploads/Grey-2.jpg', 18),
	(6, 'Puffer Tote Bag', 'Puffer Tote Bag ', 250002.00, 'uploads/tote-mockup-scaled.png', 21),
	(7, 'Puffer Tote Bag', 'Puffer Tote Bag ', 250.00, 'uploads/tote-mockup-scaled.png', 21),
	(8, 'Metal Hoodie', 'Metal Hoodie Grey', 299000.00, 'uploads/Grey-2.jpg', 18),
	(9, 'Pleated Short', 'Pleated Short Black', 220000.00, 'uploads/Black-2-scaled.png', 24),
	(10, 'Pleated Short', 'Pleated Short Black', 1123.00, 'uploads/Black-2-scaled.png', 24),
	(32, '123', '123', 123.00, 'uploads/6854de20cc5ed.png', 19);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
