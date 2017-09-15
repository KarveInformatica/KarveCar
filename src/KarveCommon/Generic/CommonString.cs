using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{ 
    /// <summary>
    ///  Helper methods for the manipulating strings.
    /// </summary>
   public class CommonString
    {
        /// <summary>
        ///  Slicing a string in parts 
        ///  string s = "Hello World!";
        ///  world = Right(s, 6);
        ///  in the world part we have "World!"
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="pos">position to cut the string</param>
        /// <returns></returns>
        public static string Right(string input, int pos)
        {
            return input.Substring(pos);            
        }
        /// <summary>
        /// Fills spaces to the left with the char c
        /// </summary>
        /// <param name="input">string to be used</param>
        /// <param name="c">character to be used</param>
        /// <param name="len">lenght of replicate the c to the left</param>
        /// <returns></returns>
        public static string FDer(string input, char c, int len)
        {
            int inputLenght = input.Length;
            if (inputLenght >= len)
            {
                return input;
            }
            else
            {
                int pos = len - inputLenght;
                string tmpDer = "";
                for (int i = 0; i < pos; ++i)
                {
                    tmpDer += c;
                }
                tmpDer = tmpDer + input;
                return tmpDer;
            }
        }
    }
}
