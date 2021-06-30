using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TaptCharter
{
    class Note
    {

        private int row;
        private int col;
        private NoteType noteType;
        private Color activeColor;
        private bool isActive = false;

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
        public Color ActiveColor
        {
            get
            {
                switch (col){
                    case 0:
                        return Color.Red;
                    case 1:
                        return Color.Orange;
                    case 2:
                        return Color.Yellow;
                    case 3:
                        return Color.Lime;
                    case 4:
                        return Color.Green;
                    case 5:
                        return Color.Cyan;
                    case 6:
                        return Color.Blue;
                    case 7:
                        return Color.Magenta;
                    case 8:
                        return Color.Purple;
                    default:
                        return Color.White;
                }
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
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
