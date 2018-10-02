using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountModuleForOnlineStore;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test_SimpleShoppingCartWithoutDiscountProducts()
        {
            float expected = 13;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(C);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule1_AB()
        {
            float expected = 27;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(B);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule2_DE()
        {
            float expected = 42.75f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(D);
            shop.AddProductToShoppingCart(E);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule3_EFG_more3()
        {
            float expected = 66.78f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(E);
            shop.AddProductToShoppingCart(F);
            shop.AddProductToShoppingCart(G);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule4_AKLM_more4()
        {
            float expected = 66.84f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);
            shop.AddProductToShoppingCart(L);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule5_AK()
        {
            float expected = 45.15f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule6_AL()
        {
            float expected = 20.45f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(L);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule7_AM()
        {
            float expected = 26.15f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule8_AKM_more3()
        {
            float expected = 59.54f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule9_more5()
        {
            float expected = 64.6f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(B);
            shop.AddProductToShoppingCart(C);
            shop.AddProductToShoppingCart(E);
            shop.AddProductToShoppingCart(F);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule10_AABBA_more5()
        {
            float expected = 56.8f;

            Shop shop = new Shop();
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(B);
            shop.AddProductToShoppingCart(B);
            shop.AddProductToShoppingCart(A);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        Product A = new Product("A", 10);
        Product B = new Product("B", 20);
        Product C = new Product("C", 3);
        Product D = new Product("D", 30);
        Product E = new Product("E", 15);
        Product F = new Product("F", 25);
        Product G = new Product("G", 34);
        Product K = new Product("K", 37);
        Product L = new Product("L", 11);
        Product M = new Product("M", 17);
    }
}
