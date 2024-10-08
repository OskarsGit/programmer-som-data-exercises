module answers

let rec merge xs ys =  
    match xs, ys with 
    | [], [] -> []
    | xs, [] -> xs
    | [], ys -> ys
    | x::xs, y::ys -> if x>y then y:: (merge (x::xs) ys) else x:: (merge xs (y::ys))