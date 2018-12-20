import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Anagram 
{
    private char[] charArray;

    public Anagram(String string)
    {
        this.charArray = string.toLowerCase().toCharArray();
        Arrays.sort(this.charArray);
    }

    public List<String> match(List<String> list) 
    {
        List<String> ret = new ArrayList<String>();
        for (String t : list) {
            char[] tmpArray = t.toLowerCase().toCharArray();
            Arrays.sort(tmpArray);
            if (Arrays.equals(this.charArray, tmpArray)) {
                ret.add(t);
            }
        }

        return ret;
    }
}