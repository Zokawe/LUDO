using System;
using System.Runtime.InteropServices;


class Game
{
    public void GameX()
    {
        var gameState = 0;

        Console.WriteLine("Welcome to the Ludo. \nYou have 1 token to move.");
        Console.ReadLine();

        Player p1 =new Player();
        p1.Move();




        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\JSL\Desktop\ludo.txt");

        //// Display the file contents by using a foreach loop.
        
        //foreach (string line in lines)
        //{
        //    // Use a tab to indent each line of the file.
        //    Console.WriteLine(line);
        //}


        string lineRead = Console.ReadLine();


    }


}