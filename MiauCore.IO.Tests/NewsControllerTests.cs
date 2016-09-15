//using MiauCore.IO.Domain.Infra;
//using MiauCore.IO.Models;
//using System;
//using Xunit;
//using System.Linq;
//using MiauCore.IO.Domain.Repository;
//using MiauCore.IO.Data;

//namespace MiauCore.IO.Tests
//{
//    public class NewsRepositoryTests : IDisposable
//    {
//        private IGenericRepository<News> _repoNews;
//        private IGenericRepository<Product> _repoProduct;
//        private ApplicationDbContext _context;

//        public NewsRepositoryTests()
//        {
//        }
//        [Fact]
//        public async void Add()
//        {
//            var product = new Product
//            {
//                Name = "Name",
//                Type = "Type"
//            };

//            _repoProduct.Add(product);
//            await _unitOfWork.SaveChanges();

//            var news = new News
//            {
//                BannerImage = "Image",
//                Content = "Content",
//                IsActive = true,
//                PublishedBy = "Meu cu",
//                Title = "Title",
//                ProductId = 1
//            };

//            _repoNews.Add(news);
//            await _unitOfWork.SaveChanges();

//            var allNews = await _repoNews.List();
//            Assert.True(allNews.Any());
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
