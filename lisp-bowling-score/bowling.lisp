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
  (cond ((null rolls) 0)
        ((and (< frame 10) (spare rolls))
         (let ((remaining (rest (rest rolls))))
           (+ 10 (first remaining) (score-at-frame (1+ frame) remaining))))
        ((and (< frame 9) (strike rolls))
         (let ((remaining (rest rolls)))
           (+ 10 (first remaining) (first (rest remaining)) (score-at-frame (1+ frame) remaining))))
        ((> (length rolls) 2)
         (let ((remaining (rest (rest rolls))))
           (+ (first rolls) (first (rest rolls)) (score-at-frame (1+ frame) remaining))))
        ((= (length rolls) 2)
         (+ (first rolls) (first (rest rolls))))
        (t (+ (first rolls) (score-at-frame frame (rest rolls))))))

(defun score (rolls)
  (score-at-frame 0 rolls))


