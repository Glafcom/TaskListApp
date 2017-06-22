using Microsoft.Practices.Unity.InterceptionExtension;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace TasklistApp.Web.Behaviors {
    public class LoggingBehavior : IInterceptionBehavior {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<Type> GetRequiredInterfaces() {
            return Type.EmptyTypes;
        }

        public bool WillExecute {
            get { return true; }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {
            var curTime = DateTime.Now;
            var result = getNext().Invoke(input, getNext);
            if (result.Exception != null) {
                logger.Error($"Error {curTime}: {result.Exception.Message}");
            };

            return result;
        }
    }
}