using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWarehouse.Model;
using MyWarehouse.Repositories;

namespace MyWarehouse.Controllers
{
    [EnableCors("AnotherPolicy")]
    [Produces("application/json")]
    [Route("Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            //PopulateProducts();
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
            //return new string[] { "value1", "value2" };
        }
        [EnableCors("Policy1")]
        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);
            //return "value";
        }
        // POST: /Product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {

            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.InsertProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (product != null)
            {
                Product db_prod = _productRepository.GetProductById(id);
                using (var scope = new TransactionScope())
                {
                    db_prod.Name = product.Name;
                    db_prod.Description = product.Description;
                    db_prod.Amount = product.Amount;
                    db_prod.CategoryId = product.CategoryId;
                    db_prod.Price = product.Price;

                    _productRepository.UpdateProduct(db_prod);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }



        private void PopulateProducts()
        {
            var products = _productRepository;

            // add product========================================================
            Product p1 = new Product();
            p1.CategoryId = 1;
            p1.Name = "Apple iPhone 12 64GB Blue";
            p1.Description = "Operatsion sistema versiyasi: iOS 14 Doimiy xotira hajmi: 64GB Face ID Datchigi: Mavjud";
            p1.Price = 15273000;
            p1.Amount = 5;
            products.InsertProduct(p1);

            Product p2 = new Product();
            p2.CategoryId = 1;
            p2.Name = "Apple iPhone 12 Pro 128GB Silver";
            p2.Description = "Operatsion sistema versiyasi: iOS 14 Doimiy xotira hajmi: 128GB Face ID Datchigi: Mavjud";
            p2.Price = 17871000;
            p2.Amount = 20;
            products.InsertProduct(p2);

            Product p3 = new Product();
            p3.CategoryId = 1;
            p3.Name = "Xiaomi Redmi Note 9 3/64GB, Onyx Black";
            p3.Description = "Kafolat muddati (oy): 1 Operatsion sistema versiyasi: Android 10.0 Doimiy xotira hajmi: 64GB";
            p3.Price = 2234000;
            p3.Amount = 35;
            products.InsertProduct(p3);

            Product p4 = new Product();
            p4.CategoryId = 1;
            p4.Name = "Samsung Galaxy A01 Core 1/16GB, Red A013";
            p4.Description = "Kafolat muddati (oy): 12 Operatsion sistema versiyasi: Android 10.0 Doimiy xotira hajmi: 16GB Ishlab chiqaruvchi: Vetnam";
            p4.Price = 1153000;
            p4.Amount = 23;
            products.InsertProduct(p4);

            Product p5 = new Product();
            p5.CategoryId = 1;
            p5.Name = "Samsung Galaxy Note20 Ultra 256GB, Mystic Bronze";
            p5.Description = "Operatsion sistema versiyasi: Android 10.0 Doimiy xotira hajmi: 256GB Face ID Datchigi: Mavjud";
            p5.Price = 12468000;
            p5.Amount = 6;
            products.InsertProduct(p5);

            Product p6 = new Product();
            p6.CategoryId = 2;
            p6.Name = "Asus S432F";
            p6.Description = "Asus S432F i5-8265 DDR4 8GB/512GB SSD Windows 10 14";
            p6.Price = 9060000;
            p6.Amount = 14;
            products.InsertProduct(p6);

            Product p7 = new Product();
            p7.CategoryId = 2;
            p7.Name = "Acer Aspire 3 ";
            p7.Description = "Acer Aspire 3 i3-1005G1 DDR4 4GB/1TB HDD 2GB VGA (A315-56-3104)";
            p7.Price = 5559000;
            p7.Amount = 18;
            products.InsertProduct(p7);

            Product p8 = new Product();
            p8.CategoryId = 2;
            p8.Name = "Acer Predator";
            p8.Description = "Acer i7-10750 DDR4 24GB/1TB SSD 8GB PH315-53-79BL";
            p8.Price = 19741000;
            p8.Amount = 6;
            products.InsertProduct(p8);

            Product p9 = new Product();
            p9.CategoryId = 2;
            p9.Name = "Lenovo Y540-15IRH ";
            p9.Description = "Lenovo Y540-15IRH i5-9300H DDR4 16GB/1TB HDD+128GB SSD 4GB GTX 1650";
            p9.Price = 10589000;
            p9.Amount = 5;
            products.InsertProduct(p9);

            Product p0 = new Product();
            p0.CategoryId = 2;
            p0.Name = "Apple MacBook Air 13";
            p0.Description = "Apple MacBook Air 13 Mid 2017, Intel Core i5, 13.3, 8GB DDR3, 128GB SSD, Intel HD Graphics 6000";
            p0.Price = 11429000;
            p0.Amount = 5;
            products.InsertProduct(p0);

            Product pp1 = new Product();
            pp1.CategoryId = 3;
            pp1.Name = "Apple Watch SE GPS 40mm Aluminum Case with Sport Band Black";
            pp1.Description = "Braslet materiali: alyuminiy/silikon";
            pp1.Price = 4727000;
            pp1.Amount = 30;
            products.InsertProduct(pp1);

            Product pp2 = new Product();
            pp2.CategoryId = 3;
            pp2.Name = "Apple Watch 6 40mm Aluminum Case, Black";
            pp2.Description = "Braslet materiali: alyuminiy/silikon";
            pp2.Price = 5230000;
            pp2.Amount = 80;
            products.InsertProduct(pp2);

            Product pp3 = new Product();
            pp3.CategoryId = 3;
            pp3.Name = "Asus Vivowatch SP (HC-A05)";
            pp3.Description = "Braslet materiali: 22 mm (silikon) Diagonali: 1.34";
            pp3.Price = 3013000;
            pp3.Amount = 40;
            products.InsertProduct(pp3);

            Product pp4 = new Product();
            pp4.CategoryId = 3;
            pp4.Name = "Samsung Galaxy Watch3 45mm Black";
            pp4.Description = "Braslet materiali: Charm Diagonali: 1.4";
            pp4.Price = 3844000;
            pp4.Amount = 100;
            products.InsertProduct(pp4);

            Product pp5 = new Product();
            pp5.CategoryId = 3;
            pp5.Name = "Xiaomi Amazfit Bip S";
            pp5.Description = "Latest smart watch of Xiamomi Company";
            pp5.Price = 707000;
            pp5.Amount = 100;
            products.InsertProduct(pp5);

            Product pp6 = new Product();
            pp6.CategoryId = 1;
            pp6.Name = "Samsung Galaxy A51 4/64GB, Haze Crush Silver A515";
            pp6.Description = "Kafolat muddati (oy): 12 Operatsion sistema versiyasi: Android 10.0 Doimiy xotira hajmi: 64GB Face ID Datchigi: Mavjud";
            pp6.Price = 3169000;
            pp6.Amount = 39;
            products.InsertProduct(pp6);

            Product pp7 = new Product();
            pp7.CategoryId = 1;
            pp7.Name = "Huawei Y8p 4/128GB, Breathing Crystal";
            pp7.Description = "Operatsion sistema versiyasi: Android 10.0 Doimiy xotira hajmi: 128GB";
            pp7.Price = 2494000;
            pp7.Amount = 55;
            products.InsertProduct(pp7);

            Product pp8 = new Product();
            pp8.CategoryId = 1;
            pp8.Name = "BQ 5730L Magic C 2/16GB, Ultra Violet";
            pp8.Description = "Kafolat muddati (oy): 12 Operatsion sistema versiyasi: Android 9.0(Pie) Doimiy xotira hajmi: 16GB";
            pp8.Price = 1206000;
            pp8.Amount = 100;
            products.InsertProduct(pp8);

            Product pp9 = new Product();
            pp9.CategoryId = 1;
            pp9.Name = "Xiaomi Redmi Note 8 Pro 6/128GB, Pearl White (Global)";
            pp9.Description = "Kafolat muddati (oy): 1 Operatsion sistema versiyasi: Android 9.0(Pie) Doimiy xotira hajmi: 128GB";
            pp9.Price = 2701000;
            pp9.Amount = 100;
            products.InsertProduct(pp9);

            Product pp0 = new Product();
            pp0.CategoryId = 1;
            pp0.Name = "Huawei P Smart Z 4/64GB, Blue";
            pp0.Description = "Kafolat muddati (oy): 12 Operatsion sistema versiyasi: Android 9.0 Doimiy xotira hajmi: 64GB";
            pp0.Price = 20182000;
            pp0.Amount = 80;
            products.InsertProduct(pp0);

        }
    }
}
