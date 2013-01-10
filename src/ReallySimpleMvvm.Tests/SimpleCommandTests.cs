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
		public void CanExecute_WhenNoCanExecuteDelegateIsPassed_CanExecuteShouldReturnTrue()
		{
			var command = new SimpleCommand(() => { });

			var result = command.CanExecute();

			Assert.IsTrue(result,"CanExecute should always return true when no delgate is given.");
		}

		[Test]
		public void CanExecute_WhenACanExecuteDelegateIsPassedThatEvaluatesToFalse_CanExecuteShouldReturnFalse()
		{
			var command = new SimpleCommand(() => { }, () => false);

			var result = command.CanExecute();

			Assert.IsFalse(result, "CanExecute should return false as there is a delegate and it returns false");
		}
	}
}
