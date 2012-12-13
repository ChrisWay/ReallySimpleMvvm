using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReallySimpleMvvm.Pcl
{
	public abstract class NotifyPropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChangedEvent(string propertyName)
		{
			
		}
	}
}
