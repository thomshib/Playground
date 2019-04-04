using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.String
{
    //https://www.youtube.com/watch?v=H4VrKHVG5qI
    public class RabinKarp
    {
        private int prime = 101;

        public int PatternSearch(string text,string pattern)
            {
            int m = pattern.Length;
            int n = text.Length;

            long patternHash = CreateHash(pattern, m - 1);

            long textHash = CreateHash(text, m - 1);

            //there n-m+1 substrings in text
            //i starts from one because initial hash starting from zero has been computed above 
            for(int i=1;i <= n - m + 1; i++)
            {
                //check if the previous hashes match

                if (textHash == patternHash && CheckEquals(text, i - 1, i + m - 2, pattern, 0, m - 1))
                {
                    return i - 1; 
                }

                if( i < n - m + 1)
                {
                    textHash = RecalculateHash(text, i - 1, i + m - 1, textHash, m);
                }
            }


            return -1;
        }

        private long RecalculateHash(string text, int oldIndex, int newIndex, long oldHash, int patternLength)
        {
            long newHash = oldHash - Convert.ToInt32(text[oldIndex]);
            newHash = newHash / prime;
            newHash += Convert.ToInt32(text[newIndex]) * Convert.ToInt64(Math.Pow(prime, patternLength - 1));
            return newHash;
        }

        private bool CheckEquals(string text, int start1 ,int end1, string pattern, int start2, int end2)
        {
           if((end1 - start1) != (end2 - start2)){
                return false;
            }

           while(start1 <= end1 && start2 <= end2)
            {
                if(text[start1] != pattern[start2])
                {
                    return false;
                }
                start1++;
                start2++;
            }

            return true;
        }

        private long CreateHash(string pattern, int m)
        {
            long  hash = 0;
            for(int i =0; i <=m; i++)
            {
                hash += Convert.ToInt32(pattern[i]) * Convert.ToInt64(Math.Pow(prime, i)); 
            }
            return hash;
        }
    }
}
