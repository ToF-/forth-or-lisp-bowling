% to run the tests:
% swipl -g run_tests -t halt bowling_test.pl

:- begin_tests(bowling_score).


:- use_module('bowling'). 

test('given no rolls then score is zero',[nondet]) :-
    score([], 0).

test('given average rolls, score is sum of rolls',[nondet]) :-
    score([3,4,5,2], 14).

test('given a spare, bonus is added to score',[nondet]) :-
    score([4,6,3], 16).

test('given a strike, bonus is added twice to score',[nondet]) :-
    score([10,4,3], 24).

test('after ten frames, rolls are not added to score', [nondet]) :-
    score([10,10,10,10,10,10,10,10,10,10,10,10], 300).

test('some games', [nondet]) :-
    score([5,5,2,8,3,7,4,6,5,5,4,6,3,7,2,8,1,9,0,10,6],130).
:- end_tests(bowling_score).


