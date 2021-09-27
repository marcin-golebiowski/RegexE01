using System.Text.RegularExpressions;
using Xunit;

namespace RegularExpressionsWalks
{
    public class QuantifiersTests
    {
        [Fact]
        public void ZeroOrMore()
        {
            var pattern = new Regex("a*b*c");
            Assert.True(pattern.IsMatch("abc"));
        }

        [Fact]
        public void Specific()
        {
            var pattern = new Regex(@"^a{2,4}b{3,}c{0,5}");
            Assert.True(pattern.IsMatch("aabbbbccccc"));
        }

        [Fact]
        public void AtLeastOne()
        {
            var pattern = new Regex("^a+b+c$");
            Assert.True(pattern.IsMatch("abc"));
            Assert.True(pattern.IsMatch("aabbbc"));
            Assert.False(pattern.IsMatch("ac"));
        }

        [Fact]
        public void Optional()
        {
            var pattern = new Regex("^a?b$");
            Assert.True(pattern.IsMatch("b"));
        }
    }
}
