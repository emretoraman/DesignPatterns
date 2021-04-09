using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Exercises.Section02_Builder
{
    public class CodeBuilder
    {
        private readonly string className;
        private readonly List<Field> fields = new List<Field>();

        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            fields.Add(new Field(name, type));
            return this;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"public class {className}");
            stringBuilder.AppendLine("{");
            foreach (var field in fields)
            {
                stringBuilder.AppendLine($"  {field}");
            }
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }
    }

    public class Field
    {
        private readonly string name;
        private readonly string type;

        public Field(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public override string ToString()
        {
            return $"public {type} {name};";
        }
    }
}
