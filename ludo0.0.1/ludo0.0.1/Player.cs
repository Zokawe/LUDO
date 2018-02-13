using System;

class Player
{
    private int playerState = 0; //change to enum later 0 = home, 1 = moving, 2 = in goal and add 'safe spots'
    private int mapLength = 56;
    private int distToGoal;
    private int spawnDist = 13;
    private int offset = 0;
    Dice plDice = new Dice();

    private int playerId;

    public Player(int id)
    {
        this.playerId = id;
        //this.offset = (id - 1) * (13);
        this.distToGoal= mapLength;
    }


    public void Move()
    {
        
           
            switch (playerState)
            {
                case 0:
                    Console.WriteLine("Player "+playerId+"'s turn. Roll a 6 to leave spawn.");
                DiceRollMsg();
                    if (plDice.GetThrow() == 6)
                    {
                        Console.WriteLine("Player "+playerId+" has left spawn!");
                        Console.WriteLine();
                        playerState = 1;
                    }
                    Console.WriteLine();

                break;
                case 1:
                    Console.WriteLine("Player "+playerId+" is moving.");
                    distToGoal = distToGoal - plDice.GetThrow();
                    

                    if (distToGoal<0)
                    {
                        distToGoal =distToGoal*(-1);
                    }
                    else if (distToGoal == 0)
                    {
                        playerState = 2;
                    }
                    DiceRollMsg();
                    Console.WriteLine("Distance to goal: " + (distToGoal));
                    Console.WriteLine();

                //Console.WriteLine("Player "+this.playerId+"rolled a: " + plDice.GetThrow());
                // Console.WriteLine("Distance to goal: " + (distToGoal));
                break;
                case 2:
                    Console.WriteLine("Goal reached");
                    playerState++;
                    break;
            }
            Console.ReadKey();
            

        
    }

    public int GetId()
    {
        return this.playerId;
    }

    public int GetDistToGoal()
    {
        return this.distToGoal;
    }

    public int GetPlayerState()
    {
        return this.playerState;
    }

    public void DiceRollMsg()
    {
        Console.WriteLine("Player "+playerId+" rolled "+plDice.GetThrow()+"!");

    }
}




