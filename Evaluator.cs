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
        private Dictionary<ChordType, int> rules = new Dictionary<ChordType, int>();

        private HashSet<int> tempMatchedBaseNote = new HashSet<int>();
        #endregion

        public void AddRule(ChordType chordType, int weight)
        {
            rules[chordType] = weight;
        }

        public int GetScore(Layout layout)
        {
            int score = 0;
            foreach (KeyValuePair<ChordType, int> rule in this.rules)
            {
                ChordType chordType = rule.Key;
                int weight = rule.Value;
                int occurenceCount = this.CountOccurence(layout, chordType);

                score += occurenceCount * weight;
            }

            return score;
        }

        private int CountOccurence(Layout layout, ChordType chordType)
        {
            this.tempMatchedBaseNote.Clear();
            for (int rowId = 0; rowId < layout.RowCount;++rowId)
            {
                for (int positionId = 0; positionId < layout.RowSize -2; ++positionId)
                {
                    int[] currentChordCandidate = new int[] { layout[rowId, positionId], layout[rowId, positionId + 1], layout[rowId, positionId + 2] };

                    this.TryMatchChord(chordType, currentChordCandidate, 0, 1, 2);
                    this.TryMatchChord(chordType, currentChordCandidate, 0, 2, 1);
                    this.TryMatchChord(chordType, currentChordCandidate, 1, 0, 2);
                    this.TryMatchChord(chordType, currentChordCandidate, 1, 2, 0);
                    this.TryMatchChord(chordType, currentChordCandidate, 2, 0, 1);
                    this.TryMatchChord(chordType, currentChordCandidate, 2, 1, 0);
                }
            }
            return tempMatchedBaseNote.Count();
        }

        private void TryMatchChord(ChordType chordType, int[] currentChordCandidate, int baseNoteId, int otherNoteId1, int otherNoteId2)
        {
            if (this.IsFifth(currentChordCandidate[baseNoteId], currentChordCandidate[otherNoteId1]))
            {
                if (this.IsThird(currentChordCandidate[baseNoteId], currentChordCandidate[otherNoteId2], chordType))
                {
                    tempMatchedBaseNote.Add(currentChordCandidate[baseNoteId]);
                }
            }
        }

        private bool IsFifth(int baseNote, int fifthCandidate)
        {
            int normalizedInterval = this.GetNormalizedInterval(baseNote, fifthCandidate);
            return normalizedInterval == 7;
        }

        private bool IsThird(int baseNote, int thirdCandidate, ChordType chordType)
        {
            int normalizedInterval = this.GetNormalizedInterval(baseNote, thirdCandidate);
            if (chordType == ChordType.Major)
            {
                return normalizedInterval == 4;
            }
            else
            {
                return normalizedInterval == 3;
            }
        }

        private int GetNormalizedInterval(int baseNote, int highNote)
        {
            throw new NotImplementedException();
        }
    }
}
