using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ReallySimpleMvvm;

namespace ReallySimpleMvvm.Tests
{
	[TestFixture]
	public class NotifyPropertyChangedTests
	{
		private const string PropertyName = "Name";

		[Test]
		public void PropertyNameInPropertyChangedEventArgs_ShouldBeTheSameAsParameter()
		{
			
			var test = new TestNotify();
			bool equal = false;
			test.PropertyChanged += (sender, e) => { equal = (e.PropertyName == PropertyName); };
			
			test.RaisesPropertyChanged(PropertyName);

			Assert.IsTrue(equal);
		}

		[Test]
		public void PropertyNameInPropertyChangedEventArgs_ShouldBeTheSameAsProperty()
		{

			var test = new TestNotify();
			bool equal = false;
			test.PropertyChanged += (sender, e) => { equal = (e.PropertyName == PropertyName); };

			test.RaisesPropertyChanged();

			Assert.IsTrue(equal);
		}

		

		private class TestNotify : NotifyPropertyChanged
		{
			public void RaisesPropertyChanged(string name)
			{
				RaisePropertyChangedEvent(name);
			}

			public void RaisesPropertyChanged()
			{
				RaisePropertyChangedEvent(() => Name);
			}

			public string Name { get; set; }
		}
	}
}
