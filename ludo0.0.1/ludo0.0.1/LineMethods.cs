using System;

//class til metoder brugt til at simplificere string metoder i console programmer
public class LineMethods
{
    //breakline til at simplificere adskillelse i consolevindue
    public void BreakLine()
    {
        Console.WriteLine("--------------------------------");
    }
    //bruges til at tjekke om input ikke er tomt, og er korrekt konverteret
    public bool InputCheck(string Input)
    {
        int inputConverted;

        bool ConvertSuccess = int.TryParse(Input, out inputConverted);
        if (ConvertSuccess == false || string.IsNullOrEmpty(Input) || string.IsNullOrWhiteSpace(Input))
        {

            return false;
        }
        else
        {
            return true;
        }
    }
}