using System;
using System.Runtime.InteropServices;

class Game
{

    private int playerCount;
    public Player[] players;
    private LineMethods lm = new LineMethods();
    private int i;
    //private int maxPlayers=4;
    //private int minPlayers=2;
    private int playerOrder = 0;

    private bool gameInProgress;

    public void GameRun()
    {
        var gameState = 0;

        InitializePlayers();

        Console.WriteLine();
        gameInProgress = true;
        GameRunning();




        
    }

    public void InitializePlayers()
    {
        bool cnvSuccess = false;

        while (cnvSuccess == false)
        {
            Console.Clear();
            Console.Write("Choose number of players: ");
            string input = Console.ReadLine();
            cnvSuccess = lm.InputCheck(input);
            int.TryParse(input, out playerCount);
            lm.BreakLine();
            players = new Player[playerCount];

            for (i = 0; i < playerCount; i++)
            {
                Piece[] pcs = InitializePieces();
                players[i] = new Player(i + 1, pcs);
                Console.WriteLine("Player " + players[i].GetId() + " has joined the game.");

            }
        }
        lm.BreakLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        
    }

    private Piece[] InitializePieces()
    {
        Piece[] pieces = new Piece[4];
        for (int i = 0; i <= 3; i++)
        {
            pieces[i] = new Piece(i+1);
        }
        return pieces;
    }

    public void GameRunning()
    {
        while (gameInProgress = true)
        {
                if (playerOrder == playerCount)
                {
                    playerOrder = 0;
                }
                else if (players[playerOrder].PlayerInGoal(players[playerOrder].GetPieces())==true)
                {
                    Console.Clear();
                    Console.WriteLine("Player#"+players[playerOrder].GetId()+" has won!");
                    Console.ReadKey();  
                    gameInProgress = false;
                }
                else
                {
                    players[playerOrder].TakeAction();
                    playerOrder++;
                }
            
        }
    }


}