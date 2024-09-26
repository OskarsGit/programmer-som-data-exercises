module Answers

open Parse
open ParseAndRun

let e421 = fromString "let sum n = n + if (n=0) then 0 else (sum (n-1)) in sum 1000 end";;

let e422 = fromString "let treer n = (if n = 0 then 1 else  3 * (treer (n - 1))) in treer 8 end";;

let e423 = fromString "let treer n = (if n = 0 then 1 else  3 * (treer (n - 1))) in 
        let treesum n = treer n + if (n=0) then 0 else (treesum (n-1)) in 
        treesum 11 end end";;

let e424 = fromString "let pow8 n = n*n*n*n*n*n*n*n in 
        let powsum n = pow8 n + if (n=0) then 0 else (powsum (n-1)) in 
        powsum 10 end end";;

let e44 = fromString "let pow n m = (if n = 0 then 1 else m * (pow (n - 1))) in pow 4 2 end"

let e45 = fromString "if 2 = 2 && 3 = 3 then 1 else 2"