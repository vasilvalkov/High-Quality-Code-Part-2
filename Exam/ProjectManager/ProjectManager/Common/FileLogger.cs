using Bytes2you.Validation;
using log4net;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private ILog log;

        public FileLogger()
        {
            this.log = LogManager.GetLogger(typeof(FileLogger));
        }

        public FileLogger(ILog logger)
        {
            Guard.WhenArgument(logger, "Logger").IsNull().Throw();
            this.log = logger;
        }

        public void Info(object msg)
        {
            this.log.Info(msg);
        }

        public void Error(object msg)
        {
            this.log.Error(msg);
        }

        public void Fatal(object msg)
        {
            this.log.Fatal(msg);
        }
    }
}
