using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicaDesigner
{
    public class Generator
    {
        #region Members
        private int rowCount;

        private int rowSize;

        private Evaluator evaluator;
        #endregion

        #region Constructors
        public Generator(int rowCount, int rowSize, Evaluator evaluator)
        {
            this.rowCount = rowCount;
            this.rowSize = rowSize;
            this.evaluator = evaluator;
        }
        #endregion

        public Layout[] GetBestLayoutsSorted()
        {
            Layout[] layouts = this.GetAllPossibleLayouts(this.rowCount, this.rowSize);

            return layouts.OrderByDescending(layout => this.evaluator.GetScore(layout)).ToArray();
        }

        private Layout[] GetAllPossibleLayouts(int rowCount, int rowSize)
        {
            #warning Implement
            throw new NotImplementedException();
        }
    }
}
