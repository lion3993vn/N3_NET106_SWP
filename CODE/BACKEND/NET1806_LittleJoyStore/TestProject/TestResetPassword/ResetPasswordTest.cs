﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NET1806_LittleJoy.API;
using Newtonsoft.Json;
using TestProject.TestSendOTP;
using TestProject.Ultils;

namespace TestProject.TestResetPassword
{
	public class ResetPasswordTest
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
		public static IEnumerable<ResetPasswordEntity> ResetPasswordTestData()
		{
			var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"D:\FPT\SU24\SWT\N3_NET1806_SWP\CODE\BACKEND\NET1806_LittleJoyStore\TestProject\TestResetPassword\ResetPassword.csv"); //nhớ chỉnh file path
			return DataProvider.GetTestData<ResetPasswordEntity>(filePath);
		}


		//viết testcase, gọi hàm ở trên để truyền file csv vô
		[Test, TestCaseSource(nameof(ResetPasswordTestData))]
		public async Task TestResetPassword(ResetPasswordEntity testData)
		{
			var url = "/api/authen/forgot-password";
			var json = JsonConvert.SerializeObject(new 
			{
				email=testData.Email,
				password = testData.Password,
				confirmPassword = testData.ConfirmPassword
			});

			Console.WriteLine($"JSON Payload: {json}");
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(url, content);

			//nếu muốn đọc json từ cái trả về thì

			//// Đọc nội dung phản hồi JSON
			string responseContent = await response.Content.ReadAsStringAsync();

			//// Chuyển đổi nội dung JSON thành đối tượng (nếu cần thiết)
			dynamic responseData = JsonConvert.DeserializeObject(responseContent);

			//// Truy cập thông điệp từ đối tượng JSON
			string message =  responseData.message; // Thay "message" bằng tên trường chứa thông điệp trong JSON của bạn
			TestContext.WriteLine(message);

			Assert.AreEqual((HttpStatusCode)testData.ResponseCode, response.StatusCode,
				$"Failed for Email: {testData.Email}");
		}
	}
}
