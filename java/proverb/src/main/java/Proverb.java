class Proverb {
    String[] list;

    Proverb(String[] words) {
        list = words;
    }

    public String recite() {
        if (list.length == 0) {
            return "";
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.length; i++) {
            if (i <= 0 || i + 1 > list.length) {
                continue;
            }
                
            sb.append(String.format("For want of a %s the %s was lost.\n", list[i-1], list[i]));
        }
        sb.append(String.format("And all for the want of a %s.", list[0]));

        return sb.toString();
    }

}
