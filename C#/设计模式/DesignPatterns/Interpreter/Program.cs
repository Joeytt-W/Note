using Interpreter;

Console.Title = "Interpreter";


var expressions = new List<RomanExpression>()
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression()
};

var context = new RomanContext(5);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numbers to Roman numbers: 5 = {context.Output}");

context = new RomanContext(81);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numbers to Roman numbers: 81 = {context.Output}");

context = new RomanContext(733);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numbers to Roman numbers: 733 = {context.Output}");

Console.ReadKey();