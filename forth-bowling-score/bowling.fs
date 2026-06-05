\ bowling.fs

variable score
variable rolls

: init-game
    0 score !
    0 rolls ! ;

: add-roll ( n -- )
    score @ 10 =
    rolls @ 2 mod 0 = and if 
        dup score +!
    endif
    score +!
    1 rolls +! ;

: compute-score ( -- n )
    score @ ;

