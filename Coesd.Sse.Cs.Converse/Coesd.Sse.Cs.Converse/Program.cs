using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coesd.Lib.Cs.ConsoleWrite;

namespace Coesd.Sse.Cs.Converse
{
    /// <summary>
    /// Simple Console Application to write supplied text to the Console
    /// </summary>
    class Program
    {
        /// <summary>
        /// Write text to Console
        /// </summary>
        /// <param name="args">text to be written to the Console</param>
        static void Main(string[] args)
        {
            string SpecifiedText = args[0];
            var Converse = new ShowText(SpecifiedText);
            Converse.ConsoleWrite();
        }
    }
}
