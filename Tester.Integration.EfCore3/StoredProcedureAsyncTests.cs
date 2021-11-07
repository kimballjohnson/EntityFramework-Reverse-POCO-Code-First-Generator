﻿using EntityFramework_Reverse_POCO_Generator;
using NUnit.Framework;

namespace Tester.Integration.EfCore3
{
    [TestFixture]
    [Category(Constants.DbType.SqlServer)]
    public class StoredProcedureAsyncTests
    {
        private MyDbContext SUT;

        [SetUp]
        public void SetUp()
        {
            SUT = ConfigurationExtensions.CreateMyDbContext();
        }

        [Test]
        [TestCase("ALFKI")]
        [TestCase("FAMIA")]
        [TestCase("WOLZA")]
        public void CustOrderHist(string customerId)
        {
            Assert.IsNotNull(SUT);
            var data = SUT.CustOrderHist(customerId);
            var asyncData = SUT.CustOrderHistAsync(customerId).Result;

            Assert.IsNotNull(data);
            Assert.IsNotNull(asyncData);
            Assert.AreEqual(data.Count, asyncData.Count);

            for (var n = 0; n < data.Count; ++n)
            {
                var dataItem = data[n];
                var asyncItem = asyncData[n];

                Assert.AreEqual(dataItem.ProductName, asyncItem.ProductName); 
                Assert.AreEqual(dataItem.Total, asyncItem.Total); 
            }
        }
    }
}