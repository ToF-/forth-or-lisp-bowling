(ql:quickload :lisp-unit)
(in-package :lisp-unit)
(setq *print-failures* t)
(load "bowling")

(define-test no-rolls-then-score-is-zero
    (assert-equal 0 (score ())))

(define-test one-average-roll-then-score-is-roll
             (assert-equal 4 (score (list 4))))

(define-test two-average-rolls-then-score-is-sum-of-rolls
             (assert-equal 5 (score (list 3 2))))


(define-test spare-counts-new-roll-as-a-bonus
             (assert-equal 12 (score (list 6 4 1))))



(run-tests :all)
(sb-ext:quit)
