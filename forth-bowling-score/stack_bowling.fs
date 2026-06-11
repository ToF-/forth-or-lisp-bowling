: bonus>> ( bonus -- bonus',factor )
    dup 3 and
    swap 2/ 2/ swap ;

: update-score ( score,roll -- score',roll )
    + ;

: new-frame? ( frame -- f )
    0= ;

: strike! ( frame#,frame,bonus,score - frame#,frame,bonus',score )
    swap 1+ 4 or swap ;

: spare! ( frame#,frame,bonus',score -- frame#,frame,bonus',score )
    swap drop 1 swap ;

: close-frame ( frame#,frame,bonus,score - frame#',frame',bonus,score )
    2swap drop 1+ 0 2swap ;

: open-frame ( frame#,frame,bonus,score,roll -- frame#,frame',bonus,score )
    >r 2swap drop r> 1+    \ bonus,score,frame#,frame'
    2swap ; 

: check-strike ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score,roll )
    dup 10 = if
        drop strike!
        close-frame
    else
        open-frame
    then ;

: frame ( frame#,frame,bonus,score,roll -- …,frame )
    2swap over >r 2swap r> ;

: last-roll ( frame -- roll )
    1- ;

: check-spare ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score )
    frame last-roll 
    + 10 = if spare! then
    close-frame ;

: check-bonus ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score )
    frame new-frame? if
        check-strike
    else
        check-spare
    then ;

: in-game? ( frame# -- f )
    0 10 within ;

: .state
    2over swap
    ." frame#:" . ." frame:" .
    2dup swap
    ." bonus:" . ." score:" . 
    cr ;

: collect-bonus  ( frame#,frame,bonus,score,roll -- frame#,frame,bonus,score,roll )
    >r swap bonus>>        \ frame#,frame,score,bonus',factor
    r@ * rot + r> ;        \ frame#,frame,bonus',score',roll ;

: +roll ( frame#,frame,bonus,score,roll - frame#',frame',bonus',score' )
   collect-bonus
   2swap over >r 2swap r>
   in-game? if
      dup check-bonus
      update-score
   else
       drop
   then .state ;

: start ( -- frame#,frame,bonus,score )
    0 0 0 0 ;

: score ( frame#',frame',bonus',score' )
    2swap 2drop nip ;
