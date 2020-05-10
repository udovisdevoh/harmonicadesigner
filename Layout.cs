using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicaDesigner
{
    public class Layout
    {
        #region Members
        private int rowCount;

        private int rowSize;

        private int[,] values;
        #endregion

        #region Constructors
        public Layout(int rowCount, int rowSize)
        {
            this.rowCount = rowCount;
            this.rowSize = rowSize;
            this.values = new int[rowCount, rowSize];
        }
        #endregion
    }
}
