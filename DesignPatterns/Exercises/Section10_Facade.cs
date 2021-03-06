using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Exercises.Section10_Facade
{
    public class Generator
    {
        private static readonly Random random = new Random();

        public List<int> Generate(int count)
        {
            _ = GetType();
            return Enumerable.Range(0, count)
              .Select(_ => random.Next(1, 6))
              .ToList();
        }
    }

    public class Splitter
    {
        public List<List<int>> Split(List<List<int>> array)
        {
            _ = GetType();
            var result = new List<List<int>>();

            var rowCount = array.Count;
            var colCount = array[0].Count;

            // get the rows
            for (int r = 0; r < rowCount; ++r)
            {
                var theRow = new List<int>();
                for (int c = 0; c < colCount; ++c)
                    theRow.Add(array[r][c]);
                result.Add(theRow);
            }

            // get the columns
            for (int c = 0; c < colCount; ++c)
            {
                var theCol = new List<int>();
                for (int r = 0; r < rowCount; ++r)
                    theCol.Add(array[r][c]);
                result.Add(theCol);
            }

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            for (int c = 0; c < colCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (c == r)
                        diag1.Add(array[r][c]);
                    var r2 = rowCount - r - 1;
                    if (c == r2)
                        diag2.Add(array[r][c]);
                }
            }

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }
    }

    public class Verifier
    {
        public bool Verify(List<List<int>> array)
        {
            _ = GetType();
            if (!array.Any()) return false;

            var expected = array.First().Sum();

            return array.All(t => t.Sum() == expected);
        }
    }

    public class MagicSquareGenerator
    {
        public List<List<int>> Generate(int size)
        {
            _ = GetType();
            var generator = new Generator();
            var splitter = new Splitter();
            var verifier = new Verifier();

            var result = new List<List<int>>();
            do
            {
                result.Clear();
                for (var i = 0; i < size; i++)
                {
                    var newRow = generator.Generate(size);
                    if (i > 0)
                    {
                        while (!verifier.Verify(new List<List<int>> { result[0], newRow }))
                        {
                            newRow = generator.Generate(size);
                        }
                    }
                    result.Add(newRow);
                }
            }
            while (!verifier.Verify(splitter.Split(result)));

            return result;
        }
    }
}
