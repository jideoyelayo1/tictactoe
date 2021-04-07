using System;
using System.Linq;
using System.Text;

namespace tictactoe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to two player tic tac toe");
            Console.WriteLine(
                "|" + tictactoeBoard[0] + "|" + tictactoeBoard[1]+ "|" + tictactoeBoard[2]+ "|" + "\n"+
                "|" + tictactoeBoard[3] + "|" + tictactoeBoard[4]+ "|" + tictactoeBoard[5]+ "|" + "\n"+
                "|" + tictactoeBoard[6] + "|" + tictactoeBoard[7]+ "|" + tictactoeBoard[8]+ "|" + "\n"
            );
            while(true)
            {
                Player1:
                Console.WriteLine("Player 1 turn\nEnter Position");
                if(!Screen('X',Convert.ToInt32(Console.ReadLine()))){
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
        public static string tictactoeBoard = "---------";
        public static bool Screen(char XorY,int Place)
        {
            bool worked = true;
            if (tictactoeBoard[Place] != 'Y' && tictactoeBoard[Place] != 'X')
            {
                StringBuilder temp = new StringBuilder(tictactoeBoard);
                //Console.WriteLine(tictactoeBoard);
                temp[Place] = XorY;
                tictactoeBoard = temp.ToString();
                //Console.WriteLine(tictactoeBoard);
            }
            else
            {
                Console.WriteLine("This place is taken");
                worked = false;
            }

            CheckForWin();
            Console.Clear();
            Console.WriteLine(
                "|" + tictactoeBoard[0] + "|" + tictactoeBoard[1]+ "|" + tictactoeBoard[2]+ "|" + "\n"+
                "|" + tictactoeBoard[3] + "|" + tictactoeBoard[4]+ "|" + tictactoeBoard[5]+ "|" + "\n"+
                "|" + tictactoeBoard[6] + "|" + tictactoeBoard[7]+ "|" + tictactoeBoard[8]+ "|" + "\n"
            );
            return worked;
        }
        public static void CheckForWin()
        {
            if (tictactoeBoard.Select(x => x == 'X').Count() < 3 &&
                tictactoeBoard.Select(x => x == 'Y').Count() < 3) return;
            if (tictactoeBoard[1] == tictactoeBoard[2] && tictactoeBoard[1] == tictactoeBoard[0])
                if (tictactoeBoard[1] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[1] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[4] == tictactoeBoard[5] && tictactoeBoard[4] == tictactoeBoard[3])
                if(tictactoeBoard[4] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[4] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[7] == tictactoeBoard[8] && tictactoeBoard[8] == tictactoeBoard[6])
                if(tictactoeBoard[7] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[7] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[0] == tictactoeBoard[3] && tictactoeBoard[3] == tictactoeBoard[6])
                if(tictactoeBoard[6] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[6] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[1] == tictactoeBoard[4] && tictactoeBoard[4] == tictactoeBoard[7])
                if(tictactoeBoard[7] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[7] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[2] == tictactoeBoard[5] && tictactoeBoard[5] == tictactoeBoard[8])
                if(tictactoeBoard[8] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[8] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[0] == tictactoeBoard[4] && tictactoeBoard[4] == tictactoeBoard[8])
                if(tictactoeBoard[4] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[4] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (tictactoeBoard[2] == tictactoeBoard[4] && tictactoeBoard[4] == tictactoeBoard[6])
                if(tictactoeBoard[4] == 'X')
                {
                    Console.WriteLine("X wins");Environment.Exit(exitCode:0);
                }
                else if(tictactoeBoard[4] == 'Y')
                {
                    Console.WriteLine("Y wins");Environment.Exit(exitCode:0);
                }
            if (!tictactoeBoard.Contains('-'))
                Environment.Exit(exitCode:0);
        }
    }
}
