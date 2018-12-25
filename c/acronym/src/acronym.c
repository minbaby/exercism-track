#include "acronym.h"
#include "stdio.h"
#include "strings.h"
#include "stdlib.h"
#include "ctype.h"

char *abbreviate(const char *phrase)
{
    if (phrase == NULL || phrase[0] == '\0') {
        return NULL;
    }

    int count = 0;
    int index = 0;
    while(phrase[index] != '\0') {
        if (phrase[index-1] == ' ' || phrase[index-1] == '-') {
            count++;
        }
        index++;
    }

    int l = sizeof(char) * (count + 2);
    char *xyz = malloc(l);
    memset(xyz, 0, l);

    int charIndex = 1;
    index = 1;
    xyz[0] = toupper(phrase[0]);
    while(phrase[index] != '\0') {
        if (phrase[index-1] == ' ' || phrase[index-1] == '-') {
            xyz[charIndex] = toupper(phrase[index]);
            charIndex++;
        }
        index++;
    };

    return xyz;
}

