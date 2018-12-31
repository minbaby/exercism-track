import java.util.HashMap;
import java.util.Map;

class IsogramChecker {
    boolean isIsogram(String phrase) {
        if (phrase.isEmpty()) {
            return true;
        }

        char[] charList = phrase.toCharArray();
        Map<Character, Integer> map = new HashMap<>();
        int count = 0;
        for (char ch : charList) {
            ch = Character.toLowerCase(ch);
            if (!map.containsKey(ch) || ch == '-' || ch == ' ') {
                map.put(ch, 1);
                count = 1;
                continue;
            }
            count = map.get(ch);
            if (count >= 1) {
                return false;
            }
            map.put(ch, count +1);
        }

        return true;
    }
}
