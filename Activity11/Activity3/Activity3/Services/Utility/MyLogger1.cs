using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3.Services.Utility
{
    public sealed class MyLogger1 : ILogger
    {
        //creates an instance of our custom logger
        public static MyLogger1 instance = new MyLogger1();
        //will only initialize once and if needed
        Lazy<MyLogger1> Instance = new Lazy<MyLogger1>();

        private Lazy<Logger> log = new Lazy<Logger>();

        private Logger logg = LogManager.GetLogger("Example");
        //constructor
        private MyLogger1() { }

        //method to get instance of mylogger
        public static MyLogger1 GetInstance()
        {
            
                return instance;
              
            
        }

       
        //the following methods are the implementation of the ILogger interface
        public void Debug(string message)
        {
            logg.Debug(message);
            //throw new NotImplementedException();
        }
        
        public void Info(string message, string v)
        {
            logg.Info(message, v);
            //throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            logg.Warn(message);
            //throw new NotImplementedException();
        }

        public void Info(string v)
        {
            logg.Info(v);
            ///throw new NotImplementedException();
        }

        public void Error(string message, string error)
        {
            logg.Error(message, error);
            //throw new NotImplementedException();
        }
    }
}



        
            
        

    

