grammar analizadorLS;								//nombre de la gramatica

/*
*opciones de compilacion de la gramatica
*/
options {							
    language=CSharp2;								//lenguaje objetivo de la gramatica
}

/*
*	Reglas del Parser
*/
programa
	:inicio EOF |inicio FINL
	; 

inicio	
	:proposicion |fin
	;
	
proposicion
	:instruccion | directiva
	;
	
instruccion
	:etiqueta opinstruccion | opinstruccion
	;
	
directiva
	:etiqueta tipodirectiva  | tipodirectiva 
	;

opinstruccion
	:formato
	;
	
tipodirectiva
	:START '0'| START opvalor | BYTE opdirectiva
	| WORD opvalor | RESB opvalor | RESW opvalor 
	| BASE M | WORD NUM | RESB NUM | RESW NUM | WORD '0' 
	|RESW '1'|RESW '0'|RESB '1'|RESB '0'|
	;

opvalor	:VALOR
	;

	
fin	
	:END etiqueta| M END etiqueta | END	
	;

etiqueta
	:M
	;
	
formato
	:f1 | f2 | f3 | f4 
	;
	
f1
	:CODOPF1
	;
	
f2
	:CODOPF2 NUM | CODOPF2 REG ',' REG | CODOPF2 REG ',' NUM | CODOPF2 'X'',' REG 
	| 'CLEAR' REG | CODOPF2 'X' |CODOPF2 'X' ',' NUM | 'TIXR' REG |CODOPF2 REG ',' 'X' 
	| CODOPF2 NUM |CODOPF2 REG ',' NUM
	;

f3
	:simple3 | indirecto3 | inmediato3
	;
f4
	:EXT f3
	;
	
simple3
	:CODOPF3 M | CODOPF3 NUM | CODOPF3 NUM ',' 'X' | CODOPF3 M ',' 'X' | 'RSUB'
	;

indirecto3
	:CODOPF3 '@' NUM | CODOPF3 '@' M |CODOPF3 '@' opvalor
	;
	
inmediato3
	:CODOPF3 '#' NUM | CODOPF3 '#' M |CODOPF3 '#' opvalor
	;

opdirectiva
	:'H' '\'' CONSTHEX '\''
	| 'C' '\'' .*? '\''
	;
	
/*
*	Reglas del Lexer.
*/


CODOPF1	:'FIX'|'FLOAT'|'HIO'|'NORM'|'SIO'|'TIO'	
	;	
	
CODOPF2	:'ADDR'|'DIVR'|'MULR'|'RMO'|'SHIFTL'|'SHIFTR'
	;

CODOPF3	:'ADD'|'ADDF'|'AND'|'COMP'|'LDA'|'LDB'|'LDX'|'STA'
	|'TIX'| 'JEQ' |'STL'|'JSUB'|'J'|'LDL'|'TD'|'RD'|'STCH'|'JLT'|'STX'|'LDCH'|'WD'
	;
	
REG	:'A'|'X'|'L'|'B'|'S'|'T'|'F'
	;
	
START	:'START'
	;

BYTE	:'BYTE'
	;

WORD	:'WORD'
	;

RESB	:'RESB'
	;

RESW	:'RESW'
	;	

BASE	:'BASE'
	;

END	:'END'
	;
	
NUM	:('0'..'9')+
	;
	
CONSTHEX
	:(('A'..'F')|('0'..'9'))+
	;

VALOR	:('0'..'9')+'H'|('0'..'9')+
	;
	
M	:(('A'..'Z')|('0'..'9'))+
	;
	
FINL	:'\n'
	;

EXT	:'+'
	;

WS
	: (' '|'-'|'\r'|'\n'|'\t')+ {Skip();}	//tokens que identifican las secuencas de escape.
	;