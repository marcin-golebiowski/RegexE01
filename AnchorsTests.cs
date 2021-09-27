using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace RegularExpressionsWalks
{
    public class AnchorsTests
    {
        [Fact]
        public void Test_Multiline_Start()
        {
            var pattern = new Regex("^Test", RegexOptions.Multiline);

            var lines = @"Test
Test
Test";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal("Test", result[0]);
            Assert.Equal("Test", result[1]);
            Assert.Equal("Test", result[2]);

            var matches = pattern.Matches(lines);
            Assert.Equal(3, matches.Count);
        }

        [Fact]
        public void Test_Multiline_StartAbsolute()
        {
            var pattern = new Regex(@"\ATest", RegexOptions.Multiline);

            var lines = @"Test line
Test line
Test line";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();


            Assert.Single(result);
            Assert.Equal(result[0], @"Test");
        }

        [Fact]
        public void Test_SingleLine_Start()
        {
            var pattern = new Regex("^Test", RegexOptions.Singleline);

            var lines = @"Test line
Test line
Test line";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();

            Assert.Single(result);
            Assert.Equal(@"Test", result[0]);
        }

        [Fact]
        public void Test_SingleLine_End()
        {
            var pattern = new Regex("line$", RegexOptions.Singleline);

            var lines = @"First line
Second line
Third line";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();

            Assert.Single(result);
            Assert.Equal(@"line", result[0]);
            var matches = pattern.Matches(lines);
        }


        [Fact]
        public void Test_Multiline_EndAbsolute()
        {
            var pattern = new Regex(@"line\z", RegexOptions.Multiline);

            var lines = @"First line
Second line
Third line";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();

            Assert.Single(result);
            Assert.Equal(@"line", result[0]);
            var matches = pattern.Matches(lines);
        }

        [Fact]
        public void Test_Multiline_End()
        {
            var pattern = new Regex(@"line$", RegexOptions.Multiline);

            var lines = @"First line
Second line
Third line";

            var result = pattern.Matches(lines).Select(p => p.Value).ToArray();

            Assert.Single(result);
            Assert.Equal(@"line", result[0]);
            var matches = pattern.Matches(lines);
        }
    }
}
