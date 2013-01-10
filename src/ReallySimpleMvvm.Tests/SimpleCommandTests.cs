using System.Windows.Input;
using NUnit.Framework;

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

		[Test]
		public void Execute_CallsTheGivenDelegate_TheGivenDelegateIsCalled()
		{
			var called = false;
			var command = new SimpleCommand(() => { called = true; });

			command.Execute();

			Assert.IsTrue(called);
		}

		[Test]
		public void ICommandExecute_CallsTheGivenDelegate_TheGivenDelegateIsCalled()
		{
			var called = false;
			var command = new SimpleCommand(() => { called = true; });

			((ICommand)command).Execute(null);

			Assert.IsTrue(called);
		}
	}
}
