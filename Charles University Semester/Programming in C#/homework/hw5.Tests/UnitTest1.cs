namespace hw5.Tests;

public class TextJustifierTests
{
    [Theory]

    [InlineData("", 4, "")]

    [InlineData(" \t\n\n\t  \n", 8, "")]

    [InlineData("hello", 8, "hello\n")]

    [InlineData("one\t two\nthree", 20, "one two three\n")]

    [InlineData("aa bb cc", 5, "aa bb\ncc\n")]

    [InlineData("a b c dddd", 7, "a  b  c\ndddd\n")]

    [InlineData("a b c dddd", 8, "a   b  c\ndddd\n")]

    [InlineData("\n \t\none\n \t\n\n two\n\n", 10, "one\n\ntwo\n")]

    [InlineData("a enormous b", 4, "a\nenormous\nb\n")]

    [InlineData("a b cc d", 1, "a\nb\ncc\nd\n")]

    [InlineData(
    "If a train station is where the train stops, what is a work station?",
    17,
    "If     a    train\n" +
    "station  is where\n" +
    "the  train stops,\n" +
    "what  is  a  work\n" +
    "station?\n")]

    public void JustifiesText(
        string input,
        int width,
        string expected)
    {
        using var reader = new StringReader(input);
        var tokenReader = new TokenReader(reader);
        using var writer = new StringWriter();

        var justifier = new TextJustifier(tokenReader);

        justifier.JustifyText(writer, width);

        Assert.Equal(expected, writer.ToString());
    }
}
