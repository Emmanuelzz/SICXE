﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Joan Hernández\Documents\Software de Sistemas\LAB\LABSW\SICXE\analizadorLS.g4 by ANTLR 4.6.6

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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IanalizadorLSListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class analizadorLSBaseListener : IanalizadorLSListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.programa"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrograma([NotNull] analizadorLSParser.ProgramaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.programa"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrograma([NotNull] analizadorLSParser.ProgramaContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.inicio"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInicio([NotNull] analizadorLSParser.InicioContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.inicio"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInicio([NotNull] analizadorLSParser.InicioContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.proposicion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProposicion([NotNull] analizadorLSParser.ProposicionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.proposicion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProposicion([NotNull] analizadorLSParser.ProposicionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.instruccion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInstruccion([NotNull] analizadorLSParser.InstruccionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.instruccion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInstruccion([NotNull] analizadorLSParser.InstruccionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.directiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDirectiva([NotNull] analizadorLSParser.DirectivaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.directiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDirectiva([NotNull] analizadorLSParser.DirectivaContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.opinstruccion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOpinstruccion([NotNull] analizadorLSParser.OpinstruccionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.opinstruccion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOpinstruccion([NotNull] analizadorLSParser.OpinstruccionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.tipodirectiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTipodirectiva([NotNull] analizadorLSParser.TipodirectivaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.tipodirectiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTipodirectiva([NotNull] analizadorLSParser.TipodirectivaContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.opvalor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOpvalor([NotNull] analizadorLSParser.OpvalorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.opvalor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOpvalor([NotNull] analizadorLSParser.OpvalorContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.expresion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpresion([NotNull] analizadorLSParser.ExpresionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.expresion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpresion([NotNull] analizadorLSParser.ExpresionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.multiplicacion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplicacion([NotNull] analizadorLSParser.MultiplicacionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.multiplicacion"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplicacion([NotNull] analizadorLSParser.MultiplicacionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.numero"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumero([NotNull] analizadorLSParser.NumeroContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.numero"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumero([NotNull] analizadorLSParser.NumeroContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.fin"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFin([NotNull] analizadorLSParser.FinContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.fin"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFin([NotNull] analizadorLSParser.FinContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.etiqueta"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEtiqueta([NotNull] analizadorLSParser.EtiquetaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.etiqueta"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEtiqueta([NotNull] analizadorLSParser.EtiquetaContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.formato"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFormato([NotNull] analizadorLSParser.FormatoContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.formato"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFormato([NotNull] analizadorLSParser.FormatoContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.f1"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterF1([NotNull] analizadorLSParser.F1Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.f1"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitF1([NotNull] analizadorLSParser.F1Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.f2"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterF2([NotNull] analizadorLSParser.F2Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.f2"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitF2([NotNull] analizadorLSParser.F2Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.f3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterF3([NotNull] analizadorLSParser.F3Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.f3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitF3([NotNull] analizadorLSParser.F3Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.f4"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterF4([NotNull] analizadorLSParser.F4Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.f4"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitF4([NotNull] analizadorLSParser.F4Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.simple3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSimple3([NotNull] analizadorLSParser.Simple3Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.simple3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSimple3([NotNull] analizadorLSParser.Simple3Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.indirecto3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndirecto3([NotNull] analizadorLSParser.Indirecto3Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.indirecto3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndirecto3([NotNull] analizadorLSParser.Indirecto3Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.inmediato3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInmediato3([NotNull] analizadorLSParser.Inmediato3Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.inmediato3"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInmediato3([NotNull] analizadorLSParser.Inmediato3Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="analizadorLSParser.opdirectiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOpdirectiva([NotNull] analizadorLSParser.OpdirectivaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="analizadorLSParser.opdirectiva"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOpdirectiva([NotNull] analizadorLSParser.OpdirectivaContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace SICXE
