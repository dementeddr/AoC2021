using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2021.Day4
{
	class BingoBoard
	{
		private int[,] _board = new int[5,5];

		public BingoBoard(List<string> board)
		{
			for (int row = 0; row < 5; row++)
			{
				for (int col = 0; col < 5; col++)
				{
					_board[row, col] = Convert.ToInt32(board[row].Substring(col*3, 2));
				}
			}
		}


		public int CheckBoard(int number)
		{
			bool[] colCheck = {true, true, true, true, true};
			bool[] rowCheck = {true, true, true, true, true};
			int points = 0;

			for (int row = 0; row < 5; row++)
			{
				for (int col = 0; col < 5; col++)
				{
					if (_board[row, col] == number)
					{
						_board[row, col] = -1;
					}

					if (_board[row, col] != -1)
					{
						points += _board[row, col];
						rowCheck[row] = false;
						colCheck[col] = false;
					}
				}
			}

			if (colCheck.Contains(true) || rowCheck.Contains(true))
				return points;

			return -1;
		}

		public override string ToString()
		{
			string outstring = "";

			for (int row = 0; row < 5; row++)
			{
				for (int col = 0; col < 5; col++)
				{
					outstring += $"{_board[row, col],2} ";
				}
				outstring += '\n';
			}

			return outstring;
		}
	}
}
