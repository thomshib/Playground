using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Knapsack
{

    //http://www.es.ele.tue.nl/education/5MC10/Solutions/knapsack.pdf
    public class Knapsack
    {

        //public int KnapsackSolution(int[] values, int[] weights,int itemCount, int capacity)
        //{
        //    /*
        //     knapsack(v,w,n,W){

        //        V is an array with W + 1(capacity) columns and n + 1(#items) rows
                
        //        //initialize zero th row to zeros
        //        for(w=0 to W) V[0,w] = 0;

        //        for(i = 1 to n){ //foreach row
        //            for(w = 0 to W){ //foreach col
                        
        //                if (w[i] <= w) and  (v[i] + V[i-1,w - w[i]] > V[i-1,w]
        //                {
        //                    //current item value + previous item value for the balance weight
        //                    V[i,w] = v[i] + V[i-1,w - w[i]];
        //                    keep[i,w] = 1;
        //                }
        //                else
        //                {
        //                    //previous item
        //                    V[i,w] = V[i-1,w]
        //                    keep[i,w] = 0;
        //                }

        //            }

        //            K = W;

        //            for (n downto 1)
        //            {
        //                if(keep[i,K] == 1
        //                {
        //                    output i;
        //                    K = K - w[i];
        //                }

        //            }

        //            return V[n,W];
        //        }





        //    }



        //    */
        //    int W = capacity + 1;
        //    int N = itemCount + 1;

        //    //create an array from 0 to values.Count+1, 0 to Weights.Count + 1
        //    int[,] V = new int[N,W];


        //    List<KeyValuePair<int, int>> keep = new List<KeyValuePair<int, int>>();

        //    //initialize row-0 to 0 weights
        //    for(int w = 0; w < W; w++)
        //    {
        //        V[0, w] = 0;
        //    }

        //    //initialize col-0 to o
        //    for (int n = 0; n < N; n++)
        //    {
        //        V[n, 0] = 0;
        //    }

        //    for (int i = 1; i < N; i++)
        //    {
        //        for(int w = 0; w <W; w++)
        //        {
        //            if ( (weights[i] <= w) && (values[i] + V[i - 1, w - weights[i]] > V[i - 1, w]))
        //            {
        //                //pick current items + previous item for the balance weight
        //                V[i, w] = values[i] + V[i - 1, w - weights[i]];
        //                keep.Add(new KeyValuePair<int, int>(i, w));
        //            }
        //            else
        //            {
        //                //pick previous item
        //                V[i, w] = V[i - 1, w];
        //                keep.Add(new KeyValuePair<int, int>(i, 0));
        //            }
        //        }
        //    }


        //    return V[N,W];
        //}

        public int KnapsackSolution(int W,int[] wt, int[] val, int n)
        {
            //base case

            if(n==0 || W == 0)
            {
                return 0;
            }

            //include nth item or not

            if( wt[n-1] > W)
            {
                //nth item cannot be included
                return KnapsackSolution(W, wt, val, n - 1);
            }
            else
            {
                //nth item can be included
                //will be a max of
                // val[n-1] + KnapsackSolution( W - wt[n-1],  wt,  val, n -1) and
                // KnapsackSolution( W,  wt,  val, n -1)
               return Math.Max((val[n - 1] + KnapsackSolution(W - wt[n - 1], wt, val, n - 1)), KnapsackSolution(W, wt, val, n - 1));
            }
        }
    }
}
