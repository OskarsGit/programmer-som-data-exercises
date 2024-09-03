(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)

//1.1 I and V here
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("min", e1, e2) -> if eval e1 env < eval e2 env then eval e1 env else eval e2 env
    | Prim("max", e1, e2) -> if eval e1 env > eval e2 env then eval e1 env else eval e2 env
    | Prim("==", e1, e2) -> if eval e1 env = eval e2 env then 1 else 0
    | If (e1, e2, e3) -> if eval e1 env <> 0 then eval e2 env else eval e3 env
    | Prim _            -> failwith "unknown primitive";;

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

//1.1 II here
eval (Prim("-", CstI(1), Prim("min", CstI(2), CstI(3)))) env
eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(3)))) env
eval (Prim("*", CstI(1), Prim("==", CstI(2), CstI(2)))) env

//1.1 III here
let rec eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(ope, e1, e2) -> 
      let i1 = eval e1 env
      let i2 = eval e2 env
      match ope with 
        | "+" -> i1 + i2
        | "*" -> i1 * i2
        | "-" -> i1 - i2
        | "min" -> if i1 < i2 then i1 else i2
        | "max" -> if i1 > i2 then i1 else i2
        | "==" -> if i1 = i2 then 1 else 0
        | _ -> failwith "unknown operator"
    | Prim _            -> failwith "unknown primitive";;






//1.2 I here

type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr
    
//1.2 II here
Sub(Var "v",Add (Var "w",Var "z")) // v-(w+z)
Mul(CstI 2,Sub (Var "v",Add (Var "w",Var "z"))) // 2*(v-(w+z))
Add(Var "x",Add (Var "y",Add(Var "z",Var "v"))) // x+y+z+v

//1.2 III here
let rec fmt aexp =
    match aexp with
    | CstI n -> string n
    | Var v -> v
    | Add (n,m) -> "(" + (fmt n) + "+" + (fmt m) + ")"
    | Mul (n,m) -> "(" + (fmt n) + "*" + (fmt m) + ")"
    | Sub (n,m) -> "(" + (fmt n) + "-" + (fmt m) + ")"
    
//1.2 IV here
let rec simplify aexp =
    match aexp with
    | Add (CstI 0, n) -> simplify n
    | Add (n, CstI 0) -> simplify n
    | Sub (n, CstI 0) -> simplify n
    | Sub (n, m) when n = m -> CstI 0
    | Mul (n, CstI 1) -> simplify n
    | Mul (CstI 1, n) -> simplify n
    | Mul (_, CstI 0) -> CstI 0
    | Mul (CstI 0, _) -> CstI 0
    //| Add (n, m) -> Add(simplify n, simplify m)
    //| Sub (n, m) -> Sub(simplify n, simplify m)
    //| Mul (n, m) -> Mul(simplify n, simplify m)
    | e -> e 

//1.2 V here
let rec diff aexp v = //diff aexp according to v
    match aexp with
    | CstI _ -> CstI 0
    | Var v' when v = v'-> CstI 1
    | Var _ -> CstI 0
    | Add (n,m) -> Add (diff n v,diff m v)
    | Sub (n,m) -> Sub (diff n v,diff m v)
    | Mul (n,m) -> Add (Mul (diff n v,m),Mul (n,diff m v))
    
