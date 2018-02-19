using System;
public enum PlayerPos { Spawn, Moving, Safe, Goal };

//class for spillere
class Player
{
    //add interface for map/board properties; state, maplength, dist to goal etc.

    //initialization of variables & constants
    private PlayerPos pos = PlayerPos.Spawn;
    private int dRoll;
    private int playerId;
    private int distToGoal;
    private const int mapLength = 56;
    //private int spawnDist = 13;
    //private int offset = 0;

    //initialization of objects used in class
    public Piece[] pieces;
    Dice plDice = new Dice();
    LineMethods lm = new LineMethods();

    
    //Constructor
    public Player(int id, Piece[] pieces)
    {
        this.playerId = id;
        this.pieces = pieces;
        //this.offset = (id - 1) * (spawnDist); //used to calculate the difference in player paths
        this.distToGoal= mapLength; //still present due to future useage
    }

    //
    public void TakeAction()
    {
        Console.Clear();
        Console.WriteLine("Player #" + playerId + "'s turn. Press any key to roll the dice");
        Console.ReadKey();
        
        PieceInfo(GetPieces());
    }

    //styre valg af ludobrik. Holder brugeren fanget såfremt at svaret ikke er en integer eller er uden for 'brikrange'
    public void PieceChoice(int dRoll)
    {
        bool cnvSuccess = false;

        lm.BreakLine();
        Console.Write("Which piece would you like to use? ");

        while (cnvSuccess == false)
        {
            //inputcheck er en metode i LineMethods til at returnere converteret input i en bool
            string input = Console.ReadLine();
            cnvSuccess = lm.InputCheck(input);

            int.TryParse(input, out int piecePick);
            //tjekker at valget er inden for range og at brikken ikke er i mål
            if (piecePick <= 4 && piecePick > 0 &&pieces[piecePick-1].pos!=PiecePos.Goal)
            {
                pieces[piecePick - 1].Move(dRoll);
            }
            else
            {
                cnvSuccess = false;
            }
        }
    }
    //bruges til at udskrive informationer om brikplacering og muligheder deraf.
    public void PieceInfo(Piece[] pieces)
    {
        //q tillader spillere, der ikke har nogen brikker på banen at slå 3 gange, såfremt de ikke slår en sekser.
        for (int q = 3; q > 0; q--)
        {
            dRoll = plDice.GetThrow();
            int choices = 0;
            lm.BreakLine();
            Console.WriteLine("Player #" + playerId + " rolled a " + dRoll + "!");
            lm.BreakLine();
            //foreach loop til at tjekke alle en spillers brikker
            foreach (Piece p in pieces)
            {
                Console.Write("Piece #" + p.GetId() + " Location: " + p.GetPos());

                switch (p.GetPos())
                {
                    case PiecePos.Spawn:
                        if (dRoll == 6)
                        {
                            Console.WriteLine(": Playable");
                            
                            //Console.Write(" Distance to goal: " + p.GetDistToGoal());
                            choices++;
                            
                            //p.pos=PiecePos.Moving;
                        }
                        else
                        {
                            Console.WriteLine(": Unplayable");

                        }
                        break;
                    case PiecePos.Moving:
                        Console.Write(": Playable");
                        Console.WriteLine(" | Distance to goal: " + p.GetDistToGoal());
                        choices++;
                        break;
                    case PiecePos.Goal:
                        Console.WriteLine(" : Unplayable");
                        break;
                }
            }
            
            if (choices != 0)
            {
                PieceChoice(dRoll);
                q = 0;
                lm.BreakLine();
                Console.WriteLine(q+" roll(s) left...");
                lm.BreakLine();
            }
            else
            {
                lm.BreakLine();
                Console.WriteLine("No actions available...");
                lm.BreakLine();
                Console.WriteLine(q-1+" roll(s) left...");
                lm.BreakLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    //bruges til at udregne/finde ud af om en spiller har alle brikker i mål/har vundet
    public bool PlayerInGoal(Piece[] pieces)
    {
        bool playerInGoal =true;
        foreach (Piece p in this.pieces)
        {
            //hvis brikken ikke er i mål, så er værdien false.
            if (p.GetPos()!=PiecePos.Goal)
            {
                playerInGoal = false;
                break;
            }
            
        }
        return playerInGoal;
    } 



    //get functions and low-line-use functions
    public int GetId()
    {
        return this.playerId;
    }

    public int GetDistToGoal()
    {
        return this.distToGoal;
    }

    public PlayerPos GetPos()
    {
        return this.pos;
    }

    public void DiceRollMsg()
    {
        Console.WriteLine("Player "+playerId+" rolled "+plDice.GetThrow()+"!");

    }
    public Piece[] GetPieces()
    {
        return this.pieces;
    }

    
}