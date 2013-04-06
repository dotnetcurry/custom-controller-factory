using MVC40_CustomController.LoggerInfo;
using MVC40_CustomController.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC40_CustomController.Controllers
{
   
    public class EmployeeInfoController : Controller
    {

        DataAccess objDs;

        List<EmployeeInfo> filteredEmps;

        IRequestLogger logger;

        /// <summary>
        /// The Constructor with the Logger parameter. 
        /// </summary>
        /// <param name="log"></param>
        public EmployeeInfoController(IRequestLogger log)
        {
            objDs = new DataAccess();
            logger = log;
        }

        //
        // GET: /EmployeeInfo/
      
        public ActionResult Index()
        {
            LogInfo();
            var Emps = from e in objDs.GetEmps()
                       select e;

            filteredEmps = Emps.ToList();
            return View(filteredEmps);
        }

        /// <summary>
        /// Private method for storing the Loggin information 
        /// </summary>
        private void LogInfo()
        {
            LoggerInformation logInfo = new LoggerInformation();

            logInfo.UserName = this.Request.LogonUserIdentity.Name;
            logInfo.RequestUrl = this.Request.Url.AbsoluteUri;
            logInfo.Browser = this.Request.Browser.Browser;
            logInfo.RequestType = this.Request.RequestType;
            logInfo.UserHostAddress = this.Request.UserHostAddress;
            logger.RecordLog(logInfo);
        }

    }
}
