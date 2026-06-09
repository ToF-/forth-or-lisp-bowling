#include "unity_fixture.h"

TEST_GROUP_RUNNER(bowling) {
    RUN_TEST_CASE(bowling, no_rolls_then_score_is_zero);
    RUN_TEST_CASE(bowling, average_rolls_then_score_is_sum_of_rolls);
    RUN_TEST_CASE(bowling, spare_then_bonus_score);
    RUN_TEST_CASE(bowling, not_every_ten_is_a_spare);
    RUN_TEST_CASE(bowling, strike_then_bonus_score_twice);
    RUN_TEST_CASE(bowling, strike_advance_to_next_frame);
    RUN_TEST_CASE(bowling, after_ten_frames_roll_dont_count);
}
