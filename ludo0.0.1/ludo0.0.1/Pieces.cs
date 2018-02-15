using System;
using System.Runtime.Remoting.Messaging;


public enum PiecePos { Spawn, Moving, Safe, Goal };

class Piece
{

    public PiecePos pos;

   // private int playerState = 0; //change to enum later 0 = home, 1 = moving, 2 = in goal and add 'safe spots'
    private int mapLength = 56;
    private int distToGoal;
    private int spawnDist = 13;
    private int offset = 0;
        LineMethods lm = new LineMethods();
        public Piece[] pieces;
        Dice plDice = new Dice();

        private int pieceId;

        public Piece(int id)
        {
            this.pieceId = id;
            //this.offset = (id - 1) * (13); //used to calculate the difference in player paths
            this.distToGoal = mapLength;
        }


        public void Move(int diceRoll)
        {
            Console.WriteLine();
            switch (pos)
            {
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

