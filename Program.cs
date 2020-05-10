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
            evaluator.AddRule(ChordType.Major, 12);
            evaluator.AddRule(ChordType.Minor, 1);

            //Generator generator = new Generator(2, 12, evaluator);
            Generator generator = new Generator(2, 3, evaluator);

            Layout[] layouts = generator.GetBestLayoutsSorted();
        }
    }
}
