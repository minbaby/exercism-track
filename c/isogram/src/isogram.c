#include "isogram.h"
#include <string.h>
#include <stdio.h>
#include <ctype.h>

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) {
        return 0;
    }

    int len = strlen(phrase);

    if (len == 0) {
        return 1;
    }

    int map[26] = {0};

    for (int i = 0; i < len; i++) {
        if (++map[tolower(phrase[i]) - 'a'] > 1 && phrase[i] != ' ') {
            return 0;
        }
    }
       
    return 1;
}
