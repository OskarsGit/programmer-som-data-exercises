module program
open Intro2
[<EntryPoint>]
let main argv = 
    printfn "1.1 II here"

    printfn "%A" (eval (Prim("-", CstI(1), Prim("min", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(3)))) env)
    printfn "%A" (eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(2)))) env)

    printfn ""
    
    
    
    
    
    0