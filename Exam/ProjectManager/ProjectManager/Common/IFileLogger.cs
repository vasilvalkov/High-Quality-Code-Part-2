namespace ProjectManager.Common
{
    public interface IFileLogger
    {
        void Error(object msg);

        void Fatal(object msg);

        void Info(object msg);
    }
}