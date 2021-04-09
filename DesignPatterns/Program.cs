using DesignPatterns.Exercises.Section02_Builder;
using DesignPatterns.Exercises.Section03_Factory;
using DesignPatterns.Exercises.Section04_Prototype;
using DesignPatterns.Exercises.Section05_Singleton;
using DesignPatterns.Exercises.Section06_Adapter;
using DesignPatterns.Exercises.Section07_Bridge;
using DesignPatterns.Exercises.Section08_Composite;
using DesignPatterns.Exercises.Section09_Decorator;
using DesignPatterns.Exercises.Section10_Facade;
using DesignPatterns.Exercises.Section11_Flyweight;
using DesignPatterns.Exercises.Section12_Proxy;
using DesignPatterns.Exercises.Section14_Command;
using DesignPatterns.Exercises.Section15_Interpreter;
using DesignPatterns.Exercises.Section16_Iterator;
using DesignPatterns.Exercises.Section17_Mediator;
using DesignPatterns.Exercises.Section18_Memento;
using DesignPatterns.Exercises.Section19_NullObject;
using DesignPatterns.Exercises.Section20_Observer;
using DesignPatterns.Exercises.Section21_StateMachine;
using DesignPatterns.Exercises.Section22_Strategy;
using DesignPatterns.Exercises.Section23_TemplateMethod;
using DesignPatterns.Exercises.Section24_Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using static DesignPatterns.Exercises.Section13_ChainOfResponsibility;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] _)
        {
            Section2_Builder();
            Section3_Factory();
            Section4_Prototype();
            Section5_Singleton();
            Section6_Adapter();
            Section7_Bridge();
            Section8_Composite();
            Section9_Decorator();
            Section10_Facade();
            Section11_Flyweight();
            Section12_Proxy();
            Section13_ChainOfResponsibility();
            Section14_Command();
            Section15_Interpreter();
            Section16_Iterator();
            Section17_Mediator();
            Section18_Memento();
            Section19_NullObject();
            Section20_Observer();
            Section21_StateMachine();
            Section22_Strategy();
            Section23_TemplateMethod();
            Section24_Visitor();
            Section();

        }

        static void Section2_Builder()
        {
            Console.WriteLine("---Section2_Builder");
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section3_Factory()
        {
            Console.WriteLine("---Section3_Builder");
            var pf = new PersonFactory();
            var p = pf.CreatePerson("John");
            Console.WriteLine(p);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section4_Prototype()
        {
            Console.WriteLine("---Section4_Prototype");
            var line = new Line { Start = new Point { X = 0, Y = 0 }, End = new Point { X = 1, Y = 1 } };
            var copy = line.DeepCopy();
            line.End.Y = 2;
            copy.End.Y = 3;
            Console.WriteLine(line);
            Console.WriteLine(copy);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section5_Singleton()
        {
            Console.WriteLine("---Section5_Singleton");
            var instance = new string[] { "a" };
            var isSingleton = SingletonTester.IsSingleton(() => instance);
            Console.WriteLine($"Singleton, IsSingleton: {isSingleton}");
            isSingleton = SingletonTester.IsSingleton(() => new string[] { "a" });
            Console.WriteLine($"Not Singleton, IsSingleton: {isSingleton}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section6_Adapter()
        {
            Console.WriteLine("---Section6_Adapter");
            var square = new Exercises.Section06_Adapter.Square() { Side = 4 };
            var adapter = new SquareToRectangleAdapter(square);
            Console.WriteLine($"Side: {square.Side}, Area: {adapter.Area()}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section7_Bridge()
        {
            Console.WriteLine("---Section7_Bridge");
            var square = new Exercises.Section07_Bridge.Square(new VectorRenderer());
            Console.WriteLine(square.ToString());
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section8_Composite()
        {
            Console.WriteLine("---Section8_Composite");
            var values = new ManyValues { 1, 2 };
            var value = new SingleValue { Value = 3 };
            var containers = new List<IValueContainer> { values, value };
            var sumString = string.Join(" + ", containers.SelectMany(c => c));
            Console.WriteLine($"{sumString} = {containers.Sum()}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section9_Decorator()
        {
            Console.WriteLine("---Section9_Decorator");
            var dragon = new Dragon() { Age = 0 };
            Console.WriteLine($"Age: {dragon.Age}, Fly: {dragon.Fly()}, Crawl: {dragon.Crawl()}");
            dragon = new Dragon() { Age = 2 };
            Console.WriteLine($"Age: {dragon.Age}, Fly: {dragon.Fly()}, Crawl: {dragon.Crawl()}");
            dragon = new Dragon() { Age = 10 };
            Console.WriteLine($"Age: {dragon.Age}, Fly: {dragon.Fly()}, Crawl: {dragon.Crawl()}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section10_Facade()
        {
            Console.WriteLine("---");
            var maqicSquare = new MagicSquareGenerator().Generate(3);
            foreach (var row in maqicSquare)
            {
                Console.WriteLine(string.Join(' ', row));
            }
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section11_Flyweight()
        {
            Console.WriteLine("---Section11_Flyweight");
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section12_Proxy()
        {
            Console.WriteLine("---");
            var responsiblePerson = new ResponsiblePerson(new Exercises.Section12_Proxy.Person()) { Age = 20 };
            Console.WriteLine($"Age: {responsiblePerson.Age}");
            Console.WriteLine($"Drink: {responsiblePerson.Drink()}");
            Console.WriteLine($"Drive: {responsiblePerson.Drive()}");
            Console.WriteLine($"DrinkAndDrive: {responsiblePerson.DrinkAndDrive()}");
            responsiblePerson.Age = 17;
            Console.WriteLine($"Age: {responsiblePerson.Age}");
            Console.WriteLine($"Drink: {responsiblePerson.Drink()}");
            Console.WriteLine($"Drive: {responsiblePerson.Drive()}");
            Console.WriteLine($"DrinkAndDrive: {responsiblePerson.DrinkAndDrive()}");
            responsiblePerson.Age = 15;
            Console.WriteLine($"Age: {responsiblePerson.Age}");
            Console.WriteLine($"Drink: {responsiblePerson.Drink()}");
            Console.WriteLine($"Drive: {responsiblePerson.Drive()}");
            Console.WriteLine($"DrinkAndDrive: {responsiblePerson.DrinkAndDrive()}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section13_ChainOfResponsibility()
        {
            Console.WriteLine("---");
            var game = new Exercises.Section13_ChainOfResponsibility.Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Console.WriteLine($"GoblinCount:{game.Creatures.Count}");
            foreach (var g in game.Creatures)
            {
                Console.WriteLine(g);
            }
            var goblin2 = new Goblin(game);
            game.Creatures.Add(goblin2);
            Console.WriteLine($"GoblinCount:{game.Creatures.Count}");
            foreach (var g in game.Creatures)
            {
                Console.WriteLine(g);
            }
            var goblin3 = new GoblinKing(game);
            game.Creatures.Add(goblin3);
            Console.WriteLine($"GoblinCount:{game.Creatures.Count}");
            foreach (var g in game.Creatures)
            {
                Console.WriteLine(g);
            }
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section14_Command()
        {
            Console.WriteLine("---");
            var account = new Exercises.Section14_Command.Account();
            var command = new Command { TheAction = Command.Action.Withdraw, Amount = 100 };
            account.Process(command);
            Console.WriteLine(command);
            Console.WriteLine(account);
            command = new Command { TheAction = Command.Action.Deposit, Amount = 100 };
            account.Process(command);
            Console.WriteLine(command);
            Console.WriteLine(account);
            command = new Command { TheAction = Command.Action.Withdraw, Amount = 100 };
            account.Process(command);
            Console.WriteLine(command);
            Console.WriteLine(account);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section15_Interpreter()
        {
            Console.WriteLine("---");
            var processor = new ExpressionProcessor();
            processor.Variables['x'] = 3;
            Console.WriteLine($"1+2+3={processor.Calculate("1+2+3")}");
            Console.WriteLine($"1+2+xy={processor.Calculate("1+2+xy")}");
            Console.WriteLine($"10-2-x={processor.Calculate("10-2-x")}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section16_Iterator()
        {
            Console.WriteLine("---");
            var node = new Node<int>(1, new Node<int>(2), new Node<int>(3)).PreOrder;
            Console.WriteLine(string.Join(", ", node));
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section17_Mediator()
        {
            Console.WriteLine("---");
            var mediator = new Mediator();
            var participant1 = new Participant(mediator);
            var participant2 = new Participant(mediator);
            participant1.Say(3);
            Console.WriteLine($"Participant1 says: {3}");
            Console.WriteLine($"Participant1 {participant1}");
            Console.WriteLine($"Participant2 {participant2}");
            participant2.Say(2);
            Console.WriteLine($"Participant2 says: {2}");
            Console.WriteLine($"Participant1 {participant1}");
            Console.WriteLine($"Participant2 {participant2}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section18_Memento()
        {
            Console.WriteLine("---");
            var tm = new TokenMachine();
            var token = new Token(111);
            tm.AddToken(token);
            var m = tm.AddToken(222);
            token.Value = 333;
            tm.Revert(m);
            Console.WriteLine($"TokenCount: {tm.Tokens.Count}");
            var i = 0;
            Console.WriteLine(string.Join(", ", tm.Tokens.Select(t => $"Token{i++}: {t.Value}")));
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section19_NullObject()
        {
            Console.WriteLine("---");
            try
            {
                var a = new Exercises.Section19_NullObject.Account(new NullLog());
                for (int i = 0; i < 100; ++i)
                    a.SomeOperation();
                Console.WriteLine("No Exception");
            }
            catch { }
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section20_Observer()
        {
            Console.WriteLine("---");
            var game = new Exercises.Section20_Observer.Game();
            var rat = new Rat(game);
            Console.WriteLine($"Rat1 Attack:{rat.Attack}");
            var rat2 = new Rat(game);
            Console.WriteLine($"Rat1 Attack:{rat.Attack}");
            Console.WriteLine($"Rat2 Attack:{rat2.Attack}");
            using (var rat3 = new Rat(game))
            {
                Console.WriteLine($"Rat1 Attack:{rat.Attack}");
                Console.WriteLine($"Rat2 Attack:{rat2.Attack}");
                Console.WriteLine($"Rat3 Attack:{rat3.Attack}");
            }
            Console.WriteLine($"Rat1 Attack:{rat.Attack}");
            Console.WriteLine($"Rat2 Attack:{rat2.Attack}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section21_StateMachine()
        {
            Console.WriteLine("---");
            var combinationLock = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(combinationLock.Status);
            combinationLock.EnterDigit(1);
            Console.WriteLine(combinationLock.Status);
            combinationLock.EnterDigit(2);
            Console.WriteLine(combinationLock.Status);
            combinationLock.EnterDigit(3);
            Console.WriteLine(combinationLock.Status);
            combinationLock.EnterDigit(4);
            Console.WriteLine(combinationLock.Status);
            combinationLock.EnterDigit(5);
            Console.WriteLine(combinationLock.Status);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section22_Strategy()
        {
            Console.WriteLine("---");
            var odStrategy = new OrdinaryDiscriminantStrategy();
            var rdStrategy = new RealDiscriminantStrategy();
            var solver = new QuadraticEquationSolver(odStrategy);
            var results = solver.Solve(1, 10, 16);
            Console.WriteLine($"Results: {results.Item1}, {results.Item2}");
            solver = new QuadraticEquationSolver(rdStrategy);
            results = solver.Solve(1, 10, 16);
            Console.WriteLine($"Results: {results.Item1}, {results.Item2}");
            solver = new QuadraticEquationSolver(odStrategy);
            results = solver.Solve(1, 4, 5);
            Console.WriteLine($"Results: {results.Item1}, {results.Item2}");
            solver = new QuadraticEquationSolver(rdStrategy);
            results = solver.Solve(1, 4, 5);
            Console.WriteLine($"Results: {results.Item1}, {results.Item2}");
            Console.WriteLine("---");
            Console.WriteLine();

        }

        static void Section23_TemplateMethod()
        {
            Console.WriteLine("---");
            var creatures = new[] { new Exercises.Section23_TemplateMethod.Creature(1, 2), new Exercises.Section23_TemplateMethod.Creature(1, 3) };
            var tempGame = new TemporaryCardDamageGame(creatures);
            Console.WriteLine($"TemporaryCardDamageGame:");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            Console.WriteLine($"Combat1 Winner: {tempGame.Combat(0, 1)}");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            Console.WriteLine($"Combat2 Winner: {tempGame.Combat(0, 1)}");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            creatures = new[] { new Exercises.Section23_TemplateMethod.Creature(1, 2), new Exercises.Section23_TemplateMethod.Creature(1, 3) };
            var permGame = new PermanentCardDamage(creatures);
            Console.WriteLine($"PermanentCardDamageGame:");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            Console.WriteLine($"Combat1 Winner: {permGame.Combat(0, 1)}");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            Console.WriteLine($"Combat2 Winner: {permGame.Combat(0, 1)}");
            Console.WriteLine($"Creature0: {creatures[0]}, Creature1: {creatures[1]}");
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section24_Visitor()
        {
            Console.WriteLine("---");
            var expression = new AdditionExpression(new Value(2), new Value(3));
            var visitor = new ExpressionPrinter();
            visitor.Visit(expression);
            Console.WriteLine(visitor);
            var expression2 = new MultiplicationExpression(
                new AdditionExpression(new Value(2), new Value(3)),
                new Value(4));
            visitor = new ExpressionPrinter();
            visitor.Visit(expression2);
            Console.WriteLine(visitor);
            Console.WriteLine("---");
            Console.WriteLine();
        }

        static void Section()
        {
            Console.WriteLine("---");

            Console.WriteLine("---");
            Console.WriteLine();
        }
    }
}
