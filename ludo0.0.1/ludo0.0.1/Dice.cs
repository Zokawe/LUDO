using System;

//terning class
class Dice
{
    private int diceThrow;


    //terningkast, bruger kun en simpel Random();
    public int DiceThrow()
    {
        Random diceRnd = new Random();

        diceThrow = diceRnd.Next(1, 7);


        return diceThrow;
    }
    //metode til at samle/hente værdien af terningkastet
    public int GetThrow()
    {
        DiceThrow();

        return diceThrow;
    }
}