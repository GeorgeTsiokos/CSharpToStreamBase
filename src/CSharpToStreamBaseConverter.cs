using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpToStreamBase
{
    public static class CSharpToStreamBaseConverter
    {
        private const string Indent = "  ";
        private const string Error = "A limited selection of c# is supported. Click the ? button to learn more.";
        private static readonly SyntaxAnnotation RemoveLeft = new SyntaxAnnotation("custom", "removeLeft");

        public static (string Name, string Implementation) Convert(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (string.Empty, string.Empty);

            try
            {
                var syntax = CSharpSyntaxTree.ParseText(value);

                var node = syntax.GetRoot().ChildNodes().First();
                if (!(node is MethodDeclarationSyntax method))
                    return (string.Empty, Error);

                var parameters = string.Join(
                    ", ",
                    method.ParameterList.Parameters.Select(p => $"{p.Identifier.Text} {Convert(p.Type)}"));

                var body = Convert(method.Body.ChildNodes().First());

                return (
                    method.Identifier.Text,
                    $"function {method.Identifier} ({parameters}) -> {Convert(method.ReturnType)} {{{body}\r\n}}");
            }
            catch
            {
                return (string.Empty, Error);
            }
        }

        private static string Convert(SyntaxNode node)
        {
            switch (node)
            {
                case ReturnStatementSyntax returnStatement:
                    return Convert(returnStatement.ChildNodes().First());
                case IdentifierNameSyntax identifierNameSyntax:
                    return identifierNameSyntax.Identifier.ValueText.Trim();
                case BinaryExpressionSyntax binaryExpressionSyntax:
                    var components = new List<string>
                    {
                        binaryExpressionSyntax.OperatorToken.Text,
                        Convert(binaryExpressionSyntax.Right)
                    };

                    if (!binaryExpressionSyntax.HasAnnotation(RemoveLeft))
                        components.Insert(0, Convert(binaryExpressionSyntax.Left));

                    return string.Join(" ", components);
                case ParenthesizedExpressionSyntax parenthesizedExpressionSyntax:
                    return $"({Convert(parenthesizedExpressionSyntax.Expression)})";
                case ConditionalExpressionSyntax conditionalExpressionSyntax:
                    var condition = Convert(conditionalExpressionSyntax.Condition);
                    var whenTrue = Convert(conditionalExpressionSyntax.WhenTrue);
                    var whenFalse = Convert(conditionalExpressionSyntax.WhenFalse);
                    return
                        $"\r\n{Indent}if {condition} then {whenTrue} else {whenFalse}";
                case SwitchStatementSyntax switchStatementSyntax:
                    var defaultSection =
                        switchStatementSyntax.Sections.FirstOrDefault(
                            section => section.Labels[0] is DefaultSwitchLabelSyntax);
                    var switchStatement = $"\r\n{Indent}if " + string.Join(
                                              $" else\r\n{Indent}if ",
                                              switchStatementSyntax.Sections
                                                  .Where(section => !ReferenceEquals(defaultSection, section))
                                                  .Select(Convert));

                    if (defaultSection != null)
                        switchStatement += $" else {Convert(defaultSection.Statements[0])}";

                    return switchStatement;
                case SwitchSectionSyntax switchSectionSyntax:
                    var switchParent = (SwitchStatementSyntax) switchSectionSyntax.Parent;
                    var switchLabelSyntax = switchSectionSyntax.Labels[0];
                    return
                        $"{Convert(switchParent.Expression) + Convert(switchLabelSyntax)} then {Convert(switchSectionSyntax.Statements[0])}";
                case CaseSwitchLabelSyntax caseSwitchLabelSyntax:
                    return Convert(caseSwitchLabelSyntax.Value);
                case CasePatternSwitchLabelSyntax casePatternSwitchLabelSyntax:
                    var whenCondition = casePatternSwitchLabelSyntax.WhenClause.Condition;
                    return ' ' + Convert(whenCondition.WithAdditionalAnnotations(RemoveLeft));
                default:
                    return node.GetText(Encoding.UTF8).ToString().Trim();
            }
        }

        private static string Convert(TypeSyntax typeSyntax)
        {
            if (typeSyntax is IdentifierNameSyntax identifierNameSyntax)
                switch (identifierNameSyntax.Identifier.ValueText)
                {
                    case nameof(Boolean):
                        return "bool";
                    case nameof(Byte):
                        return "int";
                    case nameof(Char):
                        return "string";
                    case nameof(Decimal):
                        return "decimal";
                    case nameof(Double):
                        return "double";
                    case nameof(Int16):
                    case nameof(Int32):
                        return "int";
                    case nameof(Int64):
                        return "long";
                    case nameof(Object):
                        return "object";
                    case nameof(SByte):
                        return "sbyte";
                    case nameof(Single):
                        return "float";
                    case nameof(String):
                        return "string";
                    case nameof(UInt16):
                        return "int";
                    case nameof(UInt32):
                        return "long";
                    case nameof(UInt64):
                        return "ulong";
                    case nameof(Byte) + "[]":
                        return "blob";
                    case nameof(DateTime):
                        return "timestamp";
                }

            return typeSyntax.ToString().Trim();
        }
    }
}