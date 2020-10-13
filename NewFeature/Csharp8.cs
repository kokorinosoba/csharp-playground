using System;

namespace NewFeature
{
    public class Csharp8
    {

#nullable enable
        // Nullable reference types
        public static void Nullable()
        {
            string NonNullable = null; // Warning
            NonNullable = "NonNullable";
            Console.WriteLine($"string: {NonNullable}.");

            string? nullable = null;
            nullable = "Nullable";
            Console.WriteLine($"string: {nullable}.");
        }
#nullable disable

        public static void RecursivePattern()
        {
            // C# 1.0 "is"
            if (new Foo() is object)
                Console.WriteLine($"new Foo() is object: {new Foo()}");

            // C# 7.0 "is" pattern matching
            if (new Foo() is object bar)
                Console.WriteLine($"new Foo() is object bar: {bar}");

            Foo foo = null;
            if (foo is null)
                Console.WriteLine("foo is null");

            // Recursive pattern
            if (new Foo(3, 4) is Foo(3, 4) baz)
                Console.WriteLine($"new Foo() is Foo(3, 4) baz: {baz.D2}");

            if (new Foo(3, 4) is Foo { D2: 25 })
                Console.WriteLine($"new Foo(3, 4) is Foo {{ D2: 25 }}");

            if (new Foo(3, 4) is (3, _))
                Console.WriteLine($"new Foo(3, 4) is (3, _)");

            if (new Foo(3, 4) is { D2: int d2 })
                Console.WriteLine($"new Foo(3, 4) is {{ D2: int {d2} }}");

            if (new Foo(3, 4) is (4, 3) { D2: 25 })
                Console.WriteLine($"new Foo(3, 4) is (4, 3) {{ D2: 25 }}");
        }

        public static string SwitchExpression(int num) => num switch
        {
            1 => "One",
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            int n when n >= 6 => "Over 5",
            _ => "Others"
        };

        public static void RangeAccess()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };
            // Not working
            // var rangeArr = arr[2..];
        }
    }

    public class Foo
    {
        public int X;
        public int Y;
        public int D2 { get => X * X + Y * Y; }
        public Foo() => (X, Y) = (0, 0);
        public Foo(int x, int y) => (X, Y) = (x, y);
        public void Deconstruct(out long x, out long y) => (x, y) = (X, Y);
        public override string ToString()
        {
            return "This is Foo class object";
        }
    }
}
