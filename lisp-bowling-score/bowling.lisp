; bowling.lisp

(defun spare (rolls)
  (if (> (length rolls) 2)
    (= 10 (+ (first rolls) (first (rest rolls))))
    nil))

(defun strike (rolls)
  (if (>= (length rolls) 2)
    (= 10  (first rolls))
    nil))

(defun score-at-frame (frame rolls)
  (cond ((>= frame 10) 0)
        ((spare rolls)
         (let ((remaining (rest (rest rolls))))
           (+ 10
              (first remaining)
              (score-at-frame (1+ frame) remaining))))
        ((strike rolls)
         (let ((remaining (rest rolls)))
           (+ 10
              (first remaining)
              (first (rest remaining))
              (score-at-frame (1+ frame) remaining))))
        ((> (length rolls) 2)
         (let ((remaining (rest (rest rolls))))
           (+ (first rolls)
              (first (rest rolls))
              (score-at-frame (1+ frame) remaining))))
        (t (apply #'+ rolls))))

(defun score (rolls)
  (score-at-frame 0 rolls))


