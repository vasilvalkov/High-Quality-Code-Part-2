using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Core.Providers.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Core
{
    public class Engine
    {
        internal readonly static IDictionary<int, ITeacher> teachers = new Dictionary<int, ITeacher>();
        internal readonly static IDictionary<int, IStudent> students = new Dictionary<int, IStudent>();
        private readonly IReader Reader;
        private readonly IWriter Writer;
        
        public Engine(IReader reader, IWriter writer)
        {
            if (reader == null || writer == null)
            {
                throw new ArgumentException("Both reader nor writer can be null!");
            }

            this.Reader = reader;
            this.Writer = writer;
        }


        public void Execute()
        {
            while (true)
            {
                try
                {
                    var inputCommand = Reader.ReadLine();
                    if (inputCommand == "End")
                    {
                        break;
                    }

                    var commandName = inputCommand.Split(' ')[0];
                    var assembly = GetType().GetTypeInfo().Assembly;

                    var commandType = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();

                    if (commandType == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var command = Activator.CreateInstance(commandType) as ICommand;
                    var commandParams = inputCommand.Split(' ').ToList();
                    commandParams.RemoveAt(0);

                    Writer.WriteLine(command.Execute(commandParams));
                }
                catch (Exception ex)
                {
                    Writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
