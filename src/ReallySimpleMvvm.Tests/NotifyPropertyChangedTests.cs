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
		public void RaisePropertyChangedEvent_PropertyNameInPropertyChangedEventArgs_ShouldBeTheSameAsParameter()
		{
			
			var test = new TestNotify();
			var equal = false;
			test.PropertyChanged += (sender, e) => { equal = (e.PropertyName == PropertyName); };
			
			test.RaisesPropertyChanged(PropertyName);

			Assert.IsTrue(equal);
		}

		[Test]
		public void RaisePropertyChangedEvent_PropertyNameInPropertyChangedEventArgs_ShouldBeTheSameAsProperty()
		{

			var test = new TestNotify();
			var equal = false;
			test.PropertyChanged += (sender, e) => { equal = (e.PropertyName == PropertyName); };

			test.RaisesPropertyChanged();

			Assert.IsTrue(equal);
		}

		[Test]
		public void RaisePropertyChangedEvent_RaiseEvent_ShouldRaiseEvent()
		{

			var test = new TestNotify();
			var raised = false;
			test.PropertyChanged += (sender, e) => { raised = true; };

			test.RaisesPropertyChanged();

			Assert.IsTrue(raised);
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
