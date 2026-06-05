(load "bowling")
; usage : sbcl --noinform --load main.lisp <FILE.TXT>
(process (car (cdr *posix-argv*)))
(sb-ext:quit)
