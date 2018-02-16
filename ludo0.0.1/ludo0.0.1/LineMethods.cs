using System;

public class LineMethods
{
    public void BreakLine()
    {
        Console.WriteLine("--------------------------------");
    }
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