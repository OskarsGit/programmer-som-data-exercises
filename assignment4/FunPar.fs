// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | OR
  | AND
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_OR
    | TOKEN_AND
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_Names
    | NONTERM_AtExpr
    | NONTERM_CallExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | OR  -> 9 
  | AND  -> 10 
  | PLUS  -> 11 
  | MINUS  -> 12 
  | TIMES  -> 13 
  | DIV  -> 14 
  | MOD  -> 15 
  | ELSE  -> 16 
  | END  -> 17 
  | FALSE  -> 18 
  | IF  -> 19 
  | IN  -> 20 
  | LET  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | CSTBOOL _ -> 25 
  | NAME _ -> 26 
  | CSTINT _ -> 27 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_OR 
  | 10 -> TOKEN_AND 
  | 11 -> TOKEN_PLUS 
  | 12 -> TOKEN_MINUS 
  | 13 -> TOKEN_TIMES 
  | 14 -> TOKEN_DIV 
  | 15 -> TOKEN_MOD 
  | 16 -> TOKEN_ELSE 
  | 17 -> TOKEN_END 
  | 18 -> TOKEN_FALSE 
  | 19 -> TOKEN_IF 
  | 20 -> TOKEN_IN 
  | 21 -> TOKEN_LET 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_CSTBOOL 
  | 26 -> TOKEN_NAME 
  | 27 -> TOKEN_CSTINT 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_Names 
    | 20 -> NONTERM_Names 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AtExpr 
    | 26 -> NONTERM_CallExpr 
    | 27 -> NONTERM_CallExpr 
    | 28 -> NONTERM_AppExpr 
    | 29 -> NONTERM_Const 
    | 30 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | OR  -> "OR" 
  | AND  -> "AND" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;23us;65535us;0us;2us;6us;7us;8us;9us;10us;11us;12us;13us;32us;14us;33us;15us;34us;16us;35us;17us;36us;18us;37us;19us;38us;20us;39us;21us;40us;22us;41us;23us;42us;24us;43us;25us;44us;26us;51us;27us;52us;28us;55us;29us;56us;30us;58us;31us;2us;65535us;45us;46us;50us;54us;25us;65535us;0us;4us;4us;60us;6us;4us;8us;4us;10us;4us;12us;4us;32us;4us;33us;4us;34us;4us;35us;4us;36us;4us;37us;4us;38us;4us;39us;4us;40us;4us;41us;4us;42us;4us;43us;4us;44us;4us;51us;4us;52us;4us;55us;4us;56us;4us;58us;4us;60us;60us;2us;65535us;4us;62us;60us;61us;23us;65535us;0us;5us;6us;5us;8us;5us;10us;5us;12us;5us;32us;5us;33us;5us;34us;5us;35us;5us;36us;5us;37us;5us;38us;5us;39us;5us;40us;5us;41us;5us;42us;5us;43us;5us;44us;5us;51us;5us;52us;5us;55us;5us;56us;5us;58us;5us;25us;65535us;0us;47us;4us;47us;6us;47us;8us;47us;10us;47us;12us;47us;32us;47us;33us;47us;34us;47us;35us;47us;36us;47us;37us;47us;38us;47us;39us;47us;40us;47us;41us;47us;42us;47us;43us;47us;44us;47us;51us;47us;52us;47us;55us;47us;56us;47us;58us;47us;60us;47us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;27us;30us;56us;59us;83us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;14us;1us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;1us;2us;2us;28us;1us;3us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;5us;14us;5us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;23us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;23us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;24us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;24us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;25us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;2us;19us;20us;1us;20us;1us;21us;1us;22us;2us;23us;24us;2us;23us;24us;1us;23us;1us;23us;1us;23us;1us;24us;1us;24us;1us;24us;1us;24us;1us;25us;1us;25us;2us;26us;27us;1us;27us;1us;28us;1us;29us;1us;30us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;19us;21us;24us;26us;28us;43us;45us;60us;62us;77us;79us;94us;109us;124us;139us;154us;169us;184us;199us;214us;229us;244us;259us;274us;289us;304us;319us;334us;349us;364us;366us;368us;370us;372us;374us;376us;378us;380us;382us;384us;386us;388us;390us;393us;395us;397us;399us;402us;405us;407us;409us;411us;413us;415us;417us;419us;421us;423us;426us;428us;430us;432us;|]
