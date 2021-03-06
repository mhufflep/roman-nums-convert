using System;
using System.Text;

public class RomanConverter
{
	private string allowedSymbols = "IVXLCDM";
	private bool badNum;
	private int number;
	private string input;
	
	public RomanConverter(string input)
	{
		this.input = input.ToUpper();
		badNum = false;
		number = 0;
	}
	
	public int getArabicNumeral()
	{
		return number;
	}
	
	public string getRomanNumeral()
	{
		return input;
	}
	
	public bool badConvert()
	{
		return badNum;
	}
	
	private int getRomanNumeral(int index)
	{
		int number = (int)Math.Pow(10, index / 2);
		if (index % 2 != 0)
			number *= 5;
		return number;
	}
	
	private int getIndex(char s)
	{
		int index = allowedSymbols.IndexOf(s);
		if (index == -1)
			badNum = true;
		return index;
	}
	
	public void Convert()
	{
		int currIndex;
		int nextIndex;
		
		if (input.Length == 1)
		{
			currIndex = getIndex(input[0]);
			if (!badNum)
				number = getRomanNumeral(currIndex);
		}
		else
		{
			for (int i = 1; i < input.Length; i++)
			{	
				currIndex = getIndex(input[i - 1]);
				nextIndex = getIndex(input[i]); 
				if (badNum)
					break;
				if (nextIndex <= currIndex)
					number += getRomanNumeral(currIndex);
				else
					number -= getRomanNumeral(currIndex);
				if (i == input.Length - 1)
					number += getRomanNumeral(nextIndex);
			}
		}
	}
}

public class Program
{	
	public static void Main()
    {
		Console.Write("Roman numerals: ");
        string input = Console.ReadLine();
		
		RomanConverter conv = new RomanConverter(input);
		conv.Convert();
		
		if (!conv.badConvert())
			Console.WriteLine("Arabic numerals: {0}", conv.getArabicNumeral());
		else
			Console.WriteLine("Error: Invalid symbols in line");
    }
}
