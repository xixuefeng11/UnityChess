﻿using System;

namespace UnityChess
{
    /// <summary>
    /// Representation of a square on a chessboard.
    /// </summary>
    public class Square
    {
        public int File { get; set; }
        public int Rank { get; set; }

        /// <summary>
        /// Creates a new Square instance.
        /// </summary>
        /// <param name="file">Column of the square.</param>
        /// <param name="rank">Row of the square.</param>
        public Square(int file, int rank)
        {
            this.File = file;
            this.Rank = rank;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        internal Square(Square square)
        {
            this.File = square.File;
            this.Rank = square.Rank;
        }

        public Square(int oneDimensionalIndex)
        {
            this.File = oneDimensionalIndex % 10;
            this.Rank = 9 - ((oneDimensionalIndex - this.File) / 10 - 1);
        }

        internal void AddVector(int file, int rank)
        {
            this.File += file;
            this.Rank += rank;
        }

        internal void CopyPosition(Square square)
        {
            this.File = square.File;
            this.Rank = square.Rank;
        }

        internal void SetPosition(int file, int rank)
        {
            this.File = file;
            this.Rank = rank;
        }

        /// <summary>
        /// Checks if this Square is on the 8x8 center of a 120-length board array.
        /// </summary>
        /// <returns></returns>
        internal bool IsValid()
        {
            return ((1 <= File && File <= 8) && (1 <= Rank && Rank <= 8));
        }

        internal bool IsOccupied(Board board)
        {
            Object obj = board.BasePieceList[this.AsIndex()];
            return (obj is Piece);
        }

        /// <summary>
        /// Returns the 1-D analog of the Square, with regard to a 120-length board array.
        /// </summary>
        /// <returns></returns>
        public int AsIndex()
        {
            return ((10 - this.Rank) * 10) + this.File;
        }

        public static int RankFileAsIndex(int file, int rank)
        {
            return ((10 - rank) * 10) + file;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Square square = obj as Square;
            return (Rank == square.Rank && File == square.File);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Rank.GetHashCode();
            hash = (hash * 7) + File.GetHashCode();
            return hash;
        }
    }
}