using System;
using System.Runtime.Remoting.Messaging;

//enum til at afgøre brikposition
public enum PiecePos { Spawn, Moving, Safe, Goal };

//Class for ludobrikker
class Piece
{

    public PiecePos pos;

   // private int playerState = 0; //change to enum later 0 = home, 1 = moving, 2 = in goal and add 'safe spots'
    private int mapLength = 56;
    private int distToGoal;
    private int spawnDist = 13;
    //private int offset = 0; //planlagt til senere brug, for at udregne afstanden mellem spillere/når brikker mødes

    //initialization of objects/classes
        LineMethods lm = new LineMethods();
        public Piece[] pieces;
        Dice plDice = new Dice();

        private int pieceId;

        //constructor
        public Piece(int id)
        {
            this.pieceId = id;
            //this.offset = (id - 1) * (13); //used to calculate the difference in player paths
            this.distToGoal = mapLength;
        }

        //metode der styrer den overordnede del af spillet (hvordan spiller bevæger sig fra start til slut med terningkast)
        //bruger distToGoal som den primære værdi til at afgøre brikryk
        public void Move(int diceRoll)
        {
            Console.WriteLine();
            switch (pos)
            {
            //switchcase, der arbejder ud fra brikposition
                case PiecePos.Spawn:

                    if (diceRoll == 6)
                    {
                        lm.BreakLine();
                        Console.WriteLine("Piece#" + pieceId + " has left spawn!");
                        pos = PiecePos.Moving;
                    }
                    Console.WriteLine();

                    break;
                case PiecePos.Moving:
                    lm.BreakLine();
                    Console.WriteLine("Piece#" + pieceId + " Has been moved.");
                    distToGoal = distToGoal - diceRoll;


                    if (distToGoal < 0)
                    {
                        distToGoal = distToGoal * (-1);
                    }
                    else if (distToGoal == 0)
                    {
                        pos = PiecePos.Goal;
                    }

                    Console.WriteLine("Distance to goal: " + (distToGoal));
                    lm.BreakLine();

                    
                    break;
                case PiecePos.Goal:
                    lm.BreakLine();
                    Console.WriteLine("Piece#"+pieceId+" has reached the goal!");
                    
                    break;
            }
            Console.ReadKey();

        }

    //get metoder
        public int GetId()
        {
            return this.pieceId;
        }

        public int GetDistToGoal()
        {
            return this.distToGoal;
        }

        

        public PiecePos GetPos()
        {
        return this.pos;
        }


}

