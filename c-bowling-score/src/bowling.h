#define MAX_ROLLS 21
struct game {
    int rolls[MAX_ROLLS];
    int nb_rolls;
};

void init_game(struct game *, int *, int);
int score(struct game *);
int doit();

