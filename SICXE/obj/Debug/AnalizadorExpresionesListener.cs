﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Joan Hernández\Documents\Software de Sistemas\LAB\LABSW\SICXE\AnalizadorExpresiones.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace SICXE {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="AnalizadorExpresionesParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IAnalizadorExpresionesListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorExpresionesParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompileUnit([NotNull] AnalizadorExpresionesParser.CompileUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorExpresionesParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompileUnit([NotNull] AnalizadorExpresionesParser.CompileUnitContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorExpresionesParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] AnalizadorExpresionesParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorExpresionesParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] AnalizadorExpresionesParser.ExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorExpresionesParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtom([NotNull] AnalizadorExpresionesParser.AtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorExpresionesParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtom([NotNull] AnalizadorExpresionesParser.AtomContext context);
}
} // namespace SICXE
