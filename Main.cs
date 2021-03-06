using System;
using System.Text;

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
