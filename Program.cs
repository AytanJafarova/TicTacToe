using System;
using System.Drawing;


public class TicTacToe
{
    public static void Main(string[] args)
    {
        Console.WriteLine("***************Tic Tac Toe Game*****************");
        string[,] TicTacToe = new string[3, 3];
        string[,] TicTacToeMarked = { {"1","2","3" },
                                    {"4","5","6" },
                                    {"7","8","9" } };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                TicTacToe[i, j] = "1";
            }
        }
        int count = 0;
        int xCount = 0;
        int oCount = 0;

        TicTacToeArray ticTacToeArray = new TicTacToeArray();
        Player1 player1= new Player1();
        Player2 player2= new Player2(); 

        ticTacToeArray.WriteTicTacToe(TicTacToe);
      
        Console.WriteLine("\n\nPlayer 1: x");
        Console.WriteLine("Player 2: o");
        bool player1starts = true;
        bool player2starts = false;
        Console.WriteLine("\nPlayer 1! Start the game!");
        int[] Player1Out = new int[2];
        int[] Player2Out = new int[2];


        while (ticTacToeArray.CheckArray(TicTacToeMarked))
        {
           

            if (player1starts)
            {
                enter1Again:
                Player1Out = player1.Player1Enters();
            checkNext1:
                try
                {
                    if (TicTacToeMarked[Player1Out[0] - 1, Player1Out[1] - 1] == "o" || TicTacToeMarked[Player1Out[0] - 1, Player1Out[1] - 1] == "x")
                    {
                        Console.WriteLine("Enter again! This value checked");
                        goto enter1Again;
                    }
                    else
                    {
                        TicTacToe[Player1Out[0] - 1, Player1Out[1] - 1] = "x";
                        TicTacToeMarked[Player1Out[0] - 1, Player1Out[1] - 1] = "x";
                        ticTacToeArray.WriteTicTacToe(TicTacToe);
                        player1starts = false;
                        player2starts = true;
                        count++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter valid row and column values! ");
                    Player1Out = player1.Player1Enters();
                    goto checkNext1;
                }
               
            }

            else if (player2starts)
            {
            enter2Again:
                Player2Out = player2.Player2Enters();
              checkNext2:
                try
                {
                    if(TicTacToeMarked[Player2Out[0] - 1, Player2Out[1] - 1] == "o" || TicTacToeMarked[Player2Out[0] - 1, Player2Out[1] - 1] == "x")
                    {
                        Console.WriteLine("Enter again! This value checked");
                        goto enter2Again;
                    }
                    else
                    {
                        TicTacToe[Player2Out[0] - 1, Player2Out[1] - 1] = "o";
                        TicTacToeMarked[Player2Out[0] - 1, Player2Out[1] - 1] = "o";
                        ticTacToeArray.WriteTicTacToe(TicTacToe);
                        player2starts = false;
                        player1starts = true;
                        count++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter valid row and column values! ");
                    Player2Out = player2.Player2Enters();
                    goto checkNext2;
                }
            }
            if (count == 9)
            {
                break;
            }
        
           
        }
      
                if(count == 9)
                {
                    Console.WriteLine("Game Finished!!!\n");
                    Console.WriteLine("No one wins\n");
                }
                else
                {
                    Console.WriteLine("Game Finished!!!\n");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (TicTacToe[i, j] == "x") { xCount++; }
                            else { oCount++; }
                        }
                    }
                    if (xCount > oCount) { Console.WriteLine("***Player 1(x) wins!!!***"); }
                    else { Console.WriteLine("***Player 2(o) wins!!!***"); }
                }
            
    
    }
}
public class TicTacToeArray
{
    public void WriteTicTacToe(string[,] TicTacToe)
    {
        Console.WriteLine("____________");
        for (int i = 0; i < 3; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + TicTacToe[i, j] + " |");
            }
            Console.WriteLine("");
            Console.WriteLine("____________");
        }
    }
    public bool CheckArray(string[,] TicTacToe)
    {
          if (TicTacToe[0, 0] == TicTacToe[0, 1] && TicTacToe[0, 1]  == TicTacToe[0, 2]) { return false; }
     else if (TicTacToe[1, 0] == TicTacToe[1, 1] && TicTacToe[1, 1]  == TicTacToe[1, 2]) { return false; }
     else if (TicTacToe[2, 0] == TicTacToe[2, 1] && TicTacToe[2, 1]  == TicTacToe[2, 2]) { return false; }

     else if (TicTacToe[0, 0] == TicTacToe[1, 0] && TicTacToe[1, 0]  == TicTacToe[2, 0]) { return false; }
     else if (TicTacToe[0, 1] == TicTacToe[1, 1] && TicTacToe[1, 1]  == TicTacToe[2, 1]) { return false; }
     else if (TicTacToe[0, 2] == TicTacToe[1, 2] && TicTacToe[1, 2]  == TicTacToe[2, 2]) { return false; }

     else if (TicTacToe[0, 0] == TicTacToe[1, 1] && TicTacToe[1, 1]  == TicTacToe[2, 2]) { return false; }
     else if (TicTacToe[0, 2] == TicTacToe[1, 1] && TicTacToe[1, 1]  == TicTacToe[2, 0]) { return false; }
     else { return true; }
    } 
}
public class Player1
{
    public int row;
    public int col;
    public int[] Player1Enters()
    {
        enter1:
        try
        {
            
            Console.WriteLine("\nPlayer 1 (x):");
        againP1:
            Console.Write("Row number: ");
            int rowP1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column number: ");
            int colP1 = Convert.ToInt32(Console.ReadLine());
            int[] Player1 = new int[2];

            if (Convert.ToBoolean(rowP1) && Convert.ToBoolean(colP1))
            {
                Player1[0] = rowP1;
                Player1[1] = colP1;
                return Player1;
            }
            else
            {
                goto againP1;
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Please enter valid (numeric) inputs");
            goto enter1;
        }
       
    }


}
public class Player2
{
    public int row;
    public int col;
    public int[] Player2Enters()
    {
        enter2:
        try
        {
            Console.WriteLine("\nPlayer 2 (o):");
        againP2:
            Console.Write("Row number: ");
            int rowP2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column number: ");
            int colP2 = Convert.ToInt32(Console.ReadLine());
            int[] Player2 = new int[2];

            if (Convert.ToBoolean(rowP2) && Convert.ToBoolean(colP2))
            {
                Player2[0] = rowP2;
                Player2[1] = colP2;
                return Player2;
            }
            else
            {
                goto againP2;
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Please enter valid (numeric) inputs");
            goto enter2;
        }
       
    }


}

