grammar Grammar;

options {
	language = CSharp;
}

COMMENT : '/*' .*? '*/' -> channel(HIDDEN) ;
LINE_COMMENT_1 : ';' ~[\r\n]* -> channel(HIDDEN) ;
LINE_COMMENT_2 : '//' ~[\r\n]* -> channel(HIDDEN) ;

fragment HEX_DIGIT : [a-fA-F0-9] ;
fragment DIGIT : [0-9] ;
fragment HEX_NUMBER : '-'? '0' [xX] HEX_DIGIT+ ;
fragment OCT_NUMBER : '-'? '0' [oO] DIGIT+ ;
fragment BIN_NUMBER : '0' [bB] DIGIT+ ;
fragment DEC_NUMBER : '-'? DIGIT+ ;
NUMBER : HEX_NUMBER | OCT_NUMBER | BIN_NUMBER | DEC_NUMBER ;

LPAREN : '(' ;
RPAREN : ')' ;
LBRACKET : '[' ;
RBRACKET : ']' ;

ARITH_RSHIFT : '>>>' ;
RSHIFT : '>>' ;
LSHIFT : '<<' ;

AND : '&' ;
OR : '|' ;
MULTIPLY : '*' ;
DIVIDE : '/' ;
MODULO : '%' ;
ADD : '+' ;
MINUS : '-' ;
XOR : '^' ;
NOT : '~' ;
COLON : ':' ;
COMMA : ',' ;
ASSIGN : '=' ;

fragment WORD : [wW][oO][rR][dD] ;
KW_BYTE : [bB][yY][tT][eE] ;
KW_WORD : WORD ;
KW_DWORD : [dD] WORD ;
KW_QWORD : [qQ] WORD ;

REGISTER : [rR] [0-9]+ | [rR] [A-Z]+ ;
LABEL : [a-zA-Z_.][a-zA-Z0-9_.]* ;

WHITESPACE : [ \t\n\r] -> skip ;

file : entry* ;
label : LABEL COLON ;
mnemonic : LABEL ;
constName : LABEL ;

// variable definition label will be ignored later
entry
	: label? mnemonic operands? #instruction
	| label? type datum (COMMA datum)* #data
	| label? constName ASSIGN expr #constant
	;

operands
	: operand
	| operand COMMA operand
	| operand COMMA operand COMMA operand
	;

type
	: KW_BYTE
	| KW_WORD
	| KW_DWORD
	| KW_QWORD
	;

operand
	: expr #immOp
	| REGISTER #regOp
	| LBRACKET expr RBRACKET #immAddrOp
	| LBRACKET REGISTER RBRACKET #immRegOp
	;

datum
	: expr
	;

expr
	: <assoc=right> (MINUS | NOT) expr #negateExpr
	| LPAREN expr RPAREN #parenExpr
	| expr (MULTIPLY | DIVIDE | MODULO) expr #multExpr
	| expr (ADD | MINUS) expr #addExpr
	| expr (ARITH_RSHIFT | RSHIFT | LSHIFT) expr #shiftExpr
	| expr AND expr #andExpr
	| expr XOR expr #xorExpr
	| expr OR expr #orExpr
	| NUMBER #numberLit
	| LABEL #constantLit
	;
