namespace CaesarCypherCode1;

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

    private static Dictionary<char, int> OrderMostFrequentLetter(string encodedMessage)
    {
        Dictionary<char, int> letterCounter = new Dictionary<char, int>();
        
        for (int i = 0; i < encodedMessage.Length; i++)
        {
            //FIX ME: There needs to be logic here to loop till we get the correct shift

            if (char.IsLetter(encodedMessage[i]))
            {
                if (!letterCounter.ContainsKey(char.ToLower(encodedMessage[i])))
                {
                    letterCounter.Add(char.ToLower(encodedMessage[i]), 1);
                }
                else
                {
                    letterCounter[char.ToLower(encodedMessage[i])]++;
                }
            }
        }
        var mostCommonLetters = letterCounter.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);;
        return mostCommonLetters;
    }

    private static int FindShift(string encodedMessage)
    {
        int shift = 0;
        char mostFrequentLetter = OrderMostFrequentLetter(encodedMessage).First().Key;
        
        shift = mostFrequentLetter - 'e';
        if (shift < 0)
        {
            shift = 'z' - shift;
        }
        return shift;
    }
}