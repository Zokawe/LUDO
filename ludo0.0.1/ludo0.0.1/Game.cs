using System;
using System.Runtime.InteropServices;

class Game
{

    private int playerCount;
    public Player[] players;
    private int i;
    private int playerOrder = 0;
    private bool gameInProgress = false;

    public void GameRun()
    {
        var gameState = 0;

        Console.Write("Choose number of players: ");
        int.TryParse(Console.ReadLine(), out playerCount);

        players = new Player[playerCount];

        for (i = 0; i <playerCount; i++)
            {
                players[i] = new Player(i+1);
                Console.WriteLine("Player "+players[i].GetId()+" has joined the game.");

            }
        Console.WriteLine();
        gameInProgress = true;
        GameRunning();




        

        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\JSL\Desktop\ludo.txt");

        //// Display the file contents by using a foreach loop.

        //foreach (string line in lines)
        //{
        //    // Use a tab to indent each line of the file.
        //    Console.WriteLine(line);
        //}


        //string lineRead = Console.ReadLine();


    }

    public void GameRunning()
    {
        while (gameInProgress = true)
        {
                if (playerOrder == playerCount)
                {
                    playerOrder = 0;
                }
                else if (players[playerOrder].GetPlayerState()==2)
                {
                    Console.WriteLine("Player "+players[playerOrder].GetId()+" has won!");
                    Console.ReadKey();  
                    gameInProgress = false;
                }
                else
                {
                    players[playerOrder].Move();
                    playerOrder++;
                }
            
        }
    }


}