#include "word_count.h"
#include "stdio.h"
#include "string.h"

void test(word_count_word_t *words, const char *ch)
{
    int j = 0;
    int has = 0;
    for (int i=0; i < MAX_WORDS; i++) {
        if (words[i].text == ch) {
            words[i].count++;
            has = 1;
            break;
        } 
        if (words[i].text[0] != '\0') {
            j++;
        }
    }

    if  (!has) {
        // j++;
        memcpy(words[j].text, ch, strlen(ch));
        words[j].count++;
    }
}

void printW(word_count_word_t *words)
{
    for (int i=0; i < MAX_WORDS; i++) {
        printf("[%s-%d]\n", words[i].text, words[i].count);
    }
}

int word_count(const char *input_text, word_count_word_t * words)
{
    char tmp[MAX_WORD_LENGTH];
    memset(tmp, 0, MAX_WORD_LENGTH);
    memcpy(tmp, input_text, MAX_WORD_LENGTH);
    
    printW(words);
    // printf("ddd %d \n\n", words->count);

    int ret = 0;
    char *x = strtok(tmp, " ");
    while(x) {
        // printf("===> %s <===\n", x);
        test(words, x);
        ret++;
        x = strtok(NULL, " ");
    }

    return ret;
}