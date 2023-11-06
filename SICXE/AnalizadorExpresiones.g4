grammar AnalizadorExpresiones;


/*
 * Parser Rules
 */

compileUnit
    returns [double value]
    : expr EOF { $value = $expr.value; }
    ;

expr
    returns [double value]
    : left=expr op=('*'|'/') right=expr { if ($op.text == "*") $value = $left.value * $right.value; else $value = $left.value / $right.value; }
    | left=expr op=('+'|'-') right=expr { if ($op.text == "+") $value = $left.value + $right.value; else $value = $left.value - $right.value; }
    | atom { $value = $atom.value; }
    ;

atom
    returns [double value]
    : '-' atom { $value = -$atom.value; } // Manejar números negativos
    | INT { $value = double.Parse($INT.text); }
    | '(' e=expr ')' { $value = $e.value; }
    | ID '=' e=expr { $value = $e.value; } // Asignación de identificadores
    | ID { /* Implementa la lógica para referencias a identificadores */ }
    | IDMAYUS '=' e=expr { $value = $e.value; } // Asignación de identificadores
    | IDMAYUS { /* Implementa la lógica para referencias a identificadores */ }
    ;

/*
 * Lexer Rules
 */
ID      : [a-z]+;
IDMAYUS : [A-Z]+;
IGUAL   : '=';
INT     : [0-9]+;
MUL     : '*';
DIV     : '/';
ADD     : '+';
SUB     : '-';
WS      : [ \t\r\n]+ -> skip;

