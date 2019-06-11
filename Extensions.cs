using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStatSystem
{
    public static class Extensions
    {
        public static float Range(this Random rnd, float maxInclusive)
        {
            float r = (float)rnd.NextDouble() * maxInclusive ;
            return r;
        }

        public static float Range(this Random rnd, float minInclusive, float maxInclusive)
        {
            float r = (float)rnd.NextDouble() * (maxInclusive - minInclusive);
            return r + minInclusive;
        }

        public static float Distribution(this Random rnd, float weight, float maxPoints, ref float points)
        {
            float r = (float)rnd.NextDouble() * weight * maxPoints;            
            points -= r;
            if (points < 0)
            {
                r += Math.Abs(points);
                points = 0;
            }
            return r;
        }

        public static float Clip(this float input, float min = 0f)
        {
            if (input < min) input = min;
            return input;
        }
        public static float Clip(this float input, float min ,float max)
        {
            float output;
            if (input < min) output = min;
            else if (input > max) output = max;
            else output = input;
            if (float.IsNaN(output)) Debugger.Break();
            return output;
        }

        public static IEnumerable<Tuple<T,T>> Pairwise<T>(this IEnumerable<T> enumerable)
        {
            var queue = new Queue<T>(enumerable);
            while (queue.Count() > 1) { yield return new Tuple<T,T>(queue.Dequeue(), queue.Peek()); }
        }
    }
}
