using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaptCharter
{
    class Note
    {

        private int row;
        private int col;
        private NoteType noteType;

        public int Row
        {
            get
            {
                return row;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
        }

        public NoteType NoteType
        {
            get
            {
                return noteType;
            }
            set
            {
                noteType = value;
            }
        }

        public Note(int _row, int _column, NoteType _noteType)
        {
            row = _row;
            col = _column;
            noteType = _noteType;
        }

    }
}
