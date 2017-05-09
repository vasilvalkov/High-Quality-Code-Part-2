using Bytes2you.Validation;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using System.Collections.Generic;

namespace ProjectManager.Commands
{
    public abstract class CommandCreator : ICommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;
        
        public CommandCreator(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory").IsNull().Throw();

            this.database = database;
            this.modelsFactory = factory;
        }

        protected IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        protected IModelsFactory ModelsFactory
        {
            get
            {
                return this.modelsFactory;
            }
        }

        public abstract string Execute(IList<string> parameters);
    }
}
