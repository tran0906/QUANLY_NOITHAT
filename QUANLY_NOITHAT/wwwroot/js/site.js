// Shopping Cart Management
let cart = [];

// Load cart from localStorage
function loadCart() {
    const savedCart = localStorage.getItem('cart');
    if (savedCart) {
        cart = JSON.parse(savedCart);
        updateCartBadge();
    }
}

// Save cart to localStorage
function saveCart() {
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartBadge();
}

// Update cart badge
function updateCartBadge() {
    const badge = document.querySelector('.cart-badge');
    if (badge) {
        const totalItems = cart.reduce((sum, item) => sum + item.quantity, 0);
        badge.textContent = totalItems;
    }
}

// Add to cart
function addToCart(productId, productName, price, image) {
    const existingItem = cart.find(item => item.id === productId);
    
    if (existingItem) {
        existingItem.quantity++;
    } else {
        cart.push({
            id: productId,
            name: productName,
            price: price,
            image: image || '/images/placeholder.jpg',
            quantity: 1
        });
    }
    
    saveCart();
    showNotification('Đã thêm sản phẩm vào giỏ hàng!');
}

// Add to cart and redirect
function addToCartAndRedirect(button) {
    const productId = button.getAttribute('data-product-id');
    const productName = button.getAttribute('data-product-name');
    const price = parseInt(button.getAttribute('data-product-price'));
    
    addToCart(productId, productName, price);
    
    // Redirect to cart after short delay
    setTimeout(function() {
        window.location.href = '/GioHang';
    }, 500);
}

// Show notification
function showNotification(message) {
    // Create toast notification
    const toast = document.createElement('div');
    toast.className = 'toast-notification';
    toast.innerHTML = `
        <i class="fas fa-check-circle"></i>
        <span>${message}</span>
    `;
    toast.style.cssText = `
        position: fixed;
        top: 20px;
        right: 20px;
        background: #27ae60;
        color: white;
        padding: 15px 25px;
        border-radius: 5px;
        box-shadow: 0 5px 15px rgba(0,0,0,0.3);
        z-index: 9999;
        animation: slideIn 0.3s ease;
    `;
    
    document.body.appendChild(toast);
    
    setTimeout(function() {
        toast.style.animation = 'slideOut 0.3s ease';
        setTimeout(function() {
            document.body.removeChild(toast);
        }, 300);
    }, 2000);
}

// Submit order
function submitOrder() {
    const termsCheckbox = document.getElementById('terms');
    if (!termsCheckbox.checked) {
        alert('Vui lòng đồng ý với điều khoản và điều kiện');
        return;
    }
    
    // Validate form fields
    const form = document.querySelector('form');
    if (!form.checkValidity()) {
        form.reportValidity();
        return;
    }
    
    // Clear cart and redirect
    localStorage.removeItem('cart');
    alert('Đặt hàng thành công! Cảm ơn bạn đã mua hàng.');
    window.location.href = '/Home/Index';
}

// Initialize on page load
document.addEventListener('DOMContentLoaded', function() {
    loadCart();
    
    // Menu dropdown click handling
    initMenuDropdown();
    
    // Add event listeners for "Add to Cart" buttons
    document.querySelectorAll('.btn-add-cart').forEach(button => {
        button.addEventListener('click', function(e) {
            e.preventDefault();
            
            // Get product info from data attributes
            const productId = this.getAttribute('data-product-id');
            const productName = this.getAttribute('data-product-name');
            const price = parseInt(this.getAttribute('data-product-price'));
            
            if (productId && productName && price) {
                addToCart(productId, productName, price);
            }
        });
    });
    
    // Quantity controls
    document.querySelectorAll('.input-group').forEach(group => {
        const minusBtn = group.querySelector('button:first-child');
        const plusBtn = group.querySelector('button:last-child');
        const input = group.querySelector('input[type="text"]');
        
        if (minusBtn && plusBtn && input) {
            minusBtn.addEventListener('click', function() {
                let value = parseInt(input.value) || 1;
                if (value > 1) {
                    input.value = value - 1;
                }
            });
            
            plusBtn.addEventListener('click', function() {
                let value = parseInt(input.value) || 1;
                input.value = value + 1;
            });
        }
    });
});

// Add CSS animations
const style = document.createElement('style');
style.textContent = `
    @keyframes slideIn {
        from {
            transform: translateX(400px);
            opacity: 0;
        }
        to {
            transform: translateX(0);
            opacity: 1;
        }
    }
    
    @keyframes slideOut {
        from {
            transform: translateX(0);
            opacity: 1;
        }
        to {
            transform: translateX(400px);
            opacity: 0;
        }
    }
`;
document.head.appendChild(style);


// Menu Dropdown Click Handling
function initMenuDropdown() {
    // Mega Menu Hover Handling
    initMegaMenu();
}

// Mega Menu Hover Handling
function initMegaMenu() {
    // Cột 1: Hover vào danh mục chính -> hiển thị danh mục con tương ứng
    const categoryItems = document.querySelectorAll('.mega-category-item');
    categoryItems.forEach(function(item) {
        item.addEventListener('mouseenter', function() {
            const category = this.getAttribute('data-category');
            
            // Remove active từ tất cả category items
            categoryItems.forEach(function(el) {
                el.classList.remove('active');
            });
            this.classList.add('active');
            
            // Ẩn tất cả subcategory lists
            document.querySelectorAll('.mega-subcategory-list').forEach(function(list) {
                list.style.display = 'none';
            });
            
            // Hiển thị subcategory list tương ứng
            const targetList = document.querySelector('.mega-subcategory-list[data-parent="' + category + '"]');
            if (targetList) {
                targetList.style.display = 'block';
                // Set active cho item đầu tiên
                const firstSubItem = targetList.querySelector('.mega-sub-item');
                if (firstSubItem) {
                    document.querySelectorAll('.mega-sub-item').forEach(function(el) {
                        el.classList.remove('active');
                    });
                    firstSubItem.classList.add('active');
                }
            }
        });
    });
    
    // Cột 2: Hover vào danh mục con -> hiển thị chi tiết tương ứng
    const subItems = document.querySelectorAll('.mega-sub-item');
    subItems.forEach(function(item) {
        item.addEventListener('mouseenter', function() {
            const subCategory = this.getAttribute('data-sub');
            
            // Remove active từ tất cả sub items trong cùng list
            const parentList = this.closest('.mega-subcategory-list');
            if (parentList) {
                parentList.querySelectorAll('.mega-sub-item').forEach(function(el) {
                    el.classList.remove('active');
                });
            }
            this.classList.add('active');
            
            // Ẩn tất cả detail lists
            document.querySelectorAll('.mega-detail-list').forEach(function(list) {
                list.style.display = 'none';
            });
            
            // Hiển thị detail list tương ứng
            if (subCategory) {
                const targetDetail = document.querySelector('.mega-detail-list[data-detail="' + subCategory + '"]');
                if (targetDetail) {
                    targetDetail.style.display = 'block';
                }
            }
        });
    });
}
