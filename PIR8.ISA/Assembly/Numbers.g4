grammar Numbers;

options {
	language = CSharp;
}

SIGN : '-' ;
HEX_INTRO : '0' [xX] ;
OCT_INTRO : '0' [oO] ;
BIN_INTRO : '0' [bB] ;
HEX_DIGITS : [a-fA-F0-9]+ ;
DIGITS : [0-9]+ ;

// checking whether the digits fit is done outside
// for better errors (otherwise 0b142 is parsed as 0 followed by b142 label)
number
	: SIGN? HEX_INTRO HEX_DIGITS #hex
	| SIGN? OCT_INTRO DIGITS #oct
	| BIN_INTRO DIGITS #bin
	| DIGITS #dec
	;
