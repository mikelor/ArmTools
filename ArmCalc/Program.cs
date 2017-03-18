using System;
using Microsoft.Extensions.CommandLineUtils;


namespace ArmCalc
{
    class Program
    {
        static int Main(string[] args)
        {
            // Define app which is required for CLI
            var app = new CommandLineApplication
            {
                Name = "ArmCalc",
                Description = "Calculates the cost of an Azure Resource Manager Template",
                FullName = "ArmCalc"
            };

       
            app.HelpOption("-?|-h|--help");

            // Register Options
            var name = app.Option("--name|-n", "This is the parameter 'name'. You can use --name or the shortcut -n", CommandOptionType.SingleValue);
            var options = app.Option("--options|-o", "This is the parameter 'option'. You can pass multiple values", CommandOptionType.MultipleValue);
            var force = app.Option("--force", "This is the parameter 'firce' without any other shurtcut or value. ", CommandOptionType.NoValue);


            // define what happens on Execute
            app.OnExecute(() =>
            {
                app.ShowHelp();

                // Output
                if (name.HasValue())
                {
                    Console.WriteLine($"The parameter 'name' was used and the passed value is: '{name.Value()}'");
                }
                else
                {
                    Console.WriteLine($"The parameter 'name' was not used.");
                }

                if (options.HasValue())
                {
                    Console.WriteLine($"The parameter 'option' was used and has {options.Values.Count} values:");
                    foreach (var opt in options.Values)
                    {
                        Console.WriteLine($" > {opt}'");
                    }
                }
                else
                {
                    Console.WriteLine($"The parameter 'options' was not used.");
                }


                if (force.HasValue())
                {
                    Console.WriteLine($"The parameter 'force' was used.");
                }
                else
                {
                    Console.WriteLine($"The parameter 'force' was not used.");
                }

                // give a return code
                // if anything is wrong return -1!
                return 0;
            });


            // run defined app
            int returnCode = app.Execute(args);

            Console.ReadKey();

            return returnCode;
        }
    }
}