#include "word_count.h"
#include "stdio.h"
#include "string.h"
#include "stdbool.h"
#include "ctype.h"

#define STRING_SIZE (MAX_WORD_LENGTH + 1)

void printW(word_count_word_t *words)
{
    for (int i=0; i < MAX_WORDS; i++) {
        0 && words[i].count && printf("[%s-%d]\n", words[i].text, words[i].count);
    }
}

char *rtrim(char *str, const char *seps)
{
    int i;
    if (seps == NULL) {
        seps = "\t\n\v\f\r ";
    }
    i = strlen(str) - 1;
    while (i >= 0 && strchr(seps, str[i]) != NULL) {
        str[i] = '\0';
        i--;
    }
    return str;
}

char *ltrim(char *str, const char *seps)
{
    size_t totrim;
    if (seps == NULL) {
        seps = "\t\n\v\f\r ";
    }
    totrim = strspn(str, seps);
    if (totrim > 0) {
        size_t len = strlen(str);
        if (totrim == len) {
            str[0] = '\0';
        }
        else {
            memmove(str, str + totrim, len + 1 - totrim);
        }
    }
    return str;
}

char *xtrim(char *str, const char *seps)
{
    return ltrim(rtrim(str, seps), seps);
}

bool test(word_count_word_t *words, const char *ch)
{
    char ch_tmp[STRING_SIZE];
    int len = strlen(ch);
    memset(ch_tmp, 0, STRING_SIZE);
    memcpy(ch_tmp, ch, len);
    // xtrim(ch_tmp, ",:.\n!&@^$%");
    
    for(int i = 0; i < len; i++) {
        ch_tmp[i] = tolower(ch[i]);
    }

    int j = 0;
    int has = 0;
    for (int i=0; i < MAX_WORDS; i++) {
        if (strlen(words[i].text) == 0) {
            break;
        }

        if (strcmp(words[i].text, ch_tmp) == 0) {
            words[i].count++;
            has = 1;
            break;
        }

        j++; 
    }

    if  (!has) {
        memcpy(words[j].text, ch_tmp, len);
        words[j].count = 1;
        return false;
    }

    return true;
}


int word_count(const char *input_text, word_count_word_t * words)
{
    char *sep = " ,:.\n!&@^$%";
    char tmp[STRING_SIZE * MAX_WORDS];
    
    memset(tmp, 0, STRING_SIZE * MAX_WORDS);
    memcpy(tmp, input_text, STRING_SIZE * MAX_WORDS);
    
    memset(words, 0, sizeof(word_count_word_t) * MAX_WORDS);

    int ret = 0;
    char *x = strtok(tmp, sep);
    while(x) {
        if (strlen(x) > MAX_WORD_LENGTH) {
            ret = EXCESSIVE_LENGTH_WORD;
            break;
        }

        if (ret >= MAX_WORDS) {
            ret = EXCESSIVE_NUMBER_OF_WORDS;
            break;
        }

        if (!test(words, x)) {
            ret++;
        }

        x = strtok(NULL, sep);
    }
    printW(words);

    return ret;
}
