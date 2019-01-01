import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class ProteinTranslator {

    List<String> translate(String rnaSequence) {
        Map<String, String> map = new HashMap<>();
        map.put("AUG", "Methionine");
        map.put("UUU", "Phenylalanine");
        map.put("UUC", "Phenylalanine");
        map.put("UUG", "Leucine");
        map.put("UUA", "Leucine");
        map.put("UCU", "Serine");
        map.put("UCC", "Serine");
        map.put("UCA", "Serine");
        map.put("UCG", "Serine");
        map.put("UAU", "Tyrosine");
        map.put("UAC", "Tyrosine");
        map.put("UGU", "Cysteine");
        map.put("UGC", "Cysteine");
        map.put("UGG", "Tryptophan");

        Map<String, Boolean> stop = new HashMap<>();
        stop.put("UAA", true);
        stop.put("UAG", true);
        stop.put("UGA", true);

        List<String> ret = new ArrayList<>();
        int len = rnaSequence.length();
        for (int i = 0; i < len; i += 3) {
            String str = rnaSequence.substring(i, i+3);
            if (stop.containsKey(str)) {
                break;
            }

            if (map.containsKey(str)) {
                ret.add(map.get(str));
            }
        }

        return ret;
    }
}