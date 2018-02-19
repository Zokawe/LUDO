using System;
using System.Runtime.InteropServices;

//class for 'game handler'
class Game
{

    //Initialization of variables
    private int playerCount;
    private Player[] players;
    private LineMethods lm = new LineMethods();
    //private int i;
    //private int maxPlayers=4;
    //private int minPlayers=2;
    private int playerOrder = 0;
    //bool til at afgøre om spillet kører eller ej
    private bool gameInProgress;

    //Kort metode der først initialisere de forskellige objekter med værdier og derefter starter spillet
    public void GameRun()
    {
        InitializePlayers();
        Console.WriteLine();
        gameInProgress = true;
        GameRunning();
    }

    //Initialization of players
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

            for (int i = 0; i < playerCount; i++)
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

    //Initialization of Pieces
    private Piece[] InitializePieces()
    {
        Piece[] pieces = new Piece[4];
        for (int i = 0; i <= 3; i++)
        {
            pieces[i] = new Piece(i+1);
        }
        return pieces;
    }

    //Metode der afgøre om en spiller har alle brikker i mål vha 'PlayerInGoal'
    public void GameRunning()
    {
        while (gameInProgress = true)
        {
                if (playerOrder == playerCount)
                {
                    playerOrder = 0;
                }
                //køres kun hvis alle en spillers brikker er i mål
                else if (players[playerOrder].PlayerInGoal(players[playerOrder].GetPieces())==true)
                {
                    Console.Clear();
                    Console.WriteLine("Player#"+players[playerOrder].GetId()+" has won!");
                    Console.ReadKey();  
                    gameInProgress = false;
                }
                //hvis en spiller ikke har vundet endnu, så forsætter spillet
                else
                {
                
                    players[playerOrder].TakeAction();
                    playerOrder++;
                }
        }
    }
}