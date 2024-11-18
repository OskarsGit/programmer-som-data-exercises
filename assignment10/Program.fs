module main

open ass
open System.Diagnostics


let timeAlgorithm algorithm =
    let stopwatch = Stopwatch.StartNew() // Start the stopwatch
    let result = algorithm()             // Execute the algorithm
    stopwatch.Stop()                     // Stop the stopwatch
    (result, stopwatch.Elapsed)          // Return the result and elapsed time

let main = 
    printf "11.1 awnsers\n"
    let xs = [1..10000]
    printf "List for testing in 11.1 [1..10000]\n"
    let (a,b) = (timeAlgorithm (fun x-> (lenc xs id)))
    printf "Result of 11.1.i  : %d, and took: %As\n" a b 
    printf "Result of 11.1.ii : %A\n" (lenc xs (fun x -> x*2))
    let (a,b) = (timeAlgorithm ((fun x -> leni xs 0)))
    printf "Result of 11.1.iii: %d, and took: %As\n" a b 
    printf "While lenc and leni can accive the same result lenc can do more specific tasks, as seen by the calling it with 'fun x -> x*2'\nlenc keeps its continuation functions in the heap while leni executes the result right away\nleni will execute faster in most cases due to making fewer computations"
    printf "\n\n"
    
    printf "11.2 awnsers\n"
    let xs = [1..10]
    printf "List for testing in 11.2 [1..10]\n"
    printf "Result of 11.2.i  : %A\n" (revc xs id)
    printf "Result of 11.2.ii : %A\n" (revc xs (fun x -> x@x))
    printf "Result of 11.2.iii: %A\n" (revi xs [])
    printf "\n\n"

    printf "11.3 awnsers\n"
    let xs = [1..10]
    printf "List for testing in 11.3 [1..10]\n"
    printf "Result of 11.3    : %A\n" (prodc xs id)
    printf "\n\n"

    printf "11.4 awnsers\n"
    let xs = [-100..100]
    printf "List for testing in 11.4 [-100..100]\n"
    let (a,b) = (timeAlgorithm ((fun x -> prod xs)))
    printf "Result of prod                          : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodc xs id)))
    printf "Result of prodc                         : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodcImp xs id)))
    printf "Result of prodcImp                      : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodcImp xs (fun x -> x*2))))
    printf "Result of prodcImp with 'fun x -> x*2   : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodi xs 1)))
    printf "Result of prodi                         : %d, and took %As\n" a b

    let xs = [-100..10000]
    printf "List for testing in 11.4 [-100..10000]\n"
    let (a,b) = (timeAlgorithm ((fun x -> prod xs)))
    printf "Result of prod                          : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodc xs id)))
    printf "Result of prodc                         : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodcImp xs id)))
    printf "Result of prodcImp                      : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodcImp xs (fun x -> x*2))))
    printf "Result of prodcImp with 'fun x -> x*2   : %d, and took %As\n" a b
    let (a,b) = (timeAlgorithm ((fun x -> prodi xs 1)))
    printf "Result of prodi                         : %d, and took %As\n" a b
    printf "\n\n"

    printf "11.8 awnsers\n"

    0