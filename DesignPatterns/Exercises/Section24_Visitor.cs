using System.Text;

namespace DesignPatterns.Exercises.Section24_Visitor
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value value);
        public abstract void Visit(AdditionExpression ae);
        public abstract void Visit(MultiplicationExpression me);
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public override void Visit(Value value)
        {
            stringBuilder.Append(value.TheValue);
        }

        public override void Visit(AdditionExpression ae)
        {
            stringBuilder.Append('(');
            ae.LHS.Accept(this);
            stringBuilder.Append('+');
            ae.RHS.Accept(this);
            stringBuilder.Append(')');
        }

        public override void Visit(MultiplicationExpression me)
        {
            me.LHS.Accept(this);
            stringBuilder.Append('*');
            me.RHS.Accept(this);
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}
