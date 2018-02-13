using System;

class Dice
{
    private int diceThrow;
    public int DiceThrow()
    {
        Random diceRnd = new Random();

        diceThrow = diceRnd.Next(1, 7);


        return diceThrow;
    }

    public int GetThrow()
    {
        DiceThrow();

        return diceThrow;
    }
}