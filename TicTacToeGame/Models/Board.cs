using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToeGame.Models
{
    public class Board
    {
        public Char[,] boardcoordinates = new Char[3, 3];
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    boardcoordinates[i, j] = '-';
                }
            }
        }
    }
}