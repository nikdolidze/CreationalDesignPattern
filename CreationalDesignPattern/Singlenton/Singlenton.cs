using System;
/*
 The intent of singlenton patern is to ensure that a class only has one instance and to provide a global point of acces to it.
static property ensures that when multiple instances of the logger class exist there still will be only one instance of the instance property.
Lazy initialization is the principle that states that we are only going to crate an instance of a class once we need it and not when it's constructed;
 */
namespace Singlenton
{
    public class logger
    {
        private static readonly Lazy<logger> _lazyLogger 
                = new Lazy<logger>(() => new logger());

      //  private static logger _instance;

        private logger() { }

        public static logger Instance
        {
            get
            { 
                return _lazyLogger.Value;
                //if (_instance == null)
                //    _instance = new logger();
                //return _instance;
            }
        }
        public void Log(string message)
        {
            Console.WriteLine($"Message to log : {message}");
        }
    }


}
