class ReverseString {
    String reverse(String inputString) {
        int len = inputString.length();
        char charArray[] = inputString.toCharArray();
        char tmp;
        int half = len/2;
        for (int i = 0; i < half; i++) {
            tmp = charArray[i];
            charArray[i] = charArray[len-i-1];
            charArray[len-i-1] = tmp;
        }
        return String.valueOf(charArray);
    }
  
}