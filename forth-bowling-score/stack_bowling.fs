: bonus>> ( bonus -- bonus',factor )
    dup 3 and
    swap 2/ 2/ swap ;

: collect-bonus  ( frame#,frame,bonus,score,roll,roll -- frame#,frame,bonus,score,roll )
    >r rot bonus>> >r -rot
    r> r> * + ;

: update-score ( score,roll,roll -- score',roll )
    rot + swap ;

: new-frame? ( frame -- f )
    0= ;

: strike! ( frame#,frame,bonus,score - frame#,frame,bonus',score )
    swap 1+ 4 or swap ;

: spare! ( frame#,frame,bonus',score -- frame#,frame,bonus',score )
    swap drop 1 swap ;

: close-frame ( frame#,frame,bonus,score - frame#',frame',bonus,score )
    2swap drop 1+ 0 2swap ;

: open-frame ( frame#,frame,bonus,score,roll -- frame#,frame',bonus,score )
    -rot 2swap nip 1+ 2swap ;

: check-strike ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score,roll )
    dup 10 = if
        drop
        strike!
        close-frame
    else
        open-frame
    then ;

: last-roll ( frame -- roll )
    1- ;

: check-spare ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score )
    >r rot >r -rot r> last-roll r> + 10 = if spare! then
    close-frame ;
: check-bonus ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score )
    2swap over >r 2swap r> new-frame? if
        check-strike
    else
        check-spare
    then ;

: +roll ( frame#,frame,bonus,score,roll - frame#',frame',bonus',score' )
   dup collect-bonus 
   2swap over >r 2swap
   r> 0 10 within if
      dup update-score
      check-bonus
   else
       drop
   then

: start ( frame#',frame',bonus',score' )
    0 0 0 0 ;

: score ( frame#',frame',bonus',score' )
    2swap 2drop nip ;
