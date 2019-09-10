using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Tools
{
    class BinaryTool
    {
        private readonly int[] binaryConstants =
        {
            1 << 9,
            1 << 8,
            1 << 7,
            1 << 6,
            1 << 5,
            1 << 4,
            1 << 3,
            1 << 2,
            1 << 1,
            1
        };

        private Dictionary<string, int> hexConstants = new Dictionary<string, int>
        {
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "A", 10 },
            { "B", 11 },
            { "C", 12 },
            { "D", 13 },
            { "E", 14 },
            { "F", 15 },
        };

        /*
         * Assuming no values are above 750
         * 512 256 128 64 32 16 8 4 2 1
         * 7 to 0111 
         */
        public string DecimalToBinary(int dec)
        {
            if (dec >= 750)
                throw new InvalidOperationException("Don't input decimal >= 750");

            string output = "";

            int currentRemainder = dec;

            foreach (int constant in binaryConstants)
            {
                if ((currentRemainder - constant) >= 0)
                {
                    output = output + "1";
                    currentRemainder -= constant;
                }
                else
                {
                    output = output + "0";
                }
            }

            return output;
        }

        /*
         * 512 256 128 64 32 16 8 4 2 1
         * 0111 to 7
         */
        public int BinaryToDecimal(string binary)
        {
            int output = 0;

            // "11100110"
            // 128 64 32 4 2

            var revseredBinary = binary.Reverse().ToArray();
            var revseredConstants = binaryConstants.Reverse().ToArray();

            // Iterate from back to front
            for (int i = 0; i < revseredBinary.Length; i++)
            {
                if (revseredBinary[i] == '1')
                {
                    output += revseredConstants[i];
                }
            }

            return output;
        }

        /*
         * 1 2 3 4 5 6 7 8 9 A B C D E F 10 11
         * FA to 250
         */
        public int HexToDecimal(string hex)
        {
            int output = 0;

            // "11100110"
            // 128 64 32 4 2

            var reversedHex = hex.Reverse().ToArray();

            // Iterate from back to front
            for (int i = 0; i < reversedHex.Length; i++)
            {
                if (reversedHex[i] != '0')
                {
                    output += hexConstants[reversedHex[i].ToString().ToUpper()] * (int)Math.Pow(16, i);
                }
            }

            return output;
        }

        public string HexToBinary(string hex)
        {
            return DecimalToBinary(HexToDecimal(hex));
        }

        public int OctalToDecimal(int octal)
        {
            int output = 0;

            var reversedOctal = octal.ToString().Reverse().ToArray();

            // Iterate from back to front
            for (int i = 0; i < reversedOctal.Length; i++)
            {
                if (reversedOctal[i] != '0')
                {
                    output += int.Parse(reversedOctal[i].ToString()) * (int)Math.Pow(8, i);
                }
            }

            return output;
        }

        public string OctalToBinary(int octal)
        {
            return DecimalToBinary(OctalToDecimal(octal));
        }

    }
}
