namespace CaesarCypherCode1;
using System;
using System.Linq;

public static class CaesarCypher
{
    //', space, -, 
    //around the alphabet
    
    public static string Encode(string message, int shift)
    {
        string encodedMessage = "";
        for (int i = 0; i < message.Length; i++)
        {
            //checks for special characters
            if (char.IsLetter(message[i]))
            {
                if (char.IsUpper(message[i]))
                {
                    encodedMessage += (char)('A' + (message[i] - 'A' + shift) % 26);
                }
                else
                {
                    encodedMessage += (char)('a' + (message[i] - 'a' + shift) % 26);
                }
            }
            else
            {
                encodedMessage += message[i];
            }
        }
        return encodedMessage;
    }
    public static string Decode(string message, int shift)
    {
        string decodedMessage = "";
        for (int i = 0; i < message.Length; i++)
        {
            if (char.IsLetter(message[i]))
            {
                if (char.IsUpper(message[i]))
                {
                    decodedMessage += (char)('A' + (message[i] - 'A' - shift + 26) % 26);
                }
                else
                {
                    decodedMessage += (char)('a' + (message[i] - 'a' - shift + 26) % 26);
                }
            }
            else
            {
                decodedMessage += message[i];
            }
        }
        return decodedMessage;
    }

    public static string Crack(string encodedMessage)
    {
        int shift = FindShift(encodedMessage);
        string decodedMessage = Decode(encodedMessage, shift);
        Console.WriteLine(decodedMessage);
        return decodedMessage;
    }

    // private static Dictionary<char, int> OrderMostFrequentLetter(string encodedMessage)
    // {
    //     Dictionary<char, int> letterCounter = new Dictionary<char, int>();
    //     
    //     for (int i = 0; i < encodedMessage.Length; i++)
    //     {
    //         //FIX ME: There needs to be logic here to loop till we get the correct shift
    //
    //         if (char.IsLetter(encodedMessage[i]))
    //         {
    //             if (!letterCounter.ContainsKey(char.ToLower(encodedMessage[i])))
    //             {
    //                 letterCounter.Add(char.ToLower(encodedMessage[i]), 1);
    //             }
    //             else
    //             {
    //                 letterCounter[char.ToLower(encodedMessage[i])]++;
    //             }
    //         }
    //     }
    //     var mostCommonLetters = letterCounter.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);;
    //     return mostCommonLetters;
    // }

    private static int FindShift(string encodedMessage)
    {
        int shift = 0;
        // char mostFrequentLetter = OrderMostFrequentLetter(encodedMessage).First().Key;
        
        var frequencyLettersEnglish = new Dictionary<char, double>
        {
            { 'A', 8.17 }, { 'B', 1.49 }, { 'C', 2.78 }, { 'D', 4.25 }, { 'E', 12.70 },
            { 'F', 2.23 }, { 'G', 2.02 }, { 'H', 6.09 }, { 'I', 6.97 }, { 'J', 0.15 },
            { 'K', 0.77 }, { 'L', 4.03 }, { 'M', 2.41 }, { 'N', 6.75 }, { 'O', 7.51 },
            { 'P', 1.93 }, { 'Q', 0.10 }, { 'R', 5.99 }, { 'S', 6.33 }, { 'T', 9.06 },
            { 'U', 2.76 }, { 'V', 0.98 }, { 'W', 2.36 }, { 'X', 0.15 }, { 'Y', 1.97 },
            { 'Z', 0.07 }
        };
        var countedFrequenciesInMessage = CountFrequenciesInMessage(encodedMessage);
       //calculate difference
       double bestDifference = 10000;
        for (int i = 0; i < 26; i++)
        {
            double difference = 0;
            for (int j = 0; j < 26; j++)
            {
                difference += Math.Abs(countedFrequenciesInMessage.ElementAt((j + i) % 26).Value -
                                       frequencyLettersEnglish.ElementAt(j).Value);
            }

            if (difference < bestDifference)
            {
                bestDifference = difference;
                shift = i;
            }
        }
        
        return shift;
    }

    private static Dictionary<char, double> CountFrequenciesInMessage(string encodedMessage)
    {
        Dictionary<char, double> frequencies = new Dictionary<char, double>();
        string encodedMessageCaseInsensitive = encodedMessage.ToUpper();
        int lengthOfMessage = encodedMessage.Length;
        for (int i = 0; i < 26; i++)
        {
            char currentChar = (char)('A' + i);
            int count = encodedMessageCaseInsensitive.Count(c => c == currentChar);
            double frequency = ((double)count / (double)lengthOfMessage) * 100;
            frequencies.Add(currentChar, frequency);
        }
        return frequencies;
    }
}