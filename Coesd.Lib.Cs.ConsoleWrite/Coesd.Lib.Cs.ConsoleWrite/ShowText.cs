using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Simple Class to demonstrate use of NuGet
/// </summary>
namespace Coesd.Lib.Cs.ConsoleWrite
{
    public class ShowText
    {
        public string UserText { get; private set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="textToPrint">text that will be written to the Console</param>
        public ShowText(string textToPrint)
        {
            this.UserText = textToPrint;
        }

        /// <summary>
        /// Write the value of UserText to the Console
        /// </summary>
        public void ConsoleWrite()
        {
            Console.WriteLine(this.UserText);
        }
    }
}
