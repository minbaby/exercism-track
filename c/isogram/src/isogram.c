#include "isogram.h"
#include <string.h>

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) {
        return 0;
    }

    int len = strlen(phrase);

    if (len == 0) {
        return 1;
    }

    // char *last = NULL;
    // for(int i = 0; i < len; i++) {
    //     if (last != NULL && *last == phrase[i]) {
    //         continue;
    //     }

    //     strchr()
    // }

    for (int i = 0; i + 1 < len; i++)
        if (strchr(phrase + i + 1, phrase[i]))
            return 0;

    return 1;
}