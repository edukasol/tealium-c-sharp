using NUnit.Framework;
using System;
using Tealium_Csharp;

namespace Tests
{
	[TestFixture()]
	public class TestsAppDataModule
	{
		TestsHelper utils = new TestsHelper();
		AppDataModule module = new AppDataModule();

		[Test()]
		public void TestsPublicCommandsReturn()
		{

			ModuleResponses responses = utils.ModuleReturnsFromAllBaseCalls(module);

			Assert.True(responses.Enabled, "Failed to enable.");
			Assert.True(responses.Disabled, "Failed to disable.");
			Assert.True(responses.Tracked, "Failed to track.");
			Assert.True(responses.Reported, "Failed to handle report.");
		}

		[Test()]
		public void TestsPublicCommandsRespectNonEnabledState()
		{

			ModuleResponses responses = utils.ModuleReturnsFromAllBaseCallsFromANonEnabledState(module);

			Assert.False(responses.Enabled, "Unexpectedly enabled.");
			Assert.False(responses.Disabled, "Unexpectedly disabled.");
			Assert.True(responses.Tracked, "Unexpectedly tracked call.");
			Assert.True(responses.Reported, "Unexpectededly handled report.");
		}

		[Test()]
		public void TestsPublicCommandsRespectDisableCommand()
		{

			ModuleResponses responses = utils.ModuleReturnsFromAllBaseCallsAfterDisable(module);

			Assert.True(responses.Enabled, "Enabled not called.");
			Assert.True(responses.Disabled, "Disabled not called.");
			Assert.True(responses.Tracked, "Unexpectedly tracked call.");
			Assert.True(responses.Reported, "Unexpectededly handled report.");

		}
	}
}
