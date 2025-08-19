using NUnit.Framework;
using System;
using Tealium_Csharp;

namespace Tests
{
	[TestFixture()]
	public class TestsLoggerModule
	{

		TestsHelper utils = new TestsHelper();

		[Test()]
		public void TestsPublicCommandsReturn()
		{
			LoggerModule module = new LoggerModule();
			ModuleResponses responses = utils.ModuleReturnsFromAllBaseCalls(module);

			Assert.True(responses.Enabled == true, "Failed to enable.");
			Assert.True(responses.Disabled == true, "Failed to disable.");
			Assert.True(responses.Tracked == true, "Failed to track.");
			Assert.True(responses.Reported == true, "Failed to handle report.");
		}
	}
}
