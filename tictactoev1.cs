using System;
using System.Linq;
using System.Text;

namespace tictactoe
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("PvP[1] or PvCom[2]");
            start:
            var pickGameMode = Convert.ToInt32(Console.ReadLine());
            if (pickGameMode != 1 && pickGameMode != 2)
                goto start;
            
            if (pickGameMode == 1)
            {
                Console.WriteLine("Welcome to two player tic tac toe");
                Console.WriteLine(
                    "|" + _tictactoeBoard[0] + "|" + _tictactoeBoard[1] + "|" + _tictactoeBoard[2] + "|" + "\n" +
                    "|" + _tictactoeBoard[3] + "|" + _tictactoeBoard[4] + "|" + _tictactoeBoard[5] + "|" + "\n" +
                    "|" + _tictactoeBoard[6] + "|" + _tictactoeBoard[7] + "|" + _tictactoeBoard[8] + "|" + "\n"
                );
                while (true)
                {
                    Player1:
                    Console.WriteLine("Player 1 turn\nEnter Position");
                    if (!Screen('X', Convert.ToInt32(Console.ReadLine())))
                    {
                        Console.WriteLine("This place is taken\nTry again");
                        goto Player1;
                    }

                    Player2:
                    Console.WriteLine("Player 2 turn\nEnter Position");
                    if (!Screen('Y', Convert.ToInt32(Console.ReadLine())))
                    {
                        Console.WriteLine("This place is taken\nTry again");
                        goto Player2;
                    }
                }
            }

            {
                Console.WriteLine("Welcome to PvCom player tic tac toe");
                Console.WriteLine("Easy mode[1] or Hard mode[2]");
                startComp:
                var pickComp = Convert.ToInt32(Console.ReadLine());
                if (pickComp != 1 && pickComp != 2)
                    goto startComp;
                Console.WriteLine(
                    "|" + _tictactoeBoard[0] + "|" + _tictactoeBoard[1] + "|" + _tictactoeBoard[2] + "|" + "\n" +
                    "|" + _tictactoeBoard[3] + "|" + _tictactoeBoard[4] + "|" + _tictactoeBoard[5] + "|" + "\n" +
                    "|" + _tictactoeBoard[6] + "|" + _tictactoeBoard[7] + "|" + _tictactoeBoard[8] + "|" + "\n"
                );
                if (pickComp != 1) return;
                var mode1 = new Random();
                var mode = mode1.Next(0, 1);
                switch (mode)
                {
                    case 0:
                    {
                        while (true)
                        {
                            var ran = new Random();
                            PlayCom1:
                            Console.WriteLine("Player 1 turn\nEnter Position");
                            if (!Screen('X', ran.Next(0, 8)))
                            {
                                goto PlayCom1;
                            }

                            PlayUser1:
                            Console.WriteLine("Your turn\nEnter Position");
                            if (!Screen('Y', Convert.ToInt32(Console.ReadLine())))
                            {
                                Console.WriteLine("This place is taken\nTry again");
                                goto PlayUser1;
                            }
                        }
                    }
                    case 1:
                    {
                        while (true)
                        {
                            PlayUser1:
                            Console.WriteLine("Your turn\nEnter Position");
                            if (!Screen('Y', Convert.ToInt32(Console.ReadLine())))
                            {
                                Console.WriteLine("This place is taken\nTry again");
                                goto PlayUser1;
                            }

                            Random ran = new Random();
                            PlayCom1:
                            Console.WriteLine("Player 1 turn\nEnter Position");
                            if (!Screen('X', ran.Next(0, 8)))
                            {
                                goto PlayCom1;
                            }
                        }
                    }
                }

                /*

                if (pickComp == "2")
                {
                    
                }*/
            }
        }

        private static string _tictactoeBoard = "---------";

        private static bool Screen(char xorY,int place)
        {
            var worked = true;
            if (_tictactoeBoard != null && _tictactoeBoard[place] != 'Y' && _tictactoeBoard[place] != 'X')
            {
                var temp = new StringBuilder(_tictactoeBoard) {[place] = xorY};
                //Console.WriteLine(tictactoeBoard);
                _tictactoeBoard = temp.ToString();
                //Console.WriteLine(tictactoeBoard);
            }
            else
            {
                Console.WriteLine("This place is taken");
                worked = false;
            }

            CheckForWin();
            Console.Clear();
            if (_tictactoeBoard != null)
                Console.WriteLine(
                    "|" + _tictactoeBoard[0] + "|" + _tictactoeBoard[1] + "|" + _tictactoeBoard[2] + "|" + "\n" +
                    "|" + _tictactoeBoard[3] + "|" + _tictactoeBoard[4] + "|" + _tictactoeBoard[5] + "|" + "\n" +
                    "|" + _tictactoeBoard[6] + "|" + _tictactoeBoard[7] + "|" + _tictactoeBoard[8] + "|" + "\n"
                );
            return worked;
        }

        private static void ShowFinalBoard()
        {
            Console.WriteLine(
                "|" + _tictactoeBoard[0] + "|" + _tictactoeBoard[1]+ "|" + _tictactoeBoard[2]+ "|" + "\n"+
                "|" + _tictactoeBoard[3] + "|" + _tictactoeBoard[4]+ "|" + _tictactoeBoard[5]+ "|" + "\n"+
                "|" + _tictactoeBoard[6] + "|" + _tictactoeBoard[7]+ "|" + _tictactoeBoard[8]+ "|" + "\n"
            );
        }

        private static void CheckForWin()
        {
            if (_tictactoeBoard.Select(x => x == 'X').Count() < 3 &&
                _tictactoeBoard.Select(x => x == 'Y').Count() < 3) return;
            if (_tictactoeBoard[1] == _tictactoeBoard[2] && _tictactoeBoard[1] == _tictactoeBoard[0])
                switch (_tictactoeBoard[1])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[4] == _tictactoeBoard[5] && _tictactoeBoard[4] == _tictactoeBoard[3])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[7] == _tictactoeBoard[8] && _tictactoeBoard[8] == _tictactoeBoard[6])
                switch (_tictactoeBoard[7])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[0] == _tictactoeBoard[3] && _tictactoeBoard[3] == _tictactoeBoard[6])
                switch (_tictactoeBoard[6])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[1] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[7])
                switch (_tictactoeBoard[7])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[2] == _tictactoeBoard[5] && _tictactoeBoard[5] == _tictactoeBoard[8])
                switch (_tictactoeBoard[8])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[0] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[8])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (_tictactoeBoard[2] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[6])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                        break;
                }
            if (!_tictactoeBoard.Contains('-'))
                Environment.Exit(exitCode:0);
        }
    }
}
