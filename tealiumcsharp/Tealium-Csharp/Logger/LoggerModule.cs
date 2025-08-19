using System;

namespace Tealium_Csharp
{
	/// <summary>
	/// Optional Logger module for debugging.
	/// </summary>
	public class LoggerModule : Module
	{
		public const string Name = "Tealium_Csharp.LoggerModule";

		public LoggerModule()
		{
			this.NameId = Name;
			this.Build = 1;
		}

		public override void HandleReport(Module fromModule, Process process)
		{
			if (process.type == ProcessType.Enable)
			{
                Console.WriteLine("Module: " + fromModule.NameId + " enabled.");
			}
			else if (process.type == ProcessType.Disable)
			{
                Console.WriteLine("Module: " + fromModule.NameId + " disabled.");
			}
			else if (process.type == ProcessType.Track)
			{
				Track track = process.track;
				if (process.successful == true)
				{
                    Console.WriteLine("Module: " + fromModule.NameId + " successfully tracked: " + track);
				}
				else
				{
                    Console.WriteLine("Module: " + fromModule.NameId + " failed to track: " + track);
				}
			}
			this.DidFinishReport(fromModule, process);
		}

	}

}
