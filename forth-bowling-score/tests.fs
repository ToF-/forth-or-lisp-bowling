require stack_bowling.fs
require ffl/tst.fs
page
    : +r +roll ;

    ." no rolls then score is zero" cr
    start score 0 ?S

    ." adding rolls increases score" cr
    start 3 +r 2 +r 4 +r score 9 ?S

    ." closing a frame with a spare generates bonus" cr
    start 4 +r 6 +r 3 +r score 16 ?s

    ." closing a frame with a strike generates 2 boni" cr
    start 10 +r 5 +r 1 +r score 22 ?s

    ." after ten frames, no rolls are added except bonus" cr
    start 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r 10 +r score 300 ?s

    ." some games" cr
    start 4 +r 5 +r 4 +r 6 +r 3 +r 4 +r 10 +r 8 +r 1 +r 10 +r 6 +r 3 +r 7 +r 2 +r 10 +r 10 +r 1 +r 2 +r score 128 ?s
    start 5 +r 5 +r 2 +r 8 +r 3 +r 7 +r 4 +r 6 +r 5 +r 5 +r 4 +r 6 +r 3 +r 7 +r 2 +r 8 +r 1 +r 9 +r 0 +r 10 +r 6 +r score 130 ?s
bye
