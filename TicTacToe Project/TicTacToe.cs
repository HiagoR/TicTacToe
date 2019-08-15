using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Project
{
    class TicTacToe
    {
        struct Player{
           public uint Score;
        }

        public static string[,] TablePositions = new string[3, 3];

        static protected string Player1 = "X";
        static protected string Player2 = "O";

        static uint TotalRounds = 0;
        static uint PlayCounter = 0;

        static void Main(string[] args)
        {
            InGame();
        }

        //method responsible for the execution of the game, with all requirements given being treated.
        static void InGame(Player p1 = new Player(), Player p2 = new Player(), bool MatchOver = false)
        {
            p1.Score = 0;
            p2.Score = 0;

            uint x;
            uint y;
            
            //this while represents a full match, following the requirements given.
            while (MatchOver is false)
            {
                InitVector(TablePositions);
                Print();

                //this while represents a full round.
                while (WinnerCheck(TablePositions) is false)
                {
                    Console.WriteLine("Enter with the index x");
                    x = Convert.ToUInt16(Console.ReadLine());
                    Console.WriteLine("Enter with the index y");
                    y = Convert.ToUInt16(Console.ReadLine());
       
                    Play(x, y);
                    Console.Clear();
                    Print();

                    if (WinnerCheck(TablePositions) is true)
                    {
                        if (PlayCounter %2 != 0)
                        {
                            p1.Score++;
                        }

                        if (PlayCounter % 2 == 0)
                        {
                            p2.Score++;
                        }

                        PlayCounter = 0;

                        Console.WriteLine("---------Scoreboard---------\n   Player1 {0} x {1} Player2 ", p1.Score, p2.Score);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                TotalRounds++;

                if (TotalRounds == 5)
                {
                    if (p1.Score == p2.Score)
                    {
                        while (WinnerCheck(TablePositions) is false)
                        {
                            Console.WriteLine("Enter with the index x");
                            x = Convert.ToUInt16(Console.ReadLine());
                            Console.WriteLine("Enter with the index y");
                            y = Convert.ToUInt16(Console.ReadLine());
                            Console.ReadLine();
                            Play(x, y);
                            Console.Clear();
                            Print();

                            if (WinnerCheck(TablePositions) is true)
                            {
                                if (PlayCounter % 2 == 0)
                                {
                                    p2.Score++;
                                }

                                if (PlayCounter % 2 != 0)
                                {
                                    p1.Score++;
                                }

                                PlayCounter = 1;
                            }
                        }

                        TotalRounds++;
                    }

                    if (p1.Score > p2.Score)
                    {
                        Console.WriteLine("Player 1 is the winner, with {0} points!", p1.Score);
                        Console.ReadKey();
                        MatchOver = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player 2 is the winner, with {0} points!", p2.Score);
                        Console.ReadKey();
                        MatchOver = true;
                        break;
                    }
                    

                }
                
            }
            
        }
        
        //method that initializes the vector with a blank space, preventing that are null places.
        static void InitVector(string[,] vector)
        {
            for (uint i = 0; i < 3; i++)
            {
                for (uint j = 0; j < 3; j++)
                {
                    vector[i, j] = " ";
                }
            }
        }

        //method that prints the vector with the blank positions in matrix format (x,y) and if there's a
        //marked position it prints the marker (X or O).
        static void Print()
        {
            for (uint i = 0; i < 3; i++)
            {
                for (uint j = 0; j < 3; j++)
                {
                    if (TablePositions[i, j].Equals(" "))
                    {
                        Console.Write("{0},{1}\t", i, j);
                    }
                    else
                        Console.Write("{0}\t", TablePositions[i, j]);
                }
                Console.WriteLine();

            }
        }

        //method that executes an play.
        static public void Play(uint i, uint j)
        {
            if (TablePositions[i, j].Equals(" "))
            {
                PlayCounter++;

                if (PlayCounter % 2 != 0)
                {
                    TablePositions[i, j] = Player1;
                }
                else
                {
                    TablePositions[i, j] = Player2;
                }
                
            }
    
        }

        //method that checks every possible case that could have a winner.
        static bool WinnerCheck(string[,] v)
        {
            for (int i = 0; i < 3; i++)
            {
                if (v[i, 0] != " ")
                {
                    if (v[i, 0] == v[i, 1] && v[i, 1] == v[i, 2]) return true;
                }
                if (v[0, i] != " ")
                {
                    if (v[0, i] == v[1, i] && v[1, i] == v[2, i]) return true;
                }
            }

            if (v[1, 1] != " ")
            {
                if (v[0, 0] == v[1, 1] && v[1, 1] == v[2, 2]) return true;
                if (v[1, 2] == v[1, 1] && v[1, 1] == v[2, 0]) return true;
            }

            return false;
        }
        
    }

}
