import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Anagram 
{
    private char[] charArray;

    private String string;

    public Anagram(String string)
    {
        this.string = string.toLowerCase();
        this.charArray = this.string.toCharArray();
        Arrays.sort(this.charArray);
    }

    public List<String> match(List<String> list) 
    {
        List<String> ret = new ArrayList<String>();
        String tmpString;
        char[] tmpArray;
        for (String t : list) {
            tmpString = t.toLowerCase();
            if (tmpString.equals(this.string)) {
                break;
            }
            
            tmpArray = tmpString.toCharArray();
            Arrays.sort(tmpArray);
            if (Arrays.equals(this.charArray, tmpArray)) {
                ret.add(t);
            }
        }

        return ret;
    }
}