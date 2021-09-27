using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace RegularExpressionsWalks
{
    public class CharacterClassesTests
    {
        [Fact]
        public void Literal()
        {
            var pattern = new Regex("abc");
            var line = @"abc abc g";

            Assert.True(pattern.IsMatch(line));

            var match = pattern.Match(line);
            var nextMatch = match.NextMatch();
        }

        [Fact]
        public void Optional()
        {
            var pattern = new Regex("^abc?$");

            Assert.True(pattern.IsMatch("ab"));
            Assert.True(pattern.IsMatch("abc"));
        }

        [Fact]
        public void Or()
        {
            var pattern = new Regex("a[01]b");
            var line = @"a0b a1b";

            Assert.True(pattern.IsMatch(line));

            var match = pattern.Match(line);
            var nextMatch = match.NextMatch();

            Assert.NotNull(match);
            Assert.NotNull(nextMatch);
        }

        [Fact]
        public void Not()
        {
            var pattern = new Regex("a[^01]b");
            var line = @"axb a1b";

            Assert.True(pattern.IsMatch(line));
            var matches = pattern.Matches(line);
            Assert.Equal(1, matches.Count);
        }

        [Fact]
        public void Digit()
        {
            var pattern = new Regex(@"\d\d");
            var line = @"99 11 77 889";

            var matches = pattern.Matches(line);
            Assert.Equal(4, matches.Count);
        }

        [Fact]
        public void Digit_WithSurprise()
        {
            var pattern = new Regex(@"\d(?=\d)");
            var line = @"99 11 77 889";

            var matches = pattern.Matches(line);

            // Surprise!
            Assert.Equal(5, matches.Count);

            var result = pattern.Matches(line).Select(p => line.Substring(p.Index, 2)).ToArray();
        }

        [Fact]
        public void Range()
        {
            var pattern = new Regex("^[b-d]+$");
            Assert.True(pattern.IsMatch("b"));
            Assert.True(pattern.IsMatch("bcd"));
            Assert.True(pattern.IsMatch("ddd"));
            Assert.False(pattern.IsMatch("e"));
        }


        [Fact]
        public void OrWithWordBoundry()
        {
            var pattern = new Regex(@"\ba[01]b\b");
            var line = @"a0ba1b";

            Assert.False(pattern.IsMatch("a0ba1b"));
            Assert.True(pattern.IsMatch("a0b a1b"));
            Assert.True(pattern.IsMatch("a0b"));
        }
    }
}
