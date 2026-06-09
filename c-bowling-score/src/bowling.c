#include <stdio.h>
#include "bowling.h"

void init_game(struct game *game, int *rolls, int nb_rolls) {
    for(int i = 0; i < nb_rolls; i++) {
        game->rolls[i] = rolls[i];
    };
    for(int i = nb_rolls; i < MAX_ROLLS; i++) {
        game->rolls[i] = 0;
    }
    game->nb_rolls = nb_rolls;
}

int score(struct game *game) {
    int result = 0;
    int h = 0;
    for(int i = 0; i < game->nb_rolls; i++) {
        if(h == 20) {
            break;
        }
        if(h % 2 == 0 && game->rolls[i] == 10) {
            result += game->rolls[i+1];
            result += game->rolls[i+2];
            h += 1;
        }
        else if(h % 2 == 0 && game->rolls[i] + game->rolls[i+1] == 10) {
            result += game->rolls[i+2];
        }
        result += game->rolls[i];
        h += 1;
    }
    return result;
}

int doit() {
    return 42;
}
