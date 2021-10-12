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
            var text = "ax acad abaaaaa xxxabxxxx";

            var matches = pattern.Matches(text);
            Assert.Single(matches);
        }

        [Fact]
        public void LookAheadPositive2_Before()
        {
            var pattern = new Regex(@"(?=[^ .]*ab[^ .]*)\b[a-z]+");
            var text = "ax acad abaaaaa xxxabxxxx";

            var matches = pattern.Matches(text);
            Assert.Equal(2, matches.Count);
            Assert.Equal("abaaaaa", matches[0].Value);
            Assert.Equal("xxxabxxxx", matches[1].Value);
        }

        [Fact]
        public void LookAheadNegative_Before()
        {
            var pattern = new Regex(@"(?!ab)\b[a-z]+");
            var text = "ab acad abaaaaa aabxxx";

            var matches = pattern.Matches(text);

            Assert.NotNull(matches);
            Assert.Equal("acad", matches[0].Value);
            Assert.Equal("aabxxx", matches[1].Value);
        }

        [Fact]
        public void LookAheadNegative2_Before()
        {
            var pattern = new Regex(@"(?![^ .]*ab[^ .]*)\b[a-z]+");
            var text = "ab acad abaaaaa aabxxx";

            var matches = pattern.Matches(text);

            Assert.NotNull(matches);
            Assert.Single(matches);
            Assert.Equal("acad", matches[0].Value);
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
        public void LookBehindPositive2_Before()
        {
            var pattern = new Regex(@"(?<=.*I love.* )You");
            var text = "I love very much You";

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

        [Fact]
        public void LookBehindNegative2_Before()
        {
            var pattern = new Regex(@"(?<!.*I hate.* )You");
            var text = "I hate and love You";

            var matches = pattern.Matches(text);

            Assert.NotNull(matches);
            Assert.Empty(matches);
        }
    }
}
