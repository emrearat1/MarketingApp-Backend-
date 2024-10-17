using Business.Abstracts;
using Business.Request.ShoppingCartRequests;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concreates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contretes
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IShoppingCartDal _ShoppingCartDal;
        private IProductDal _productDal;
        private IShoppingCartProductDal _shoppingCartProductDal;
        
        public ShoppingCartService(IShoppingCartDal shoppingCartDal, IProductDal productDal, IShoppingCartProductDal shoppingCartProductDal)
        {
            _ShoppingCartDal = shoppingCartDal;
            _productDal = productDal;
            _shoppingCartProductDal = shoppingCartProductDal;
        }



        //NOTCALLABLE
        public bool CreateShoppingCart(string Id)
        {
            
            ShoppingCart shoppingCartToAdd = new ShoppingCart
            {
                UserId = Id,
                TotalPrice = 0
            };

            _ShoppingCartDal.Add(shoppingCartToAdd);
            return true;
        }

        public bool DeleteShoppingCart(DeleteShoppingCartRequest request)
        {
            ShoppingCart shoppingCartToDelete = _ShoppingCartDal.Get(x => x.Id == request.Id);
            _ShoppingCartDal.Delete(shoppingCartToDelete);
            return true;
        }

        public ShoppingCart GetById(Guid id)
        {
            return _ShoppingCartDal.Get(x => x.Id == id);
        }

        public List<ShoppingCart> Getlist()
        {
            List<ShoppingCart> shoppingCarts = _ShoppingCartDal.GetList();
            return shoppingCarts;
        }

        public bool UpdateShoppingCart(UpdateShoppingCartRequest request)
        {
            ShoppingCart shoppingCartToUpdate = _ShoppingCartDal.Get(x => x.Id == request.Id);

            shoppingCartToUpdate.Id = request.Id;
            //shoppingCartToUpdate.UserId = request.UserId;  User değiştirilemez
            //shoppingCartToUpdate.Products = request.Products;
            shoppingCartToUpdate.TotalPrice = request.TotalPrice; //ürünlerin toplam fiyatını veren algoritma yaz
            _ShoppingCartDal.Update(shoppingCartToUpdate);
            return true;
        }


        //public bool AddProductToCart(Guid cartId, Guid productId)
        //{
        //    var shoppingCart = _ShoppingCartDal.Get(x => x.Id == cartId);
        //    if (shoppingCart == null)
        //    {
        //        return false; // Shopping cart not found
        //    }

        //    var product = _productDal.Get(x => x.Id == productId);
        //    if (product == null)
        //    {
        //        return false; // Product not found
        //    }

        //    // Check if the product is already in the cart
        //    var existingCartProduct = shoppingCart.ShoppingCartProducts
        //        .FirstOrDefault(scp => scp.ProductId == productId);

        //    if (existingCartProduct != null)
        //    {
        //        // Optionally, update quantity or handle duplicate entry logic
        //        existingCartProduct.Quantity += 1;
        //    }
        //    else
        //    {
        //        // Add the product using the join entity
        //        var shoppingCartProduct = new ShoppingCartProduct
        //        {
        //            ShoppingCartId = cartId,
        //            ProductId = productId,
        //            Quantity = 1, // Start with a default quantity of 1
        //        };

        //        shoppingCart.ShoppingCartProducts.Add(shoppingCartProduct);
        //    }

        //    // Update the total price
        //    shoppingCart.TotalPrice += product.Price;

        //    _ShoppingCartDal.Update(shoppingCart);
        //    return true;
        //}

        public bool AddProductToCart(Guid cartId, Guid productId)
        {
            // Retrieve the shopping cart from the data access layer
            var shoppingCart = _ShoppingCartDal.Get(x => x.Id == cartId);
            if (shoppingCart == null)
            {
                return false; // Shopping cart not found
            }

            // Retrieve the product from the data access layer
            var product = _productDal.Get(x => x.Id == productId);
            if (product == null)
            {
                return false; // Product not found
            }

            // Check if the product is already in the cart
            var existingShoppingCartProduct = _shoppingCartProductDal.Get(x => x.ShoppingCartId == cartId && x.ProductId == productId);
            if (existingShoppingCartProduct != null)
            {
                // Handle if the product is already in the cart (e.g., update quantity)
                Console.WriteLine("Product is already in the cart.");
                return false; // Assuming you want to prevent duplicates
            }

            // Create a new ShoppingCartProduct entity to link the cart and product
            var shoppingCartProduct = new ShoppingCartProduct
            {
                ShoppingCartId = cartId,
                ProductId = productId,
                ShoppingCart = shoppingCart,
                Product = product
            };

            // Add the ShoppingCartProduct to the database
            try
            {
                _shoppingCartProductDal.Add(shoppingCartProduct); // Add the link to the database
                
                // Update the total price of the shopping cart
                shoppingCart.TotalPrice += product.Price;

                // Update the product if needed (e.g., stock decrement if applicable)
                _productDal.Update(product); // Update the product in the database

                // Update the shopping cart in the database
                _ShoppingCartDal.Update(shoppingCart); // Update the shopping cart in the database

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception
                Console.WriteLine($"Concurrency error: {ex.Message}");
                // Ideally, implement logging or user feedback about the conflict
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions, such as database connectivity issues
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public ShoppingCart GetByUserId(string userId)
        {
            return _ShoppingCartDal.Get(x => x.UserId == userId);
        }

        public bool DeleteProductFromCart(Guid cartid, Guid productId)
        {
            try
            {
                // Find the ShoppingCartProduct entity that links the cart and the product
                var shoppingCartProductToDelete = _shoppingCartProductDal.Get(x => x.ShoppingCartId == cartid && x.ProductId == productId);
                _shoppingCartProductDal.Delete(shoppingCartProductToDelete);
                return true;
            }
            catch (Exception ex)
            {
                // Handle other exceptions, such as database connectivity issues
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
    }

