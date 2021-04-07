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
                switch (pickComp)
                {
                    case 1:
                        
                    {
                        Console.WriteLine("Eazy Mode");
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

                        break;
                    }
                    case 2:
                        Console.WriteLine("HARDMODE");
                        var mode3 = new Random();
                        var mode2 = mode3.Next(0, 1);
                        switch (mode2)
                        {
                            case 0:
                            {
                                while (true)
                                {
                                    var ran = new Random();
                                    PlayCom1:
                                    Console.WriteLine("Comp turn");
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

                                    PlayCom1:
                                    Console.WriteLine("Player 1 turn\nEnter Position");
                                    if (!Screen('X', CompAlgo()))
                                    {
                                        goto PlayCom1;
                                    }
                                }
                            }
                        }

                        break;
                }
            }
        }
        private static string _tictactoeBoard = "---------";
        private static bool Screen(char xorY, int place)
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
                "|" + _tictactoeBoard[0] + "|" + _tictactoeBoard[1] + "|" + _tictactoeBoard[2] + "|" + "\n" +
                "|" + _tictactoeBoard[3] + "|" + _tictactoeBoard[4] + "|" + _tictactoeBoard[5] + "|" + "\n" +
                "|" + _tictactoeBoard[6] + "|" + _tictactoeBoard[7] + "|" + _tictactoeBoard[8] + "|" + "\n"
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
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[4] == _tictactoeBoard[5] && _tictactoeBoard[4] == _tictactoeBoard[3])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[7] == _tictactoeBoard[8] && _tictactoeBoard[8] == _tictactoeBoard[6])
                switch (_tictactoeBoard[7])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[0] == _tictactoeBoard[3] && _tictactoeBoard[3] == _tictactoeBoard[6])
                switch (_tictactoeBoard[6])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[1] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[7])
                switch (_tictactoeBoard[7])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[2] == _tictactoeBoard[5] && _tictactoeBoard[5] == _tictactoeBoard[8])
                switch (_tictactoeBoard[8])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[0] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[8])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (_tictactoeBoard[2] == _tictactoeBoard[4] && _tictactoeBoard[4] == _tictactoeBoard[6])
                switch (_tictactoeBoard[4])
                {
                    case 'X':
                        ShowFinalBoard();
                        Console.WriteLine("X wins");
                        Environment.Exit(exitCode: 0);
                        break;
                    case 'Y':
                        ShowFinalBoard();
                        Console.WriteLine("Y wins");
                        Environment.Exit(exitCode: 0);
                        break;
                }

            if (!_tictactoeBoard.Contains('-'))
                Environment.Exit(exitCode: 0);
        }

        private static int CompAlgo()
        {
            int val0 = 0, val1 = 0, val2 = 0, val3 = 0, val4 = 0, val5 = 0, val6 = 0, val7 = 0, val8 = 0;
            val0 = _tictactoeBoard[0] == 'X' ? 1 : 0;
            val1 = _tictactoeBoard[1] == 'X' ? 1 : 0;
            val2 = _tictactoeBoard[2] == 'X' ? 1 : 0;
            val3 = _tictactoeBoard[3] == 'X' ? 1 : 0;
            val4 = _tictactoeBoard[4] == 'X' ? 1 : 0;
            val5 = _tictactoeBoard[5] == 'X' ? 1 : 0;
            val6 = _tictactoeBoard[6] == 'X' ? 1 : 0;
            val7 = _tictactoeBoard[7] == 'X' ? 1 : 0;
            val8 = _tictactoeBoard[8] == 'X' ? 1 : 0;
            
            
            // Check to see if possible next win
            if (val0 + val1 + val2 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val1 == 0 && _tictactoeBoard[1] == '-')
                    return 1;
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
            }
            if (val3 + val4 + val5 == 2)
            {
                if (val3 == 0 && _tictactoeBoard[3] == '-')
                    return 3;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val5 == 0 && _tictactoeBoard[5] == '-')
                    return 5;
            }
            if (val6 + val7 + val8 == 2)
            {
                if (val6 == 0 && _tictactoeBoard[0] == '-')
                    return 6;
                if (val7 == 0 && _tictactoeBoard[7] == '-')
                    return 0;
                if (val8 == 0 && _tictactoeBoard[8] == '-')
                    return 8;
            }
            if (val0 + val3 + val6 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val3 == 0 && _tictactoeBoard[3] == '-')
                    return 3;
                if (val6 == 0 && _tictactoeBoard[6] == '-')
                    return 6;
            }
            if (val1 + val4 + val7 == 2)
            {
                if (val1 == 0 && _tictactoeBoard[1] == '-')
                    return 1;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val7 == 0 && _tictactoeBoard[7] == '-')
                    return 7;
            }
            if (val2 + val5 + val8 == 2)
            {
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
                if (val5 == 0 && _tictactoeBoard[5] == '-')
                    return 5;
                if (val8 == 0 && _tictactoeBoard[8] == '-')
                    return 8;
            }
            
            if (val0 + val4 + val8 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 1;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val8 == 0 && _tictactoeBoard[8] == '-')
                    return 8;
            }
            if (val2 + val4 + val6 == 2)
            {
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val6 == 0 && _tictactoeBoard[6] == '-')
                    return 6;
            }
            
            
            //stop player win
            val0 = _tictactoeBoard[0] == 'Y' ? 1 : 0;
            val1 = _tictactoeBoard[1] == 'Y' ? 1 : 0;
            val2 = _tictactoeBoard[2] == 'Y' ? 1 : 0;
            val3 = _tictactoeBoard[3] == 'Y' ? 1 : 0;
            val4 = _tictactoeBoard[4] == 'Y' ? 1 : 0;
            val5 = _tictactoeBoard[5] == 'Y' ? 1 : 0;
            val6 = _tictactoeBoard[6] == 'Y' ? 1 : 0;
            val7 = _tictactoeBoard[7] == 'Y' ? 1 : 0;
            val8 = _tictactoeBoard[8] == 'Y' ? 1 : 0;
            
            if (val0 + val1 + val2 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val1 == 0 && _tictactoeBoard[1] == '-')
                    return 1;
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
            }
            if (val3 + val4 + val5 == 2)
            {
                if (val3 == 0  && _tictactoeBoard[3] == '-')
                    return 3;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val5 == 0 && _tictactoeBoard[5] == '-')
                    return 5;
            }
            if (val6 + val7 + val8 == 2)
            {
                if (val6 == 0 && _tictactoeBoard[6] == '-')
                    return 6;
                if (val7 == 0 && _tictactoeBoard[7] == '-')
                    return 0;
                if (val8 == 0 && _tictactoeBoard[8] == '-')
                    return 8;
            }
            if (val0 + val3 + val6 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val3 == 0 && _tictactoeBoard[3] == '-')
                    return 3;
                if (val6 == 0 && _tictactoeBoard[6] == '-')
                    return 6;
            }
            if (val1 + val4 + val7 == 2)
            {
                if (val1 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val7 == 0 && _tictactoeBoard[7] == '-')
                    return 7;
            }
            if (val2 + val5 + val8 == 2)
            {
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
                if (val5 == 0 && _tictactoeBoard[5] == '-')
                    return 5;
                if (val8 == 0 && _tictactoeBoard[8] == '-')
                    return 8;
            }
            
            if (val0 + val4 + val8 == 2)
            {
                if (val0 == 0 && _tictactoeBoard[0] == '-')
                    return 0;
                if (val4 == 0 && _tictactoeBoard[4] == '-')
                    return 4;
                if (val8 == 0  && _tictactoeBoard[8] == '-')
                    return 8;
            }
            if (val2 + val4 + val6 == 2)
            {
                if (val2 == 0 && _tictactoeBoard[2] == '-')
                    return 2;
                if (val4 == 0  && _tictactoeBoard[4] == '-')
                    return 4;
                if (val6 == 0 && _tictactoeBoard[6] == '-')
                    return 6;
            }
            if (_tictactoeBoard.Contains('Y')&& _tictactoeBoard[4] == '-')
                return 4;
            if (!_tictactoeBoard.Contains('Y'))
                return 8;
            if (_tictactoeBoard[8] == 'Y' && _tictactoeBoard[0] == '-')
                return 0;
            if (_tictactoeBoard[8] == 'Y' && _tictactoeBoard[0] == 'Y'&& _tictactoeBoard[4] == 'X')
                if (_tictactoeBoard[2] == '-')
                    return 2;
                else if(_tictactoeBoard[6] == '-')
                    return 6;
            
            Console.WriteLine("Computer is a bit confused\nThe Computer makes a random pick");
            Random ran = new Random();
            return ran.Next(0, 8);
        }
    }
}
