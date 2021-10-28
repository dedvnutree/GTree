// Tkachuk Pavel. Assignment 2 for class CS341
// TASK : https://cs.winona.edu/iyengar/CS%20341/Fall%202021/assignment%202%20F21.htm

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Gtree
    {
        public static Gtree<T> Create<T>(int maxElementsInNode, params T[] rootValues) where T: IComparable
        {
            var tree = new Gtree<T>(maxElementsInNode);
            foreach(var value in rootValues)
                tree.InsertIntoNode(tree, value);
            
            return tree;
        }
        
        public static Gtree<T> Parse<T>(string[] tree) where T: IComparable
        {
            var m = int.Parse(tree[0]);
            var rootValues = new List<T>();
            foreach (var value in tree[1].Split(' '))
                rootValues.Add(GtreeTextHelper.GetValue<T>(value));
            var result = Create(m, rootValues.ToArray());
            
            for (var i = 2; i < tree.Length; i++)
            {
                var splittedNode = tree[i].Split();
                var nodeRoot = GtreeTextHelper.GetValue<T>(splittedNode[0]);
                var values = GtreeTextHelper.GetValuesFromStringNode<T>(splittedNode);
                result.Insert(nodeRoot, values);
            }

            return result;
        }
    }
    
    public class Gtree<T>: IEnumerable<T> where T : IComparable
    {
        public int MaxElementsInNode;
        private int nodeHeight;
        public int Height
        {
            get { return GetHeightOfGtree(); }
        }

        private int RootHeight;
        public Gtree<T> Parent;
        private T ParentValue;
        private Dictionary<T, Gtree<T>> ValuesAndBranches;

        public Gtree(int maxElementsInNode)
        {
            MaxElementsInNode = maxElementsInNode;
            nodeHeight = 0;
            ValuesAndBranches = new Dictionary<T, Gtree<T>>();
        }

        public Gtree<T> FindNodeWithRoot(T root)
        {
            if(!FindOrCreateNodeIfRootExist(root, out var node))
                throw new Exception("This root does not exits!");

            node.Parent.ValuesAndBranches[root] = node;
            node.ParentValue = root;
            return node;
        }

        private bool FindOrCreateNodeIfRootExist(T root, out Gtree<T> node)
        {
            node = null;
            foreach (var valueAndBranch in ValuesAndBranches)
            {
                if (valueAndBranch.Key.CompareTo(root) == 0)
                {
                    node = valueAndBranch.Value;
                    if (node == null)
                    {
                        node = new Gtree<T>(MaxElementsInNode);
                        node.Parent = this;
                        node.nodeHeight = nodeHeight + 1;
                    }

                    return true;
                }

                if(valueAndBranch.Value != null)
                    if (valueAndBranch.Value.FindOrCreateNodeIfRootExist(root, out node))
                        return true;
            }
            
            return false;
        }

        public void Insert(T root, T value)
        {
            var node = FindNodeWithRoot(root);
            node.InsertIntoThisNode(value);
        }

        public void Insert(T root, IEnumerable<T> values)
        {
            var node = FindNodeWithRoot(root);
            foreach(var value in values)
                node.InsertIntoThisNode(value);
        }
        
        public void InsertIntoNode(Gtree<T> node, T value)
        {
            node.InsertIntoThisNode(value);
        }
        
        public void InsertIntoNodeMultiple(Gtree<T> node, T[] values)
        {
            foreach(var value in values)
                node.InsertIntoThisNode(value);
        }

        private void InsertIntoThisNode(T value)
        {
            ValuesAndBranches.Add(value, null);
            if (ValuesAndBranches.Count > MaxElementsInNode)
                throw new Exception("Too many values in the node!");
        }

        private int GetHeightOfGtree(int maxHeight = 0)
        {
            if (nodeHeight > maxHeight) maxHeight = nodeHeight;

                foreach (var branch in ValuesAndBranches.Values)
                    if (branch != null)
                    {
                        var newHeight = branch.GetHeightOfGtree(maxHeight);
                        if (newHeight > maxHeight) maxHeight = newHeight;
                    }

                return maxHeight;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var valueAndBranch in ValuesAndBranches)
            {
                yield return valueAndBranch.Key;
                
                if(valueAndBranch.Value == null)
                    continue;
                
                foreach (var branchValues in valueAndBranch.Value)
                {
                    yield return branchValues;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public override string ToString()
        {
            var tree = new StringBuilder();
            if(Parent != null)
                tree.Append(ParentValue + " ");
            
            foreach (var value in ValuesAndBranches.Keys)
                tree.Append(value + " ");

            tree.Append('\n');

            foreach (var branch in ValuesAndBranches.Values)
                if(branch != null)
                    tree.Append(branch.ToString());

            return tree.ToString();
        }
    }
}