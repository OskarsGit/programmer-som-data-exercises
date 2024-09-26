module Answers

open Parse
open ParseAndRun

let e421 = fromString "let sum n = n + if (n=0) then 0 else (sum (n-1)) in sum 1000 end";;
