using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicaDesigner
{
    public class Evaluator
    {
        #region Members
        private Dictionary<int[], int> rules = new Dictionary<int[], int>();
        #endregion

        public void AddRule(int[] intervals, int weight)
        {
            rules[intervals] = weight;
        }
    }
}
