using MVC40_CustomController.LoggerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Xml.Linq;

namespace MVC40_CustomController.CustomControllerFactoryRepository
{
    /// <summary>
    /// The Custom Controller Factory class. 
    /// 
    /// </summary>
    public class CCustomControllerFactory : IControllerFactory
    {
        /// <summary>
        /// The method to create the controller object from the requested routing information
        /// This methods loads the xml file where the Controller information 
        /// with its full qualify path stored. The XLinq is used to load the xml file. 
        /// The xml file is queried using xlinq based upon the controllerName.
        /// The information received from the cml file is stored into the Dictionary<string,string> object.
        /// From this dictionary object the controller object is created and using the Activator object 
        /// the controller instance is created to whcih the Logger object is passed.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
             IController controllerType = null;
            Type typeData = null;

            XDocument xdoc = XDocument.Load(HostingEnvironment.MapPath(@"~/Controllers.xml"));
            var controllerData =( from controller in xdoc.Descendants("ControllerName")
                                 select new ControllerInfo()
                                 {
                                      ControllerKey = controller.Descendants("Class").First().Value,
                                      ControllerPath = controller.Descendants("FullPath").First().Value
                                 }).ToList();

            Dictionary<string, string> controllersDictionary = new Dictionary<string, string>();

            foreach (var item in controllerData)
            {
                controllersDictionary.Add(item.ControllerKey, item.ControllerPath);
            }
            string controllerTypeName = null;

            if (controllersDictionary.TryGetValue(controllerName, out controllerTypeName))
            {
                typeData = Type.GetType(controllerTypeName);
            }

            IRequestLogger logger = new RequestLogger();

            controllerType = (IController)Activator.CreateInstance(typeData, logger);
            
            
            return controllerType;
        }
        /// <summary>
        /// The default session state
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        /// <summary>
        /// Release the controller
        /// </summary>
        /// <param name="controller"></param>
        public void ReleaseController(IController controller)
        {
            IDisposable release = controller as IDisposable;
            release.Dispose();
        }
    }
    /// <summary>
    /// The Class for Controller Information
    /// </summary>
    public class ControllerInfo
    {
        public string ControllerKey { get; set; }
        public string ControllerPath { get; set; }
    }
}