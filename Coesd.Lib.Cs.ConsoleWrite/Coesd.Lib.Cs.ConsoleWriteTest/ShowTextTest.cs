using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Coesd.Lib.Cs.ConsoleWrite;

namespace Coesd.Lib.Cs.ConsoleWriteTests
{
    public class ShowTextTest
    {
        private readonly ShowText ShowText;
        public ShowTextTest()
        {
            this.ShowText = new ShowText("Hello World");
        }

        [Fact]
        public void HelloWorldTest()
        {
            Assert.True(ShowText.UserText.Equals("Hello World"));
        }

        [Fact]
        public void EndOfDaysTest()
        {
            Assert.False(ShowText.UserText.Equals("End Of Days"));
        }
    }
}
