module program
open Intro2
open Intcomp1
[<EntryPoint>]
let main argv = 

(*    printfn "%A" (eval (Prim("-", CstI(1), Prim("min", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(2)))) env)
*)
(*    
    printfn "%s" (fmt (Add ((CstI 2), (CstI 3))))
    printfn "%s" (fmt (Mul(CstI 2,Sub (Var "v",Add (Var "w",Var "z")))))
    
    printfn "%s" (fmt (simplify (Add (Var "x",CstI 0))))
    printfn "%s" (fmt (simplify (Add (CstI 1,CstI 0))))
    printfn "%s" (fmt (simplify (Mul (Add (CstI 0, CstI 1),Sub (CstI 0, Var "y")))))
    *)
    printfn "%A" (run (Let([("x1", CstI 3); ("x2", CstI 4)], Prim("+", Var "x1", Var "x2"))))
    printfn "%A" (freevars (Let([("x1", CstI 3); ("x2", CstI 4)], Prim("+", Var "x1", Var "x2"))))
    printfn "%A" (freevars (Let([("y", Prim("+", Var "x",CstI 3)); ("z", Prim("+",Var "y", Var "x"))], Prim("+", Var "x",CstI 3))))
    printf "test of tcomp: "
    printfn "%A" (teval (tcomp (Let([("x1", CstI 3)], Prim("+", Var "x1", Var "x2"))) ["x2"]) [2])
    printf "test with two lets and things in env: "
    printfn "%A" (teval (tcomp (Let([("x1", CstI 3); ("x2", CstI 4)], Prim ("*", Var "x3", Prim("+", Var "x1", Var "x2")))) ["x3"] ) [2])
    printf "test with more than 2 lets and none in env: "
    printfn "%A" (teval (tcomp (Let([("x1", CstI 3); ("x2", CstI 4); ("x3", CstI 4)], Prim ("*", Var "x3", Prim("+", Var "x1", Var "x2")))) [] ) [])
    
    
    
    
    
    0