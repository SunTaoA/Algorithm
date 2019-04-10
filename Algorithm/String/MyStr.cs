using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
   public class MyStr
   {
        public List<string> lstRet = new List<string>();
        public List<string> Permutation(string str)
        {
            string onePossible = string.Empty;
            var chars = str.ToList();
            chars.Sort();

            ListAll(chars, onePossible);

            return lstRet.Distinct().ToList();
        }

        public void ListAll(List<char> lstChars, string onePossible)
        {
            if (lstChars.Count == 0)
            {
                lstRet.Add(onePossible);
            }
            else
            {

                
                foreach (var e in lstChars)
                {
                    List<char> ori = new List<char>(lstChars);
                    string para = onePossible + e.ToString();
                    ori.Remove(e);
                    ListAll(ori, para);
                }
            }
        }

    }
}
