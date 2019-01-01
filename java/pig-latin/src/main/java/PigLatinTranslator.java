import java.util.regex.Pattern;
import java.util.regex.Matcher;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class PigLatinTranslator
{
    private static final Pattern VOWELISH = Pattern.compile("^([aeiou]|y[^aeiou]|xr)");
    private static final Pattern CONSONANTISH = Pattern.compile("^([^aeiou]?qu|[^aeiouy]+|y(?=[aeiou]))");

    public String translate(String input) {
        return Pattern.compile(" ").splitAsStream(input)
                .map(PigLatinTranslator::translateWord)
                .collect(Collectors.joining(" "));
    }

    private static String translateWord(String word) {
        return rotateLetters(word, numberOfLettersToMove(word)) + "ay";
    }

    private static int numberOfLettersToMove(String word) {
        if (VOWELISH.matcher(word).find())
            return 0;
        else
            return Stream.of(CONSONANTISH)
                    .map(pattern -> pattern.matcher(word))
                    .filter(Matcher::find)
                    .mapToInt(Matcher::end)
                    .findFirst()
                    .orElse(0);
    }

    private static String rotateLetters(String word, int num) {
        return word.substring(num) + word.substring(0, num);
    }
}