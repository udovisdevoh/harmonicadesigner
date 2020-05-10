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

        public int GetScore(Layout layout)
        {
            int score = 0;
            foreach (KeyValuePair<int[], int> ruleAndWeight in this.rules)
            {
                int[] rule = ruleAndWeight.Key;
                int weight = ruleAndWeight.Value;
                int occurenceCount = this.CountOccurence(layout, rule);

                score += occurenceCount * weight;
            }

            return score;
        }

        private int CountOccurence(Layout layout, int[] rule)
        {
            #warning Implement
            throw new NotImplementedException();
        }
    }
}
