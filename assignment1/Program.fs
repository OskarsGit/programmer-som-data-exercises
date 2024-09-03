module program
open Intro2
[<EntryPoint>]
let main argv = 
    printfn "1.1 II here"

(*    printfn "%A" (eval (Prim("-", CstI(1), Prim("min", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(2)))) env)
*)
    printfn "%s" (fmt (Add ((CstI 2), (CstI 3))))
    printfn "%s" (fmt (Mul(CstI 2,Sub (Var "v",Add (Var "w",Var "z")))))
    
    
    printfn "%s" (fmt (simplify (Add (Var "x",CstI 0))))
    printfn "%s" (fmt (simplify (Add (CstI 1,CstI 0))))
    printfn "%s" (fmt (simplify (Mul (Add (CstI 0, CstI 1),Sub (CstI 0, Var "y")))))
    
    
    
    0