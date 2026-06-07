\ bowling.fs

variable score

variable bonus
\  0 | no bonus    (0)
\  1 | spare bonus (1)
\  5 | strike boni (1,1)
\  6 | accumulated strikes (2,1)

variable frame
\ 0 : new-frame 1…10 : last roll value + 1

variable frame#

: start
    score off bonus off frame off frame# off ;

\ get bonus factor and shift bonus
: bonus>> ( -- 0|1|2 )
    bonus @ dup 3 and
    swap 2/ 2/ bonus ! ;

\ multiplies roll by bonus factor and shift bonus
: collect-bonus ( n -- )
    bonus>> * score +! ;

\ does the current frame already has a first roll?
: open-frame? ( -- f )
    frame @ ;

\ is the current frame a new frame?
: new-frame? ( -- f )
    open-frame? 0= ;

\ value of the frame's first roll
: last-roll ( -- n )
    frame @ 1- ;

\ start a new frame, storing the roll
: open-frame ( n -- )
    1+ frame ! ;

\ increment the frame number to a max of 10
: frame#++
    frame# @ 1+ 10 min frame# ! ;

\ start a new frame and increment the frame count
: close-frame
    0 frame ! frame#++ ;

\ store bonus for a spare
: spare!
    1 bonus ! ;

\ store boni for a strike
: strike!
    bonus @ 1+ 4 or bonus ! ;

\ register a bonus if roll completes a spare
: check-spare ( n -- )
    last-roll + 10 = if spare! then
    close-frame ;

\ register boni if roll is a strike
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
