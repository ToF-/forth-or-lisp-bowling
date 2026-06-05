require bowling.fs
require ffl/tst.fs
page
T{
    ." no rolls then score is zero" cr

    init-game
    compute-score 
    0 ?S
}T

T{
    ." one average roll then score is roll" cr

    init-game
    4 add-roll
    compute-score 
    4 ?S
}T

T{
    ." two average rolls then score is sum of rolls" cr

    init-game
    3 add-roll
    2 add-roll
    compute-score 
    5 ?S
}T

T{
    ." 10 in 2 rolls then 3rd roll added twice" cr

    init-game
    6 add-roll
    4 add-roll
    1 add-roll
    compute-score 
    12 ?S
}T
T{
    ." not every 10 is score is a spare" cr

    init-game
    8 add-roll
    1 add-roll
    1 add-roll
    4 add-roll
    compute-score 
    14 ?S
}T

bye
