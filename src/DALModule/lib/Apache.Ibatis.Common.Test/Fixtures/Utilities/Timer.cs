using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace Apache.Ibatis.Common.Test.Fixtures.Utilities
{
    public class Timer
    {
            [DllImport("Kernel32.dll")]
			private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

			[DllImport("Kernel32.dll")]
			private static extern bool QueryPerformanceFrequency(out long lpFrequency);

			private long startTime, stopTime;
			private long freq;

			public Timer()
			{
				startTime = 0;
				stopTime = 0;

				if (QueryPerformanceFrequency(out freq) == false)
				{
					throw new Win32Exception();
				}
			}

			public void Start()
			{
				Thread.Sleep(0);
				QueryPerformanceCounter(out startTime);
			}

			public void Stop()
			{
				QueryPerformanceCounter(out stopTime);
			}

			public double Duration
			{
				get { return (double) (stopTime - startTime)/(double) freq; }
			}
    }
}
