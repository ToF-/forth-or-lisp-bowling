module Bowling
    where

type Bonus = Int
type Roll = Int
data Frame = NoFrame
           | Open Roll
           | Frame Roll Roll
           | Spare Roll Bonus
           | Strike Bonus Bonus
    deriving (Eq, Show)

points :: Frame -> Int
points NoFrame = 0
points (Open r) = r
points (Frame x y) = x + y
points (Spare r b) = 10 + b
points (Strike a b) = 10 + a + b

qualify :: [Int] -> (Frame, [Int])
qualify [] = (NoFrame, [])
qualify [x,y] | x == 10 = (Strike y 0, [])
qualify (x:y:z:rest) | x == 10 = (Strike y z, y:z:rest)
qualify [x,y] | x + y == 10 = (Spare y 0, [])
qualify (x:y:z:rest) | x + y == 10 = (Spare y z, z:rest)
qualify (x:y:rest) = (Frame x y, rest)
qualify (x:rest) = (Open x, rest)

qualify_at :: [Int] -> Int -> [Frame]
qualify_at _ 10 = []
qualify_at [] _ = []
qualify_at rolls f = let (frame, rest) = qualify rolls in
                         frame : (qualify_at rest (succ f))
score :: [Int] -> Int
score rolls = foldl (\acc q -> acc + points q) 0 (qualify_at rolls 0)



