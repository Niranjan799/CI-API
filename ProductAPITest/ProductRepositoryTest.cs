﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI.Model;
using ProductWebAPI.Repository;

namespace ProductAPITest
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void GetProductById_ShouldReturnMatchingProduct()
        {
            // Arrange
            var repository = new ProductRepository();

            // Act
            var result = repository.GetProductById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ProductId);
            Assert.Equal("Watch", result.ProductName);

        }

        [Fact]
        public void AddProduct_ShouldAddProductSuccessfully()
        {
            // Arrange
            var repository = new ProductRepository();
            var newProduct = new Product { ProductName = "NewProduct", ProductBrand = "Brand", ProductQuantity = 5, ProductPrice = 345678 };

            // Act
            repository.AddProduct(newProduct);

            // Assert
            var addedProduct = repository.GetProductById(newProduct.ProductId);
            Assert.NotNull(addedProduct);
            Assert.Equal(newProduct.ProductName, addedProduct.ProductName);

        }

        [Fact]
        public void UpdateProduct_ShouldUpdateProductSuccessfully()
        {
            // Arrange
            var repository = new ProductRepository();
            var updatedProduct = new Product { ProductId = 1, ProductName = "UpdatedName", ProductBrand = "UpdatedBrand", ProductQuantity = 15, ProductPrice = 1234567 };

            // Act
            repository.UpdateProduct(updatedProduct);

            // Assert
            var productAfterUpdate = repository.GetProductById(updatedProduct.ProductId);
            Assert.NotNull(productAfterUpdate);
            Assert.Equal(updatedProduct.ProductName, productAfterUpdate.ProductName);

        }

        [Fact]
        public void DeleteProduct_ShouldDeleteProductSuccessfully()
        {
            // Arrange
            var repository = new ProductRepository();
            var productIdToDelete = 2;

            // Act
            repository.DeleteProduct(productIdToDelete);

            // Assert
            var deletedProduct = repository.GetProductById(productIdToDelete);
            Assert.Null(deletedProduct);
        }

    }
}
