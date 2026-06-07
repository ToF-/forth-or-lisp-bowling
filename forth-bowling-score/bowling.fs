\ bowling.fs

variable score
variable bonus
variable frame
variable frame#

: start
    0 frame# !
    0 frame !
    0 bonus !
    0 score ! ;

: bonus>> ( -- 0|1|2 )
    bonus @ dup 3 and
    swap 2/ 2/ bonus ! ;

: collect-bonus ( n -- )
    bonus>> * score +! ;

: open-frame? ( -- f )
    frame @ ;

: new-frame? ( -- f )
    open-frame? 0= ;

: last-roll ( -- n )
    frame @ 1- ;

: open-frame ( n -- )
    1+ frame ! ;

: frame#++
    frame# @ 1+ 10 min frame# ! ;

: close-frame
    0 frame !
    frame#++ ;

: spare!
    1 bonus ! ;

: strike!
    bonus @ 1+ 4 or bonus ! ;

: check-spare ( n -- )
    last-roll + 10 = if spare! then
    close-frame ;

: check-strike ( n -- )
    dup 10 = if
        drop
        strike!
        close-frame
    else
        open-frame
    then ;

: check-bonus ( n -- )
    new-frame? if
        check-strike
    else
        check-spare
    then ;

: +roll ( n -- )
    dup collect-bonus
    frame# @ 0 10 within if
        dup score +!
        check-bonus
    else
        drop
    then ;
