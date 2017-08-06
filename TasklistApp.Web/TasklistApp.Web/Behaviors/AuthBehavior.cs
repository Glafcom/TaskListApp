using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasklistApp.Web.Behaviors {
    /*public class AuthBehavior : IInterceptionBehavior {
        public IEnumerable<Type> GetRequiredInterfaces() {
            return Type.EmptyTypes;
        }

        public bool WillExecute {
            get { return true; }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {

            if (input.MethodBase .Name == "GetTenant") {
                var tenantName = input.Arguments["tenant"].ToString();
                if (IsInCache(tenantName)) {
                    return input.CreateMethodReturn(
                      FetchFromCache(tenantName));
                }
            }

            var result = getNext().Invoke(input, getNext);
            
            return result;
        }
    }*/
}