using System;

class Player
{
    private int placement = 0; //change to enum later 0 = home, 1 = moving, 2 = in goal
    private int distToGoal = 56;
    Dice plDice = new Dice();

    public void Move()
    {
        while (true)
        {


            switch (placement)
            {
                case 0:
                    Console.WriteLine("Token placed in home.");
                    if (plDice.GetThrow() == 6)
                    {
                        placement = 1;
                    }
                    break;
                case 1:
                    Console.WriteLine("Token is moving.");
                    distToGoal = distToGoal - plDice.GetThrow();
                    
                    if (distToGoal<0)
                    {
                        distToGoal =distToGoal*(-1);
                    }
                    else if (distToGoal == 0)
                    {
                        placement = 2;
                    }
                    Console.WriteLine("Distance to goal: " + (distToGoal));
                    break;
                case 2:
                    Console.WriteLine("Goal reached");
                    break;
            }
            Console.ReadKey();
            

        }
    }

}




