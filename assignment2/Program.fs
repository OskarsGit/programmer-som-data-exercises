// For more information see https://aka.ms/fsharp-console-apps
open Intcomp1

printfn "%A" (assemble (scomp e1 [])) 
intsToFile (assemble (scomp e1 [])) "is1.txt"