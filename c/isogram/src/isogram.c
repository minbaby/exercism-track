#include "isogram.h"
#include <string.h>
#include <ctype.h>
#include <stdio.h>

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) {
        return 0;
    }

    int map[26] = {0};
    int index = 0;
    int charIndex = 0;
    while(phrase[index] != '\0') {
        charIndex = tolower(phrase[index]) - 'a';
        map[charIndex]++;
        if (map[charIndex] > 1 && phrase[index] != ' ') {
            return 0;
        }
        index++;
    }
       
    return 1;
}
