using System.Text.RegularExpressions;
using Xunit;

namespace RegularExpressionsWalks
{
    public class AssertionsTests
    {
        [Fact]
        public void LookAheadPositive_After()
        {
            var pattern = new Regex(@"\b[a-z]+(?=ab)");
            var text = "ax acab abaaaaa";

            var match = pattern.Match(text);

            Assert.NotNull(match);
            Assert.Equal("ac", match.Value);
        }
        [Fact]
        public void LookAheadPositive_Before()
        {
            var pattern = new Regex(@"(?=ab)\b[a-z]+");
            var text = "ax acad abaaaaa";

            var match = pattern.Match(text);

            Assert.NotNull(match);
            Assert.Equal("abaaaaa", match.Value);
        }

        [Fact]
        public void LookAheadNegative_Before()
        {
            var pattern = new Regex(@"(?!ab)\b[a-z]+");
            var text = "ab acad abaaaaa";

            var match = pattern.Match(text);

            Assert.NotNull(match);
            Assert.Equal("acad", match.Value);
        }

        [Fact]
        public void LookBehindPositive_Before()
        {
            var pattern = new Regex(@"(?<=I love )You");
            var text = "I love You";

            var match = pattern.Match(text);

            Assert.NotNull(match);
            Assert.Equal("You", match.Value);
        }

        [Fact]
        public void LookBehindNegative_Before()
        {
            var pattern = new Regex(@"(?<!I hate )You");
            var text = "I love You";

            var match = pattern.Match(text);

            Assert.NotNull(match);
            Assert.Equal("You", match.Value);
        }
    }
}
