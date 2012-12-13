using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallySimpleMvvm.Tests
{
	[TestFixture]
	public class SimpleCommandTests
	{
		[Test]
		public void WhenNoCanExecuteDelegateIsPassedCanExecute_ShouldReturnTrue()
		{
			var command = new SimpleCommand(() => { });

			var result = command.CanExecute();

			Assert.IsTrue(result,"Can Execute should always return true when no delgate is given.");
		}
	}
}
