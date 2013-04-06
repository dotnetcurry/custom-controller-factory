using MVC40_CustomController.Models;

namespace MVC40_CustomController.LoggerInfo
{
    /// <summary>
    /// Interface for the Logging
    /// </summary>
    public interface IRequestLogger
    {
        void RecordLog(LoggerInformation logInfo);
    }
    /// <summary>
    /// The class for Loggin the Request Information into the database usign ADO.NET EF
    /// </summary>
    public class RequestLogger : IRequestLogger
    {
        CompanyEntities objContext;
        public RequestLogger()
        {
            objContext = new CompanyEntities(); 
        }

        public void RecordLog(LoggerInformation logInfo)
        {
            objContext.AddToLoggerInformations(logInfo);
            objContext.SaveChanges();
        }
    }

}