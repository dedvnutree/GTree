using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Assignment2
{
    public class Tests
    {
        [Test]
        public void SingleNodeInsertTest1()
        {
            var tree = Gtree.Create(4, 1);
            var a = tree.ToArray();
            var actual = String.Join(", ", tree.ToArray());
            var expected = "1";
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void DoubleNodeInsertTest1()
        {
            var tree = Gtree.Create(4, 1);
            tree.Insert(1, new List<int>{5,9,2});
            var actualArray = tree.ToArray();
            var actual = String.Join(", ",  actualArray);
            var expected = "1, 5, 9, 2";
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TripleNodeInsertTest2()
        {
            var tree = Gtree.Create(4, 1);
            tree.Insert(1, new List<int>{2,3,4});
            tree.Insert(2, new List<int>{5,6,7});
            tree.Insert(4, 15);
            var actualArray = tree.ToArray();
            var actual = String.Join(", ",  actualArray);
            var expected = "1, 2, 5, 6, 7, 3, 4, 15";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseTest()
        {
            var text = "3\n" +
                       "1\n" +
                       "1 8 22 29\n" +
                       "8 3 5 17\n" +
                       "3 16 19 32\n" +
                       "19 10 15\n" +
                       "22 42\n" +
                       "42 13 18 49\n" +
                       "29 4 9";
            
            var tree =Gtree.Parse<int>(text.Split('\n'));
            var text1 = text.Replace(" ", "");
            var treeString = GtreeTextHelper.ToStringWithM(tree);
            var actual =  treeString.Replace(" ", "").Trim();
            Assert.AreEqual(text1, actual);
        }
        
        [Test]
        public void GetHeightZeroNodeTest()
        {
            var tree = Gtree.Create(4, Array.Empty<int>());
            var height = tree.Height;
            
            Assert.AreEqual(0, height);
        }
        
        [Test]
        public void GetHeightSingleNodeTest()
        {
            var tree = Gtree.Create(4, 1);
            var height = tree.Height;
            
            Assert.AreEqual(0, height);
        }
        
        [Test]
        public void GetHeightTwoNodesTest()
        {
            var tree = Gtree.Create(4, 1);
            tree.Insert(1, new List<int>{2,3,4});
            
            var height = tree.Height;
            
            Assert.AreEqual(1, height);
        }
        
        [Test]
        public void GetHeightHardTest()
        {
            var text = "3\n" +
                       "1\n" +
                       "1 8 22 29\n" +
                       "8 3 5 17\n" +
                       "3 16 19 32\n" +
                       "19 10 15\n" +
                       "22 42\n" +
                       "42 13 18 49\n" +
                       "29 4 9";
            
            var tree =Gtree.Parse<int>(text.Split('\n'));
            var actual = tree.Height;
            Assert.AreEqual(4, actual);
        }
    }
}