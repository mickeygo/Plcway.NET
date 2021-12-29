using System;
using Microsoft.Extensions.DiagnosticAdapter;

namespace Plcway.Framework.Tracing
{
    internal class DefaultDiagnosticListener
    {
        [DiagnosticName("Host.MiddlewareStarting")]
        public virtual void OnMiddlewareStarting()
        {
            
        }
    }
}
