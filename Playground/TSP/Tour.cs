using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.TSP
{
    class Tour
    {
        public Stop Anchor { get; set; }

        public Tour(IEnumerable<Stop> stops)
        {
            Anchor = stops.First();
        }

        private IEnumerable<Stop> Cycle()
        {
            return Anchor.CanGetTo();
        }


       

        public double Cost()
        {
            return Cycle().Aggregate(
                0.0, (sum, stop) =>

                sum + Stop.Distance(stop, stop.Next)
                );
        }

        public IList<Stop> UnConnectedClones()
        {
            return Cycle().Select(stop => stop.Clone()).ToList();
        }


        //public Tour CloneWithSwap(City firstCity,City secondCity)
        //{
        //    Stop firstFrom = null, secondFrom = null;
        //    var stops = UnConnectedClones();
        //    stops.Connect(true);
        //    return null;

        //}

        //public static void Connect(this IEnumerable<Stop> stops, bool loop)
        //{
        //    Stop prev = null;
        //    Stop current = null;

        //    foreach(var stop in stops)
        //    {
        //        if (current == null) current = stop;
        //        if (prev != null) prev.Next = stop;
        //        prev = stop;
        //    }

        //    if (loop)
        //    {
        //        prev.Next = current;
        //    }

        //}
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
