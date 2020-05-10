using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicaDesigner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Evaluator evaluator = new Evaluator();
            evaluator.AddRule(new int[] { 0, 4, 7}, 12);
            evaluator.AddRule(new int[] { 0, 3, 7 }, 1);

            Generator generator = new Generator(2, 12, evaluator);

            Layout[] layouts = generator.GetBestLayoutsSorted();
        }
    }
}
