#include "word_count.h"
#include "stdio.h"
#include "string.h"
#include "stdbool.h"
#include "ctype.h"
#include "stdlib.h"

#define __DEBUG false

void printW(word_count_word_t *words)
{
    if (!__DEBUG) {
        return;
    }

    for (int i=0; i < MAX_WORDS; i++) {
        words[i].count && printf("[%s-%d]\n", words[i].text, words[i].count);
    }
}

char* fix_char(char *ch, int len) 
{
    if (ch[0] == '\'' && ch[len-1] == '\'') {
        char *ret = malloc(len-2);
        memcpy(ret, ch+1, len - 2);
        return ret;     
    }

    return ch;
}

char* str_tolower(char *ch, int len) 
{
    for(int i = 0; i < len; i++) {
        ch[i] = tolower(ch[i]);
    }
    return ch;
}

bool handler(word_count_word_t *words, char *ch)
{
    int len = strlen(ch);

    ch = str_tolower(fix_char(ch, len), len);

    int j = 0;
    int has = 0;
    for (int i=0; i < MAX_WORDS; i++) {
        if (strlen(words[i].text) == 0) {
            break;
        }

        if (strcmp(words[i].text, ch) == 0) {
            words[i].count++;
            has = 1;
            break;
        }

        j++; 
    }

    if  (!has) {
        memcpy(words[j].text, ch, len);
        words[j].count = 1;
        return false;
    }

    return true;
}


int word_count(const char *input_text, word_count_word_t * words)
{
    char *sep = " ,:.\n!&@^$%";

    int len = strlen(input_text) + 1;
    char *tmp = malloc(len);
    
    memset(tmp, 0, len);
    memcpy(tmp, input_text, len);
    
    memset(words, 0, sizeof(word_count_word_t) * MAX_WORDS);

    int ret = 0;
    char *ch = strtok(tmp, sep);
    while(ch) {
        if (strlen(ch) > MAX_WORD_LENGTH) {
            ret = EXCESSIVE_LENGTH_WORD;
            break;
        }

        if (ret >= MAX_WORDS) {
            ret = EXCESSIVE_NUMBER_OF_WORDS;
            break;
        }

        if (!handler(words, ch)) {
            ret++;
        }

        ch = strtok(NULL, sep);
    }
    printW(words);

    return ret;
}
