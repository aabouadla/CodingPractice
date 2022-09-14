using System;

namespace CodingPractice.Search
{
    public class RotationalCipher
    {
        public static void Test()
        {
            Console.WriteLine("############# TEST 1 ######################");
            string input_1 = "Zebra-493?";
            int rotationFactor_1 = 3;
            string expected_1 = "Cheud-726?";

            Console.Write("Expected: ");
            Console.Write(expected_1 + " ");
            Console.WriteLine("");
            Console.Write(" Result: ");
            Console.Write(rotationalCipher(input_1, rotationFactor_1) + " ");
            Console.WriteLine("");

            String input_2 = "All-convoYs-9-be:Alert1.";
            int rotationFactor_2 = 4;
            String expected_2 = "Epp-gsrzsCw-3-fi:Epivx5.";
            String output_2 = rotationalCipher(input_2, rotationFactor_2);

            Console.Write("Expected: ");
            Console.Write(expected_2 + " ");
            Console.WriteLine("");
            Console.Write(" Result: ");
            Console.Write(rotationalCipher(input_2, rotationFactor_2) + " ");
            Console.WriteLine("");

            
        }

        private static string rotationalCipher(String input, int rotationFactor)
        {

            string output = string.Empty;
            string smallChars = "abcdefghijklmnopqrstuvwxyz";
            string cpaitalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ints = "0123456789";

            foreach (char ch in input)
            {
                char cipherCH = ch;
                int outpunIdx = rotationFactor;
                // check if the ch is a Capital letter
                if (ch >= 'A' && ch <= 'Z')
                {
                    outpunIdx = (cpaitalChars.IndexOf(ch) + rotationFactor) % 26;
                    cipherCH = cpaitalChars[outpunIdx];
                }

                // check if the ch is a Small letter
                if (ch >= 'a' && ch <= 'z')
                {
                    outpunIdx = (smallChars.IndexOf(ch) + rotationFactor) % 26;
                    cipherCH = smallChars[outpunIdx];
                }

                // check if the ch is a Digit
                if (ch >= '0' && ch <= '9')
                {
                    outpunIdx = (ints.IndexOf(ch) + rotationFactor) % 10;
                    cipherCH = ints[outpunIdx];
                }

                output += cipherCH;
            }

            return output;

        }

        //private static string rotationalCipher(String input, int rotationFactor)
        //{
        //    string smallLetters = "abcdefghijklmnopqrstuwxyz";
        //    string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUWXYZ";
        //    string nums = "123456789";

        //    // check the rotationFactor (0 <= rotationFactor <= 1,000,000)
        //    if (rotationFactor <= 0)
        //        return input;

        //    StringBuilder result = new StringBuilder();
        //    foreach (char ch in input)
        //    {
        //        char rotatedChar = ch;
        //        if (ch >= 'A' && ch <= 'Z')
        //        {
        //            int idxChar = (ch - 'A') + rotationFactor;
        //            if (idxChar > 25)
        //                idxChar %= 26;
        //            rotatedChar = (char)(capitalLetters[idxChar]);
        //        }               
        //        else if (ch >= 'a' && ch <= 'z')
        //        {
        //            int idxChar = (ch - 'a') + rotationFactor;
        //            if (idxChar > 25)
        //                idxChar %= 26;
        //            rotatedChar = (char)(smallLetters[idxChar]);
        //        }
        //        else if (ch >= '1' && ch <= '9')
        //        {
        //            int idxChar = (ch - '0') + rotationFactor;
        //            if (idxChar > 9)
        //                idxChar %= 10;

        //            rotatedChar=nums[idxChar-1];
        //        }

        //        result.Append(rotatedChar);
        //    }

           
        //    return result.ToString();
        //}
    }
}
