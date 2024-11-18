module ass 

//11.1
let rec lenc xs con =
    match xs with 
    | [] -> con 0
    | x::xs -> lenc xs (fun y -> con (y + 1))

let rec leni xs acc =
    match xs with 
    | [] -> acc
    | x::xs -> leni xs (acc+1)

//11.2
let rec revc xs (con) = 
    match xs with
    | [] -> con []
    | x::xs -> revc xs (fun y -> con (y@[x]))

let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xs -> revi xs (x::acc)

//11.3
let rec prod xs = 
    match xs with
    | [] -> 1
    | x::xs -> x * prod xs
let rec prodc xs con =
    match xs with
    | [] -> con 1
    | x::xs -> prodc xs (fun y -> con x*y)
//11.4
let rec prodcImp xs con =
    match xs with
    | [] -> con 1
    | x::xs -> if x = 0 then 0 else (prodc xs (fun y -> con x*y))

let rec prodi xs acc = 
    match xs with
    | [] -> acc
    | 0::xs -> 0
    | x::xs -> prodi xs (x*acc)