let _fsyacc_action_rows = 65
let _fsyacc_actionTableElements = [|7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;0us;49152us;14us;32768us;0us;3us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;0us;16385us;5us;16386us;1us;58us;21us;49us;25us;64us;26us;48us;27us;63us;0us;16387us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;23us;8us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;16us;10us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;13us;16388us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;3us;16389us;13us;34us;14us;35us;15us;36us;3us;16390us;13us;34us;14us;35us;15us;36us;3us;16391us;13us;34us;14us;35us;15us;36us;0us;16392us;0us;16393us;0us;16394us;9us;16395us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;9us;16396us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;9us;16397us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;9us;16398us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;9us;16399us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;9us;16400us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;11us;16401us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;11us;16402us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;20us;52us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;17us;53us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;20us;56us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;17us;57us;14us;32768us;2us;59us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;1us;16403us;26us;45us;0us;16404us;0us;16405us;0us;16406us;1us;32768us;26us;50us;2us;32768us;3us;51us;26us;45us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;0us;16407us;1us;32768us;3us;55us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;0us;16408us;7us;32768us;1us;58us;12us;12us;19us;6us;21us;49us;25us;64us;26us;48us;27us;63us;0us;16409us;5us;16410us;1us;58us;21us;49us;25us;64us;26us;48us;27us;63us;0us;16411us;0us;16412us;0us;16413us;0us;16414us;|]
let _fsyacc_actionTableRowOffsets = [|0us;8us;9us;24us;25us;31us;32us;40us;55us;63us;78us;86us;100us;108us;112us;116us;120us;121us;122us;123us;133us;143us;153us;163us;173us;183us;195us;207us;222us;237us;252us;267us;282us;290us;298us;306us;314us;322us;330us;338us;346us;354us;362us;370us;378us;386us;388us;389us;390us;391us;393us;396us;404us;412us;413us;415us;423us;431us;432us;440us;441us;447us;448us;449us;450us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;1us;2us;1us;1us;7us;8us;3us;1us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;3us;3us;4us;4us;4us;4us;4us;5us;5us;6us;7us;7us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;16387us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16404us;16405us;16406us;65535us;65535us;65535us;65535us;16407us;65535us;65535us;65535us;16408us;65535us;16409us;65535us;16411us;16412us;16413us;16414us;|]
let _fsyacc_reductions = lazy [|
# 269 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 278 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1 
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 289 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               _1                     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 300 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               _1                     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 311 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 324 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 335 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 347 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 359 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 371 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 383 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 395 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 407 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 419 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 431 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 443 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 55 "FunPar.fsy"
                 : Absyn.expr));
# 455 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 467 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               If (_1, CstB(true), _3)
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 479 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                              If (_1, _3, CstB(false))
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 491 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               [_1]                   
                   )
# 62 "FunPar.fsy"
                 : string list));
# 502 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _2 = parseState.GetInput(2) :?> string list in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "FunPar.fsy"
                                                               _1 :: _2               
                   )
# 63 "FunPar.fsy"
                 : string list));
# 514 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               _1                     
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 525 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "FunPar.fsy"
                                                               Var _1                 
                   )
# 68 "FunPar.fsy"
                 : Absyn.expr));
# 536 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 69 "FunPar.fsy"
                 : Absyn.expr));
# 549 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string list in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
# 563 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               _2                     
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 574 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "FunPar.fsy"
                                                               [_1]                   
                   )
# 75 "FunPar.fsy"
                 : Absyn.expr list));
# 585 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr list in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "FunPar.fsy"
                                                               _1 :: _2               
                   )
# 76 "FunPar.fsy"
                 : Absyn.expr list));
# 597 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr list in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 80 "FunPar.fsy"
                 : Absyn.expr));
# 609 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 84 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 84 "FunPar.fsy"
                 : Absyn.expr));
# 620 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 85 "FunPar.fsy"
                 : Absyn.expr));
|]
# 632 "FunPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _
