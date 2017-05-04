using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Core.Providers.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchoolSystem.Core
{
    public class Engine
    {
        internal readonly static IDictionary<int, ITeacher> Teachers = new Dictionary<int, ITeacher>();
        internal readonly static IDictionary<int, IStudent> Students = new Dictionary<int, IStudent>();
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

        public void Ignite()
        {
            StringBuilder resultBuilder = new StringBuilder();

            while (true)
            {
                try
                {
                    var inputCommand = Reader.ReadLine();
                    if (inputCommand == "End")
                    {
                        Writer.WriteLine(resultBuilder.ToString());
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

                    string commandResult = command.Execute(commandParams);

                    resultBuilder.AppendLine(commandResult);
                }
                catch (Exception ex)
                {
                    Writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
