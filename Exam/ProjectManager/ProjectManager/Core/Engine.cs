using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers.Contracts;
using System;
using System.Text;

namespace ProjectManager
{
    public class Engine
    {
        private IFileLogger logger;
        private ICommandProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IFileLogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine reader provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine writer provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            StringBuilder resultBuilder = new StringBuilder();

            while (true)
            {
                string inputCommand = this.reader.ReadLine();

                if (inputCommand.ToLower() == "exit")
                {
                    resultBuilder.AppendLine("Program terminated.");
                    this.writer.WriteLine(resultBuilder.ToString());
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(inputCommand);

                    resultBuilder.AppendLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
