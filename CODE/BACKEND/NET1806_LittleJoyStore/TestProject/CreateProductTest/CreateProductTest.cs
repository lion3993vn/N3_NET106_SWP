﻿using Microsoft.AspNetCore.Mvc.Testing;
using NET1806_LittleJoy.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProject.DemoTest;
using TestProject.Ultils;

namespace TestProject.CreateProductTest
{
    internal class CreateProductTest
    {
        //setup (don't change)
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        //setup (don't change)
        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        //setup (don't change)
        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        //provide data (important), nhớ chỉnh entity nữa nha, bật file entity để hiểu
        public static IEnumerable<ProductCsvEntity> CreateProductTestData()
        {
            var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\..\TestProject\CreateProductTest\CreateProductTest.csv"); //nhớ chỉnh file path
            return DataProvider.GetTestData<ProductCsvEntity>(filePath);
        }


        [Test, TestCaseSource(nameof(CreateProductTestData))]
        public async Task TestCreateProduct(ProductCsvEntity testData)
        {
            var url = "/api/product";
            var json = JsonConvert.SerializeObject(new
            {
                Case = testData.Case,
                ProductName = testData.ProductName,
                Price = testData.Price,
                Description = testData.Description,
                Weight = testData.Weight,
                Quantity = testData.Quantity,
                Image = testData.Image,
                AgeId = testData.AgeId,
                OriginId = testData.OriginId,
                BrandId = testData.BrandId,
                CateId = testData.CateId
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);

            // Read JSON response
            string responseContent = await response.Content.ReadAsStringAsync();
            dynamic responseData = JsonConvert.DeserializeObject(responseContent);

            // Verify HTTP status code
            Console.WriteLine($"Test Case: {testData.Case}");
            
            Assert.AreEqual((HttpStatusCode)testData.ResponseCode, response.StatusCode,
                            $"Failed for Product: {testData.ProductName}\nExpected status code: {(HttpStatusCode)testData.ResponseCode}, but got: {response.StatusCode}");

            // Verify error message
           
            Assert.AreEqual(testData.ErrorMessage, (string)responseData.message,
                            $"Failed for Product: {testData.ProductName}\nExpected error message: {testData.ErrorMessage}, but got: {(string)responseData.message}");

            Console.WriteLine($"Expected status code: {(HttpStatusCode)testData.ResponseCode}, Actual status code: {response.StatusCode}");

            Console.WriteLine($"Expected error message: {testData.ErrorMessage}, Actual error message: {(string)responseData.message}");

        }


    }
}