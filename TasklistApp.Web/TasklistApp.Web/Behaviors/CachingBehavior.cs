using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasklistApp.Web.Behaviors {
    public class CachingBehavior : IInterceptionBehavior {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {

        }

        //Проверяем на кэшируемость
        private bool IsInCach(string key) {
            return true;
        }

        private 

    }
}