using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace Generate
{
    public class GeneratePoem
    {
        public static string Generate(int number)
        {
            ScriptEngine engine = Python.CreateEngine();

            string script = @"..\Generate\PythonCode\markov.py";

            var libs = new[] {
                @"C:\Program Files\IronPython 2.7\Lib",
                @"C:\Program Files\IronPython 2.7\DLLs"
            };

            engine.SetSearchPaths(libs);

            dynamic source = engine.ExecuteFile(script);

            string result = source.execute(number);

            return result;

        }
    }
}
