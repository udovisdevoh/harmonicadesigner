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

        #region Properties
        public int RowCount
        {
            get { return this.rowCount; }
        }

        public int RowSize
        {
            get { return this.rowSize; }
        }

        public int this[int rowId, int positionId]
        {
            get { return this.values[rowId, positionId]; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder layoutDescription = new StringBuilder();

            layoutDescription.Append("|");
            for (int index = 1; index <= rowSize; ++index)
            {
                layoutDescription.Append(index);
                if (index < 10)
                {
                    layoutDescription.Append(" ");
                }

                layoutDescription.Append("|");
            }
            layoutDescription.Append("\r\n");

            for (int rowId = 0; rowId < rowCount; ++rowId)
            {
                layoutDescription.Append("|");
                for (int valueId = 0; valueId < rowSize;++valueId)
                {
                    int value = this.values[rowId, valueId];
                    string valueDescription = this.GetValueDescription(value);

                    layoutDescription.Append(valueDescription);
                    if (valueDescription.Length < 2)
                    {
                        layoutDescription.Append(" ");
                    }

                    layoutDescription.Append("|");
                }

                layoutDescription.Append("\r\n");
            }

            return layoutDescription.ToString();
        }

        private string GetValueDescription(int value)
        {
            switch (value)
            {
                case 0:
                    return "C";
                case 1:
                    return "C#";
                case 2:
                    return "D";
                case 3:
                    return "D#";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "F#";
                case 7:
                    return "G";
                case 8:
                    return "G#";
                case 9:
                    return "A";
                case 10:
                    return "A#";
                case 11:
                    return "B";
                default:
                    return "?";
            }
        }
    }
}
