using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.String
{
   public  class KMPAlgo
    {

        public int[] PartialMatch(string pattern)
        {
            

            int[] prefixArray = new int[pattern.Length];
            prefixArray[0] = 0;
            int k = 0;
            int m = pattern.Length;

            for(int q = 1;q < m; q++)
            {
                while (k > 0 && pattern[q] != pattern[k + 1])
                {
                    k = prefixArray[k - 1];
                }

                if (pattern[q] == pattern[k + 1]){
                    k = k + 1;
                }
                prefixArray[q] = k;
            }


            return prefixArray;


        }

        //http://cs.indstate.edu/~kmandumula/presentation.pdf

    /*
        Step 1: Initializetheinput variables:
            n = Length of the Text.
            m = Length of the Pattern .
            a = Prefix −functionof pattern (p ) .
            q = Number of characters matched.

        Step 2: Define the variable :
            q= 0, the beginning of the match.

        Step 3: Compare the first character of the pattern with firstcharacter of
            text.
            If match is not found, substitute the value of u[q] to q .
            If match is found , then in crement the value of q by 1.

         Step 4: Check whether a ll the pattern elements are matched wit h the te x t
            elements .
            If not , repeat the search process .
            If yes, print the number of shifts taken by the pattern.

         Step5: look for the next match.

    */
        public bool PatternMatch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            int q = 0;

            int[] prefixArrary = PartialMatch(pattern);
            for(int i = 0; i < n; i++)
            {
                while (q > 0 && pattern[q] != text[i])
                {
                    q = prefixArrary[q - 1];
                }

                    if (pattern[q] == text[i]){

                        q = q + 1;
                    }

                    if (q == m)
                    {
                        return true;
                    }

                }
           

            return false;

        }
    }
}
