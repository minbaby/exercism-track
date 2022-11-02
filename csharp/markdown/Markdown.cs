using System;
using System.Text.RegularExpressions;

/// <summary>
/// <see cref="https://exercism.org/tracks/csharp/exercises/markdown/solutions/Nia11"/>
/// </summary>
public static class Markdown
{
    public static string Parse(string markdown)
    {
        markdown = Regex.Replace(markdown, "^###### ([^\n$]+)", "<h6>$1</h6>");
        markdown = Regex.Replace(markdown, "^##### ([^\n$]+)", "<h5>$1</h5>");
        markdown = Regex.Replace(markdown, "^#### ([^\n$]+)", "<h4>$1</h4>");
        markdown = Regex.Replace(markdown, "^### ([^\n$]+)", "<h3>$1</h3>");
        markdown = Regex.Replace(markdown, "^## ([^\n$]+)", "<h2>$1</h2>");
        markdown = Regex.Replace(markdown, "^# ([^\n$]+)", "<h1>$1</h1>");
        markdown = Regex.Replace(markdown, @"(^|\n)\* ([^\n$]+)", "<li>$2</li>");
        markdown = Regex.Replace(markdown, @"^(^|((?!(<li>)).)+)(<li>.+)", "$1<ul>$4");
        markdown = Regex.Replace(markdown, @"</li>(\n|$)", "</li></ul>");
        markdown = Regex.Replace(markdown, @"__(((?!(__)).)+)__", "<strong>$1</strong>");
        markdown = Regex.Replace(markdown, @"_(((?!(_)).)+)_", "<em>$1</em>");
        markdown = Regex.Replace(markdown, @"^(<strong>.+</strong>)$", "<p>$1</p>");
        markdown = Regex.Replace(markdown, @"^(<em>.+</em>)$", "<p>$1</p>");
        markdown = Regex.Replace(markdown, @"^([^<].*)$", "<p>$1</p>");
        markdown = Regex.Replace(markdown, @">([\w\s]+)$", "><p>$1</p>");
        return markdown;
    }
}