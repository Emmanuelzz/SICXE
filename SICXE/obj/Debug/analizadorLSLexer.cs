//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\emman\OneDrive\Documentos\Semestre 8\Laboratorio de Fundamentos de Software de Sistemas\PROYECTO REPOSITORIO\SICXE\SICXE\analizadorLS.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace SICXE {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class analizadorLSLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		CODOPF1=18, CODOPF2=19, CODOPF3=20, REG=21, START=22, BYTE=23, WORD=24, 
		RESB=25, RESW=26, BASE=27, EQU=28, END=29, NUM=30, CONSTHEX=31, VALOR=32, 
		M=33, FINL=34, EXT=35, WS=36;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"CODOPF1", "CODOPF2", "CODOPF3", "REG", "START", "BYTE", "WORD", "RESB", 
		"RESW", "BASE", "EQU", "END", "NUM", "CONSTHEX", "VALOR", "M", "FINL", 
		"EXT", "WS"
	};


	public analizadorLSLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'0'", "'1'", "'*'", "'-'", "'/'", "'('", "')'", "','", "'X'", "'CLEAR'", 
		"'TIXR'", "'RSUB'", "'@'", "'#'", "'H'", "'''", "'C'", null, null, null, 
		null, "'START'", "'BYTE'", "'WORD'", "'RESB'", "'RESW'", "'BASE'", "'EQU'", 
		"'END'", null, null, null, null, "'\n'", "'+'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, "CODOPF1", "CODOPF2", "CODOPF3", "REG", 
		"START", "BYTE", "WORD", "RESB", "RESW", "BASE", "EQU", "END", "NUM", 
		"CONSTHEX", "VALOR", "M", "FINL", "EXT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "analizadorLS.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 35 : WS_action(_localctx, actionIndex); break;
		}
	}
	private void WS_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0: Skip(); break;
		}
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2&\x196\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4"+
		"\x3\x5\x3\x5\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\n\x3\n\x3\v"+
		"\x3\v\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r"+
		"\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12"+
		"\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13"+
		"\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13"+
		"\x3\x13\x5\x13\x8D\n\x13\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x5\x14\xBF\n\x14\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x5\x15\x145\n\x15\x3\x16\x3"+
		"\x16\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x18\x3\x18\x3\x18\x3"+
		"\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1A\x3"+
		"\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3"+
		"\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3"+
		"\x1F\x6\x1F\x171\n\x1F\r\x1F\xE\x1F\x172\x3 \x6 \x176\n \r \xE \x177\x3"+
		"!\x6!\x17B\n!\r!\xE!\x17C\x3!\x3!\x6!\x181\n!\r!\xE!\x182\x5!\x185\n!"+
		"\x3\"\x6\"\x188\n\"\r\"\xE\"\x189\x3#\x3#\x3$\x3$\x3%\x6%\x191\n%\r%\xE"+
		"%\x192\x3%\x3%\x2\x2\x2&\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2"+
		"\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D"+
		"\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2"+
		"\x18/\x2\x19\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2"+
		"\x1F=\x2 ?\x2!\x41\x2\"\x43\x2#\x45\x2$G\x2%I\x2&\x3\x2\x6\a\x2\x43\x44"+
		"HHNNUVZZ\x4\x2\x32;\x43H\x4\x2\x32;\x43\\\x6\x2\v\f\xF\xF\"\"//\x1D4\x2"+
		"\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2"+
		"\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2"+
		"\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2"+
		"\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2"+
		"\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2"+
		"\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2"+
		"\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2"+
		"\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2"+
		"\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2"+
		"\x3K\x3\x2\x2\x2\x5M\x3\x2\x2\x2\aO\x3\x2\x2\x2\tQ\x3\x2\x2\x2\vS\x3\x2"+
		"\x2\x2\rU\x3\x2\x2\x2\xFW\x3\x2\x2\x2\x11Y\x3\x2\x2\x2\x13[\x3\x2\x2\x2"+
		"\x15]\x3\x2\x2\x2\x17\x63\x3\x2\x2\x2\x19h\x3\x2\x2\x2\x1Bm\x3\x2\x2\x2"+
		"\x1Do\x3\x2\x2\x2\x1Fq\x3\x2\x2\x2!s\x3\x2\x2\x2#u\x3\x2\x2\x2%\x8C\x3"+
		"\x2\x2\x2\'\xBE\x3\x2\x2\x2)\x144\x3\x2\x2\x2+\x146\x3\x2\x2\x2-\x148"+
		"\x3\x2\x2\x2/\x14E\x3\x2\x2\x2\x31\x153\x3\x2\x2\x2\x33\x158\x3\x2\x2"+
		"\x2\x35\x15D\x3\x2\x2\x2\x37\x162\x3\x2\x2\x2\x39\x167\x3\x2\x2\x2;\x16B"+
		"\x3\x2\x2\x2=\x170\x3\x2\x2\x2?\x175\x3\x2\x2\x2\x41\x184\x3\x2\x2\x2"+
		"\x43\x187\x3\x2\x2\x2\x45\x18B\x3\x2\x2\x2G\x18D\x3\x2\x2\x2I\x190\x3"+
		"\x2\x2\x2KL\a\x32\x2\x2L\x4\x3\x2\x2\x2MN\a\x33\x2\x2N\x6\x3\x2\x2\x2"+
		"OP\a,\x2\x2P\b\x3\x2\x2\x2QR\a/\x2\x2R\n\x3\x2\x2\x2ST\a\x31\x2\x2T\f"+
		"\x3\x2\x2\x2UV\a*\x2\x2V\xE\x3\x2\x2\x2WX\a+\x2\x2X\x10\x3\x2\x2\x2YZ"+
		"\a.\x2\x2Z\x12\x3\x2\x2\x2[\\\aZ\x2\x2\\\x14\x3\x2\x2\x2]^\a\x45\x2\x2"+
		"^_\aN\x2\x2_`\aG\x2\x2`\x61\a\x43\x2\x2\x61\x62\aT\x2\x2\x62\x16\x3\x2"+
		"\x2\x2\x63\x64\aV\x2\x2\x64\x65\aK\x2\x2\x65\x66\aZ\x2\x2\x66g\aT\x2\x2"+
		"g\x18\x3\x2\x2\x2hi\aT\x2\x2ij\aU\x2\x2jk\aW\x2\x2kl\a\x44\x2\x2l\x1A"+
		"\x3\x2\x2\x2mn\a\x42\x2\x2n\x1C\x3\x2\x2\x2op\a%\x2\x2p\x1E\x3\x2\x2\x2"+
		"qr\aJ\x2\x2r \x3\x2\x2\x2st\a)\x2\x2t\"\x3\x2\x2\x2uv\a\x45\x2\x2v$\x3"+
		"\x2\x2\x2wx\aH\x2\x2xy\aK\x2\x2y\x8D\aZ\x2\x2z{\aH\x2\x2{|\aN\x2\x2|}"+
		"\aQ\x2\x2}~\a\x43\x2\x2~\x8D\aV\x2\x2\x7F\x80\aJ\x2\x2\x80\x81\aK\x2\x2"+
		"\x81\x8D\aQ\x2\x2\x82\x83\aP\x2\x2\x83\x84\aQ\x2\x2\x84\x85\aT\x2\x2\x85"+
		"\x8D\aO\x2\x2\x86\x87\aU\x2\x2\x87\x88\aK\x2\x2\x88\x8D\aQ\x2\x2\x89\x8A"+
		"\aV\x2\x2\x8A\x8B\aK\x2\x2\x8B\x8D\aQ\x2\x2\x8Cw\x3\x2\x2\x2\x8Cz\x3\x2"+
		"\x2\x2\x8C\x7F\x3\x2\x2\x2\x8C\x82\x3\x2\x2\x2\x8C\x86\x3\x2\x2\x2\x8C"+
		"\x89\x3\x2\x2\x2\x8D&\x3\x2\x2\x2\x8E\x8F\a\x43\x2\x2\x8F\x90\a\x46\x2"+
		"\x2\x90\x91\a\x46\x2\x2\x91\xBF\aT\x2\x2\x92\x93\a\x45\x2\x2\x93\x94\a"+
		"N\x2\x2\x94\x95\aG\x2\x2\x95\x96\a\x43\x2\x2\x96\xBF\aT\x2\x2\x97\x98"+
		"\a\x45\x2\x2\x98\x99\aQ\x2\x2\x99\x9A\aO\x2\x2\x9A\x9B\aR\x2\x2\x9B\xBF"+
		"\aT\x2\x2\x9C\x9D\a\x46\x2\x2\x9D\x9E\aK\x2\x2\x9E\x9F\aX\x2\x2\x9F\xBF"+
		"\aT\x2\x2\xA0\xA1\aO\x2\x2\xA1\xA2\aW\x2\x2\xA2\xA3\aN\x2\x2\xA3\xBF\a"+
		"T\x2\x2\xA4\xA5\aT\x2\x2\xA5\xA6\aO\x2\x2\xA6\xBF\aQ\x2\x2\xA7\xA8\aU"+
		"\x2\x2\xA8\xA9\aJ\x2\x2\xA9\xAA\aK\x2\x2\xAA\xAB\aH\x2\x2\xAB\xAC\aV\x2"+
		"\x2\xAC\xBF\aN\x2\x2\xAD\xAE\aU\x2\x2\xAE\xAF\aJ\x2\x2\xAF\xB0\aK\x2\x2"+
		"\xB0\xB1\aH\x2\x2\xB1\xB2\aV\x2\x2\xB2\xBF\aT\x2\x2\xB3\xB4\aU\x2\x2\xB4"+
		"\xB5\aW\x2\x2\xB5\xB6\a\x44\x2\x2\xB6\xBF\aT\x2\x2\xB7\xB8\aU\x2\x2\xB8"+
		"\xB9\aX\x2\x2\xB9\xBF\a\x45\x2\x2\xBA\xBB\aV\x2\x2\xBB\xBC\aK\x2\x2\xBC"+
		"\xBD\aZ\x2\x2\xBD\xBF\aT\x2\x2\xBE\x8E\x3\x2\x2\x2\xBE\x92\x3\x2\x2\x2"+
		"\xBE\x97\x3\x2\x2\x2\xBE\x9C\x3\x2\x2\x2\xBE\xA0\x3\x2\x2\x2\xBE\xA4\x3"+
		"\x2\x2\x2\xBE\xA7\x3\x2\x2\x2\xBE\xAD\x3\x2\x2\x2\xBE\xB3\x3\x2\x2\x2"+
		"\xBE\xB7\x3\x2\x2\x2\xBE\xBA\x3\x2\x2\x2\xBF(\x3\x2\x2\x2\xC0\xC1\a\x43"+
		"\x2\x2\xC1\xC2\a\x46\x2\x2\xC2\x145\a\x46\x2\x2\xC3\xC4\a\x43\x2\x2\xC4"+
		"\xC5\a\x46\x2\x2\xC5\xC6\a\x46\x2\x2\xC6\x145\aH\x2\x2\xC7\xC8\a\x43\x2"+
		"\x2\xC8\xC9\aP\x2\x2\xC9\x145\a\x46\x2\x2\xCA\xCB\a\x45\x2\x2\xCB\xCC"+
		"\aQ\x2\x2\xCC\xCD\aO\x2\x2\xCD\x145\aR\x2\x2\xCE\xCF\a\x45\x2\x2\xCF\xD0"+
		"\aQ\x2\x2\xD0\xD1\aO\x2\x2\xD1\xD2\aR\x2\x2\xD2\x145\aH\x2\x2\xD3\xD4"+
		"\a\x46\x2\x2\xD4\xD5\aK\x2\x2\xD5\x145\aX\x2\x2\xD6\xD7\a\x46\x2\x2\xD7"+
		"\xD8\aK\x2\x2\xD8\xD9\aX\x2\x2\xD9\x145\aH\x2\x2\xDA\x145\aL\x2\x2\xDB"+
		"\xDC\aL\x2\x2\xDC\xDD\aG\x2\x2\xDD\x145\aS\x2\x2\xDE\xDF\aL\x2\x2\xDF"+
		"\xE0\aI\x2\x2\xE0\x145\aV\x2\x2\xE1\xE2\aL\x2\x2\xE2\xE3\aN\x2\x2\xE3"+
		"\x145\aV\x2\x2\xE4\xE5\aL\x2\x2\xE5\xE6\aU\x2\x2\xE6\xE7\aW\x2\x2\xE7"+
		"\x145\a\x44\x2\x2\xE8\xE9\aN\x2\x2\xE9\xEA\a\x46\x2\x2\xEA\x145\a\x43"+
		"\x2\x2\xEB\xEC\aN\x2\x2\xEC\xED\a\x46\x2\x2\xED\x145\a\x44\x2\x2\xEE\xEF"+
		"\aN\x2\x2\xEF\xF0\a\x46\x2\x2\xF0\xF1\a\x45\x2\x2\xF1\x145\aJ\x2\x2\xF2"+
		"\xF3\aN\x2\x2\xF3\xF4\a\x46\x2\x2\xF4\x145\aH\x2\x2\xF5\xF6\aN\x2\x2\xF6"+
		"\xF7\a\x46\x2\x2\xF7\x145\aN\x2\x2\xF8\xF9\aN\x2\x2\xF9\xFA\a\x46\x2\x2"+
		"\xFA\x145\aU\x2\x2\xFB\xFC\aN\x2\x2\xFC\xFD\a\x46\x2\x2\xFD\x145\aV\x2"+
		"\x2\xFE\xFF\aN\x2\x2\xFF\x100\a\x46\x2\x2\x100\x145\aZ\x2\x2\x101\x102"+
		"\aN\x2\x2\x102\x103\aR\x2\x2\x103\x145\aU\x2\x2\x104\x105\aO\x2\x2\x105"+
		"\x106\aW\x2\x2\x106\x145\aN\x2\x2\x107\x108\aO\x2\x2\x108\x109\aW\x2\x2"+
		"\x109\x10A\aN\x2\x2\x10A\x145\aH\x2\x2\x10B\x10C\aQ\x2\x2\x10C\x145\a"+
		"T\x2\x2\x10D\x10E\aT\x2\x2\x10E\x145\a\x46\x2\x2\x10F\x110\aT\x2\x2\x110"+
		"\x111\aU\x2\x2\x111\x112\aW\x2\x2\x112\x145\a\x44\x2\x2\x113\x114\aU\x2"+
		"\x2\x114\x115\aU\x2\x2\x115\x145\aM\x2\x2\x116\x117\aU\x2\x2\x117\x118"+
		"\aV\x2\x2\x118\x145\a\x43\x2\x2\x119\x11A\aU\x2\x2\x11A\x11B\aV\x2\x2"+
		"\x11B\x145\a\x44\x2\x2\x11C\x11D\aU\x2\x2\x11D\x11E\aV\x2\x2\x11E\x11F"+
		"\a\x45\x2\x2\x11F\x145\aJ\x2\x2\x120\x121\aU\x2\x2\x121\x122\aV\x2\x2"+
		"\x122\x145\aH\x2\x2\x123\x124\aU\x2\x2\x124\x125\aV\x2\x2\x125\x145\a"+
		"K\x2\x2\x126\x127\aU\x2\x2\x127\x128\aV\x2\x2\x128\x145\aN\x2\x2\x129"+
		"\x12A\aU\x2\x2\x12A\x12B\aV\x2\x2\x12B\x145\aU\x2\x2\x12C\x12D\aU\x2\x2"+
		"\x12D\x12E\aV\x2\x2\x12E\x12F\aU\x2\x2\x12F\x145\aY\x2\x2\x130\x131\a"+
		"U\x2\x2\x131\x132\aV\x2\x2\x132\x145\aV\x2\x2\x133\x134\aU\x2\x2\x134"+
		"\x135\aV\x2\x2\x135\x145\aZ\x2\x2\x136\x137\aU\x2\x2\x137\x138\aW\x2\x2"+
		"\x138\x145\a\x44\x2\x2\x139\x13A\aU\x2\x2\x13A\x13B\aW\x2\x2\x13B\x13C"+
		"\a\x44\x2\x2\x13C\x145\aH\x2\x2\x13D\x13E\aV\x2\x2\x13E\x145\a\x46\x2"+
		"\x2\x13F\x140\aV\x2\x2\x140\x141\aK\x2\x2\x141\x145\aZ\x2\x2\x142\x143"+
		"\aY\x2\x2\x143\x145\a\x46\x2\x2\x144\xC0\x3\x2\x2\x2\x144\xC3\x3\x2\x2"+
		"\x2\x144\xC7\x3\x2\x2\x2\x144\xCA\x3\x2\x2\x2\x144\xCE\x3\x2\x2\x2\x144"+
		"\xD3\x3\x2\x2\x2\x144\xD6\x3\x2\x2\x2\x144\xDA\x3\x2\x2\x2\x144\xDB\x3"+
		"\x2\x2\x2\x144\xDE\x3\x2\x2\x2\x144\xE1\x3\x2\x2\x2\x144\xE4\x3\x2\x2"+
		"\x2\x144\xE8\x3\x2\x2\x2\x144\xEB\x3\x2\x2\x2\x144\xEE\x3\x2\x2\x2\x144"+
		"\xF2\x3\x2\x2\x2\x144\xF5\x3\x2\x2\x2\x144\xF8\x3\x2\x2\x2\x144\xFB\x3"+
		"\x2\x2\x2\x144\xFE\x3\x2\x2\x2\x144\x101\x3\x2\x2\x2\x144\x104\x3\x2\x2"+
		"\x2\x144\x107\x3\x2\x2\x2\x144\x10B\x3\x2\x2\x2\x144\x10D\x3\x2\x2\x2"+
		"\x144\x10F\x3\x2\x2\x2\x144\x113\x3\x2\x2\x2\x144\x116\x3\x2\x2\x2\x144"+
		"\x119\x3\x2\x2\x2\x144\x11C\x3\x2\x2\x2\x144\x120\x3\x2\x2\x2\x144\x123"+
		"\x3\x2\x2\x2\x144\x126\x3\x2\x2\x2\x144\x129\x3\x2\x2\x2\x144\x12C\x3"+
		"\x2\x2\x2\x144\x130\x3\x2\x2\x2\x144\x133\x3\x2\x2\x2\x144\x136\x3\x2"+
		"\x2\x2\x144\x139\x3\x2\x2\x2\x144\x13D\x3\x2\x2\x2\x144\x13F\x3\x2\x2"+
		"\x2\x144\x142\x3\x2\x2\x2\x145*\x3\x2\x2\x2\x146\x147\t\x2\x2\x2\x147"+
		",\x3\x2\x2\x2\x148\x149\aU\x2\x2\x149\x14A\aV\x2\x2\x14A\x14B\a\x43\x2"+
		"\x2\x14B\x14C\aT\x2\x2\x14C\x14D\aV\x2\x2\x14D.\x3\x2\x2\x2\x14E\x14F"+
		"\a\x44\x2\x2\x14F\x150\a[\x2\x2\x150\x151\aV\x2\x2\x151\x152\aG\x2\x2"+
		"\x152\x30\x3\x2\x2\x2\x153\x154\aY\x2\x2\x154\x155\aQ\x2\x2\x155\x156"+
		"\aT\x2\x2\x156\x157\a\x46\x2\x2\x157\x32\x3\x2\x2\x2\x158\x159\aT\x2\x2"+
		"\x159\x15A\aG\x2\x2\x15A\x15B\aU\x2\x2\x15B\x15C\a\x44\x2\x2\x15C\x34"+
		"\x3\x2\x2\x2\x15D\x15E\aT\x2\x2\x15E\x15F\aG\x2\x2\x15F\x160\aU\x2\x2"+
		"\x160\x161\aY\x2\x2\x161\x36\x3\x2\x2\x2\x162\x163\a\x44\x2\x2\x163\x164"+
		"\a\x43\x2\x2\x164\x165\aU\x2\x2\x165\x166\aG\x2\x2\x166\x38\x3\x2\x2\x2"+
		"\x167\x168\aG\x2\x2\x168\x169\aS\x2\x2\x169\x16A\aW\x2\x2\x16A:\x3\x2"+
		"\x2\x2\x16B\x16C\aG\x2\x2\x16C\x16D\aP\x2\x2\x16D\x16E\a\x46\x2\x2\x16E"+
		"<\x3\x2\x2\x2\x16F\x171\x4\x32;\x2\x170\x16F\x3\x2\x2\x2\x171\x172\x3"+
		"\x2\x2\x2\x172\x170\x3\x2\x2\x2\x172\x173\x3\x2\x2\x2\x173>\x3\x2\x2\x2"+
		"\x174\x176\t\x3\x2\x2\x175\x174\x3\x2\x2\x2\x176\x177\x3\x2\x2\x2\x177"+
		"\x175\x3\x2\x2\x2\x177\x178\x3\x2\x2\x2\x178@\x3\x2\x2\x2\x179\x17B\x4"+
		"\x32;\x2\x17A\x179\x3\x2\x2\x2\x17B\x17C\x3\x2\x2\x2\x17C\x17A\x3\x2\x2"+
		"\x2\x17C\x17D\x3\x2\x2\x2\x17D\x17E\x3\x2\x2\x2\x17E\x185\aJ\x2\x2\x17F"+
		"\x181\x4\x32;\x2\x180\x17F\x3\x2\x2\x2\x181\x182\x3\x2\x2\x2\x182\x180"+
		"\x3\x2\x2\x2\x182\x183\x3\x2\x2\x2\x183\x185\x3\x2\x2\x2\x184\x17A\x3"+
		"\x2\x2\x2\x184\x180\x3\x2\x2\x2\x185\x42\x3\x2\x2\x2\x186\x188\t\x4\x2"+
		"\x2\x187\x186\x3\x2\x2\x2\x188\x189\x3\x2\x2\x2\x189\x187\x3\x2\x2\x2"+
		"\x189\x18A\x3\x2\x2\x2\x18A\x44\x3\x2\x2\x2\x18B\x18C\a\f\x2\x2\x18C\x46"+
		"\x3\x2\x2\x2\x18D\x18E\a-\x2\x2\x18EH\x3\x2\x2\x2\x18F\x191\t\x5\x2\x2"+
		"\x190\x18F\x3\x2\x2\x2\x191\x192\x3\x2\x2\x2\x192\x190\x3\x2\x2\x2\x192"+
		"\x193\x3\x2\x2\x2\x193\x194\x3\x2\x2\x2\x194\x195\b%\x2\x2\x195J\x3\x2"+
		"\x2\x2\xF\x2\x8C\xBE\x144\x172\x175\x177\x17C\x182\x184\x187\x189\x192"+
		"\x3\x3%\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace SICXE
