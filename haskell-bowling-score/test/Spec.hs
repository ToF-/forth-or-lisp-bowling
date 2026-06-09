import Test.Hspec
import Bowling

main :: IO ()
main = hspec $ do
    describe "bowling score" $ do
        it "yields 0 when given no rolls" $ do
            score [] `shouldBe` 0
        it "yields the sum of rolls when given average rolls" $ do
            score [4,5,3,2] `shouldBe` 14
        it "adds a bonus when given a spare" $ do
            score [6,4,2] `shouldBe` 14
        it "adds two boni when given a strike" $ do
            score [10,4,4] `shouldBe` 26
        it "counts points and boni until frame ten" $ do
            score [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10] `shouldBe` 300
            score [5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5] `shouldBe` 150
        it "should pass on some games" $ do
            score [5, 5, 2, 8, 3, 7, 4, 6, 5, 5, 4, 6, 3, 7, 2, 8, 1, 9, 0, 10, 6] `shouldBe` 130
            score [4, 5, 4, 6, 3, 4, 10, 8, 1, 10, 6, 3, 7, 2, 10, 10, 1, 2] `shouldBe` 128
