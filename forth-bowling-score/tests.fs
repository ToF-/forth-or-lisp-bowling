require bowling.fs
require ffl/tst.fs
page
    ." no rolls then score is zero" cr
    start score @ 0 ?S

    ." adding rolls increases score" cr
    start 3 +roll 2 +roll 4 +roll score @ 9 ?S

    ." closing a frame with a spare generates bonus" cr
    start 4 +roll 6 +roll 3 +roll score @ 16 ?s

    ." closing a frame with a strike generates 2 boni" cr
    start 10 +roll 5 +roll 1 +roll score @ 22 ?s

    ." after ten frames, no rolls are added except bonus" cr
    start 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll 10 +roll score @ 300 ?s
bye
