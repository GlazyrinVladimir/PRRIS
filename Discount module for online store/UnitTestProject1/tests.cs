using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountModuleForOnlineStore;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        void AddRules(ref Shop shop)
        {
            List<Product> productsInDiscount = new List<Product>();
            productsInDiscount.Add(A);
            productsInDiscount.Add(B);
            PercentType discount = new PercentType(10);
            List<Product> productsNotInDiscount = new List<Product>();
            shop.AddRule(new RuleBuyItAll(discount, productsInDiscount, productsNotInDiscount));

            List<Product> productsInDiscount2 = new List<Product>();
            productsInDiscount2.Add(D);
            productsInDiscount2.Add(E);
            PercentType discount2 = new PercentType(5);
            DiscountModuleForOnlineStore.ValueType discount4 = new DiscountModuleForOnlineStore.ValueType(10);
            shop.AddRule(new RuleBuyItAll(discount4, productsInDiscount2, productsNotInDiscount));

            List<Product> productsInDiscount3 = new List<Product>();
            productsInDiscount3.Add(E);
            productsInDiscount3.Add(F);
            productsInDiscount3.Add(G);
            shop.AddRule(new RuleBuyItAll(discount2, productsInDiscount3, productsNotInDiscount));

            List<Product> productsInDiscount4 = new List<Product>();
            List<Product> productsNotInDiscount2 = new List<Product>();
            productsInDiscount4.Add(A);
            productsInDiscount4.Add(K);
            productsNotInDiscount2.Add(A);
            shop.AddRule(new RuleBuyItAll(discount2, productsInDiscount4, productsNotInDiscount2));

            List<Product> productsInDiscount5 = new List<Product>();
            List<Product> productsNotInDiscount3 = new List<Product>();
            productsInDiscount5.Add(A);
            productsInDiscount5.Add(L);
            productsNotInDiscount3.Add(A);
            shop.AddRule(new RuleBuyItAll(discount2, productsInDiscount5, productsNotInDiscount3));

            List<Product> productsInDiscount6 = new List<Product>();
            List<Product> productsNotInDiscount4 = new List<Product>();
            productsInDiscount6.Add(A);
            productsInDiscount6.Add(M);
            productsNotInDiscount4.Add(A);
            shop.AddRule(new RuleBuyItAll(discount2, productsInDiscount6, productsNotInDiscount4));

            List<Product> productsNotInDiscount5 = new List<Product>();
            productsNotInDiscount5.Add(A);
            productsNotInDiscount5.Add(C);

            int amount = 3;
            shop.AddRule(new RuleBuyMoreThan(discount2, productsNotInDiscount5, amount));

            amount = 4;
            shop.AddRule(new RuleBuyMoreThan(discount, productsNotInDiscount5, amount));

            amount = 5;
            PercentType discount3 = new PercentType(20);
            shop.AddRule(new RuleBuyMoreThan(discount3, productsNotInDiscount5, amount));
        }

        [TestMethod]
        public void Test_SimpleShoppingCartWithoutDiscountProducts()
        {
            float expected = 13;

            Shop shop = new Shop();
            AddRules(ref shop);         

            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(C);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule1_AB_Percent()
        {
            float expected = 27;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(B);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule2_DE_Value()
        {
            float expected = 25.0f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(D);
            shop.AddProductToShoppingCart(E);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule3_EFG_more3_Percent()
        {
            float expected = 66.79f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(E);
            shop.AddProductToShoppingCart(F);
            shop.AddProductToShoppingCart(G);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule4_AKLM_more4_Percent()
        {
            float expected = 66.84f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);
            shop.AddProductToShoppingCart(L);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule5_AK_Percent()
        {
            float expected = 45.15f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule6_AL_Percent()
        {
            float expected = 20.45f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(L);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule7_AM_Percent()
        {
            float expected = 26.15f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule8_AKM_more3_Percent()
        {
            float expected = 59.54f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(A);
            shop.AddProductToShoppingCart(K);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule9_more5_Percent()
        {
            float expected = 64.6f;

            Shop shop = new Shop();
            AddRules(ref shop);
            shop.AddProductToShoppingCart(B);
            shop.AddProductToShoppingCart(C);
            shop.AddProductToShoppingCart(E);
            shop.AddProductToShoppingCart(F);
            shop.AddProductToShoppingCart(M);

            float actual = shop.GetSummaryPrice();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRule10_AABBA_more5_Percent()
        {
            float expected = 56.8f;

            Shop shop = new Shop();
            AddRules(ref shop);
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
