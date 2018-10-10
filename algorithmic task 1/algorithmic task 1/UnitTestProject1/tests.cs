using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithmic_task_1;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Test1_error_no_first_param()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();         
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = -2;
            int expectedMin = list.Count - 1;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "1", "day");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test2_error_no_second_param()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = -2;
            int expectedMin = list.Count - 1;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "day", "2");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test3_simpleTest()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = 12;
            int expectedMin = 5;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "Today", "day");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test4_reverse_simpleTest()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = 12;
            int expectedMin = 5;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "day", "Today");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test5_simpleTest_more_same_words()
        {
            string s = "Today day is very good a sunny day and tomorrow will be very good Today day too day";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = 16;
            int expectedMin = 0;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "day", "Today");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test6_reverse_simpleTest_upperCase()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = 12;
            int expectedMin = 5;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "day", "TODAY");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }

        [TestMethod]
        public void Test7_reverse_simpleTest_lowerCase()
        {
            string s = "Today is very good a sunny day and tomorrow will be very good day too";
            Program p = new Program();
            List<string> list = new List<string>();
            p.FillList(s, list);

            int expectedMax = 12;
            int expectedMin = 5;

            KeyValuePair<int, int> answer = p.SearchMaxAndMinLength(list, "day", "today");

            Assert.AreEqual(expectedMax, answer.Key);
            Assert.AreEqual(expectedMin, answer.Value);
        }
    }
}
