﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Domain;
using NUnit.Framework;

namespace ProductDaoTest
{
    [TestFixture]
    public class ProductDaoTest
    {
        private IProductDao productDao;

        [SetUp]
        public void Init()
        {
            productDao = new ProductDao();
        }

        [Test]
        public void SaveTest()
        {
            var product = new Domain.Product
            {
                ID = Guid.NewGuid(),
                BuyPrice = 10M,
                Code = "ABC123",
                Name = "电脑",
                QuantityPerUnit = "20x1",
                SellPrice = 11M,
                Unit = "台"
            };

            var obj = this.productDao.Save(product);

            Assert.NotNull(obj);
        }

        [Test]
        public void UpdateTest()
        {
            var product = this.productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            product.SellPrice = 12M;
            this.productDao.Update(product);
            Assert.AreEqual(12M, product.SellPrice);
        }

        [Test]
        public void DeleteTest()
        {
            var product = this.productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            var id = product.ID;
            this.productDao.Delete(product);
            Assert.Null(this.productDao.Get(id));
        }

        [Test]
        public void GetTest()
        {
            var product = this.productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            var id = product.ID;
            Assert.NotNull(this.productDao.Get(id));
        }

        [Test]
        public void LoadTest()
        {
            var product = this.productDao.LoadAll().FirstOrDefault();
            Assert.NotNull(product);

            var id = product.ID;
            Assert.NotNull(this.productDao.Get(id));
        }

        [Test]
        public void LoadAllTest()
        {
            var count = this.productDao.LoadAll().Count;
            Assert.True(count > 0);
        }
    }
}
