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
