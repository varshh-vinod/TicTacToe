using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class BoardController : ApiController
    {
        static Board board = new Board();
        static int countOfTimesBoardIsCalled=0;//odd calls are by player 1 and even calls are by player 2 

        // GET: api/Board
        public String Get()
        {
            String boardview = "\r\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) 
                {
                    boardview = boardview + board.boardcoordinates[i,j];
                }
                boardview = boardview + "\r\n";
            }
            return boardview;
        }

        // GET: api/Board/5
        public string Get(int id)
        {
            int y = (id % 10) - 1;
            int x = (id / 10) - 1;
            return board.boardcoordinates[x, y] + "";
        }

        // PUT: api/Board/5
        public String Put(int id)
        {
            int y = (id % 10) - 1;
            int x = (id / 10) - 1;
            countOfTimesBoardIsCalled++;
            if (countOfTimesBoardIsCalled % 2 != 0)//player 1's turn
            {
                board.boardcoordinates[x, y] = 'O';
                if (ifItsAwin('O')==1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            board.boardcoordinates[i, j] = '-';
                        }
                    }
                    countOfTimesBoardIsCalled = 0;
                    return "Player 1 wins, board has been resetted";
                }
            }
            else //playes 2's turn
            {
                board.boardcoordinates[x, y] = 'X';
                if (ifItsAwin('X') == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            board.boardcoordinates[i, j] = '-';
                        }
                    }
                    countOfTimesBoardIsCalled = 0;
                    return "Player 2 wins, board has been resetted";      
                }
            }
            return null;
        }

        public static int ifItsAwin(Char x)
        {
            //row 1 win
            if (board.boardcoordinates[0, 0] == x && board.boardcoordinates[0, 1] == x && board.boardcoordinates[0, 2] == x)
            {
                return 1;
            }
            //row 2 win
            if (board.boardcoordinates[1, 0] == x && board.boardcoordinates[1, 1] == x && board.boardcoordinates[1, 2] == x)
            {
                return 1;
            }
            //row 3 win
            if (board.boardcoordinates[2, 0] == x && board.boardcoordinates[2, 1] == x && board.boardcoordinates[2, 2] == x)
            {
                return 1;
            }
            //column 1 win
            if (board.boardcoordinates[0, 0] == x && board.boardcoordinates[1, 0] == x && board.boardcoordinates[2, 0] == x)
            {
                return 1;
            }
            //column 2 win
            if (board.boardcoordinates[0, 1] == x && board.boardcoordinates[1, 1] == x && board.boardcoordinates[2, 1] == x)
            {
                return 1;
            }
            //column 3 win
            if (board.boardcoordinates[0, 2] == x && board.boardcoordinates[1, 2] == x && board.boardcoordinates[2, 2] == x)
            {
                return 1;
            }
            //diagonal win 1
            if (board.boardcoordinates[0, 0]==x && board.boardcoordinates[1, 1]==x && board.boardcoordinates[2, 2]==x)
            {
                return 1;
            }
            //diagonal win 2
            if (board.boardcoordinates[0,2]==x && board.boardcoordinates[1,1]==x && board.boardcoordinates[2,0]==x)
            {
                return 1;
            }
            return 0;
        }

        // POST: api/Board
        public void Post([FromBody]String ids)
        {
        }

        // DELETE: api/Board/5
        public void Delete(int id)
        {
        }
    }
}
