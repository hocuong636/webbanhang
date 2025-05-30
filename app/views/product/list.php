<?php include 'app/views/shares/header.php'; ?>

<div class="container py-5">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h1 class="h2 mb-0">Danh sách sản phẩm</h1>
        <a href="/Product/add" class="btn btn-primary">
            <i class="fas fa-plus-circle mr-2"></i>Thêm sản phẩm mới
        </a>
    </div>

    <div class="row">
        <?php foreach ($products as $product): ?>
            <div class="col-md-4 mb-4">
                <div class="card h-100 shadow-sm hover-effect">
                    <?php if ($product->image): ?>
                        <div class="product-image-wrapper">
                            <img src="/<?php echo $product->image; ?>" 
                                 alt="<?php echo htmlspecialchars($product->name, ENT_QUOTES, 'UTF-8'); ?>" 
                                 class="card-img-top product-image">
                        </div>
                    <?php endif; ?>
                    
                    <div class="card-body">
                        <h5 class="card-title">
                            <a href="/Product/show/<?php echo $product->id; ?>" class="text-dark text-decoration-none">
                                <?php echo htmlspecialchars($product->name, ENT_QUOTES, 'UTF-8'); ?>
                            </a>
                        </h5>
                        
                        <p class="card-text text-muted mb-2">
                            <?php echo htmlspecialchars($product->description, ENT_QUOTES, 'UTF-8'); ?>
                        </p>
                        
                        <div class="product-details">
                            <div class="price mb-2">
                                <strong class="text-primary">
                                    <?php echo number_format($product->price, 0, ',', '.'); ?> VNĐ
                                </strong>
                            </div>
                            
                            <span class="badge badge-info mb-3">
                                <?php echo htmlspecialchars($product->category_name, ENT_QUOTES, 'UTF-8'); ?>
                            </span>
                        </div>
                    </div>

                    <div class="card-footer bg-white border-top-0">
                        <div class="btn-group d-flex" role="group">
                            <a href="/Product/edit/<?php echo $product->id; ?>" 
                               class="btn btn-outline-warning btn-sm flex-grow-1">
                                <i class="fas fa-edit mr-1"></i>Sửa
                            </a>
                            <a href="/Product/delete/<?php echo $product->id; ?>" 
                               class="btn btn-outline-danger btn-sm flex-grow-1"
                               onclick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này?');">
                                <i class="fas fa-trash-alt mr-1"></i>Xóa
                            </a>
                            <a href="/Product/addToCart/<?php echo $product->id; ?>" 
                               class="btn btn-outline-primary btn-sm flex-grow-1">
                                <i class="fas fa-cart-plus mr-1"></i>Thêm vào giỏ
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        <?php endforeach; ?>
    </div>
</div>

<style>
.product-image-wrapper {
    height: 200px;
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
}

.product-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
    transition: transform 0.3s ease;
}

.hover-effect {
    transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.hover-effect:hover {
    transform: translateY(-5px);
    box-shadow: 0 4px 15px rgba(0,0,0,0.1) !important;
}

.hover-effect:hover .product-image {
    transform: scale(1.05);
}

.card {
    border: none;
    border-radius: 8px;
}

.card-title {
    font-weight: 500;
    margin-bottom: 1rem;
}

.card-text {
    font-size: 0.9rem;
    overflow: hidden;
    display: -webkit-box;
    -webkit-line-clamp: 3;
    -webkit-box-orient: vertical;
}

.badge {
    font-weight: 500;
    padding: 0.5em 1em;
}

.btn-group .btn {
    border-radius: 4px;
    margin: 0 2px;
}

.price {
    font-size: 1.1rem;
}
</style>

<?php include 'app/views/shares/footer.php'; ?>