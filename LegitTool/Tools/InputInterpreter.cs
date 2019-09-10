using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Tools
{
    public enum InputFormat
    {
        None,
        DecimalToBinary,
        BinaryToDecimal,
        DecimalToHex,
        HexToDecimal,
        HexToBinary,
        OctalToBinary
    }

    class InputInterpreter
    {

        #region Configurations
        private string m_StartPhrase;
        public string StartPhrase { get => m_StartPhrase; set => m_StartPhrase = value; }

        private string m_EndPhrase;
        public string EndPhrase { get => m_EndPhrase; set => m_EndPhrase = value; }
        #endregion

        public InputInterpreter(string startPhrase, string endPhrase)
        {
            StartPhrase = startPhrase;
            EndPhrase = endPhrase;
        }

        public InputFormat GetInputFormat(string input)
        {

            return InputFormat.None;
        }

    }
}
