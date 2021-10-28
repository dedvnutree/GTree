using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class GtreeTextHelper
    {
        public static T GetValue<T>(String value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        
        public static string ToStringWithM<T>(Gtree<T> tree) where T: IComparable
        {
            var result = new StringBuilder();
            result.Append(tree.MaxElementsInNode + "\n" ); 
            result.Append(tree.ToString());
            
            return result.ToString(); 
        }

        public static List<T> GetValuesFromStringNode<T>(string[] node) where T: IComparable
        {
            var values = new List<T>();
            for (var i =1; i < node.Length; i++)
                values.Add(GtreeTextHelper.GetValue<T>(node[i]));

            return values;
        }
    }
}