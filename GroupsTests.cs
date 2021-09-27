using System.Text.RegularExpressions;
using Xunit;

namespace RegularExpressionsWalks
{
    public class GroupsTests
    {
        [Fact]
        public void Or()
        {
            var pattern = new Regex("java|dotnet");
            Assert.True(pattern.IsMatch("java"));
            Assert.True(pattern.IsMatch("dotnet"));
        }

        [Fact]
        public void CapturingGroup()
        {
            var pattern = new Regex(@"(I love dotnet)\s\1");
            var text = "I love dotnet I love dotnet";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);
            Assert.Equal(match.Value.Length, text.Length);

            Assert.Equal(2, match.Groups.Count);
        }

        [Fact]
        public void NonCapturingGroup()
        {
            var pattern = new Regex(@"(?:Why )(I love dotnet)\s\1");
            var text = "Why I love dotnet I love dotnet";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);
            Assert.Equal(match.Value.Length, text.Length);

            Assert.Equal(2, match.Groups.Count);
        }

        [Fact]
        public void CapturingGroupCaptures()
        {
            var pattern = new Regex(@"(I love dotnet)*");
            var text = "I love dotnetI love dotnet";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);

            // match.Groups[0] = everything
            // match.Groups[1] - first group in regular expression
            Assert.Equal(2, match.Groups.Count);
            Assert.Equal(2, match.Groups[1].Captures.Count);
        }

        [Fact]
        public void CapturingGroupCapturesNumber()
        {
            var pattern = new Regex(@"(I love dotnet){2}");
            var text = "I love dotnetI love dotnet";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);

            // match.Groups[0] = everything
            // match.Groups[1] - first group in regular expression
            Assert.Equal(2, match.Groups.Count);
            Assert.Equal(2, match.Groups[1].Captures.Count);
        }


        [Fact]
        public void NamedCapturingGroup()
        {
            var pattern = new Regex(@"(?<something>I love dotnet)\s\k<something>");
            var text = "I love dotnet I love dotnet";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);
            Assert.Equal(match.Value.Length, text.Length);
            Assert.Equal(2, match.Groups.Count);

            var group = match.Groups["something"];

            Assert.Single(group.Captures);
        }

        [Fact]
        public void NamedCapturingGroupRedefined()
        {
            var pattern = new Regex(@"(?<something>I love dotnet)\s(?<something>tmp)");
            var text = "I love dotnet tmp";

            Assert.True(pattern.IsMatch(text));

            var match = pattern.Match(text);
            Assert.NotNull(match);
            Assert.Equal(match.Value.Length, text.Length);
            Assert.Equal(2, match.Groups.Count);

            var group = match.Groups["something"];

            Assert.Equal(2, group.Captures.Count);
        }

        [Fact]
        public void BalacingGroups()
        {
            var pattern = new Regex(@"^((?:[^}{])|(?<something>{)|(?<-something>}))*(?(something)(?!))$");

            Assert.True(pattern.IsMatch("{}"));
            Assert.True(pattern.IsMatch("{{abc}}"));
            Assert.False(pattern.IsMatch("{{"));
            Assert.False(pattern.IsMatch("{{}"));
        }
    }
}
