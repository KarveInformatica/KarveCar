using System.Diagnostics;

namespace KarveCar
{
    internal class DebugTraceListener : TraceListener
    {
        public DebugTraceListener()
        {
        }

        public override void Write(string message)
        {
          
            throw new System.NotImplementedException();
        }

        public override void WriteLine(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}