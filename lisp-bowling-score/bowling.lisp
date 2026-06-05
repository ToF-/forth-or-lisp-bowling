; bowling.lisp

(defun score (rolls)
  (cond ((null rolls) 0)
    (t (+ (first rolls) (score (rest rolls))))))

