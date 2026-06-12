:- module(bowling, [score/2]).

score(Rolls, Score) :-
    score_at_frame(0, Rolls, Score).

score_at_frame(_, [],0).

score_at_frame(10, _, 0).

score_at_frame(Frame, [A,B,C|Rest], Score) :-
    10 is A + B,
    A \= 10,
    NextFrame is Frame + 1,
    score_at_frame(NextFrame, [C|Rest], ScoreRest),
    Score is 10 + C + ScoreRest.

score_at_frame(Frame, [A,B,C|Rest], Score) :-
    10 is A,
    NextFrame is Frame + 1,
    score_at_frame(NextFrame, [B,C|Rest], ScoreRest),
    Score is 10 + B + C + ScoreRest.

score_at_frame(Frame, [A,B|Rest], Score) :-
    A \= 10,
    NextFrame is Frame + 1,
    score_at_frame(NextFrame, Rest, ScoreRest),
    Score is A + B + ScoreRest.

score_at_frame(_, [A], Score) :-
    Score is A.
