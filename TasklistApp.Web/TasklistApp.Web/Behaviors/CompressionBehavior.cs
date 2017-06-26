using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasklistApp.Web.Behaviors {
    public class CompressionBehavior : IInterceptionBehavior {
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