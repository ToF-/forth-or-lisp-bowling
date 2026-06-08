module Bowling
    where

type Roll = Int
data Frame = NoFrame
           | Open Roll
           | Frame Roll Roll
           | Spare Roll
           | Strike

    deriving (Eq, Show)

qualify :: [Int] -> (Frame, [Int])
qualify [] = (NoFrame, [])
qualify (x:rest) | x == 10 = (Strike, rest)
qualify (x:y:rest) | x + y == 10 = (Spare x, rest)
qualify (x:y:rest) = (Frame x y, rest)
qualify (x:rest) = (Open x, rest)

score :: [Int] -> Int
score rolls = let (q,rest) = qualify rolls in
                case q of
                  Strike -> 0
                  Spare x -> 10 + (head rest) + score rest
                  Frame x y -> x + y + score rest
                  Open x -> x + score rest
                  NoFrame -> 0



