using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ReallySimpleMvvm.Pcl
{
	public abstract class NotifyPropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChangedEvent(string propertyName)
		{
			var handler = PropertyChanged;
			if(handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void RaisePropertyChangedEvent<T>(Expression<Func<T>> property)
		{
			RaisePropertyChangedEvent(PropertyNameHelper.GetPropertyName(property));
		}
	}

	/// <summary>
	/// Source: http://keith-woods.com/Blog/post/Strongly-Typed-INotifyPropertyChanged-Event-Raisers.aspx
	/// </summary>
	internal class PropertyNameHelper
	{
		public static string GetPropertyName<T>(Expression<Func<T>> expression)
		{
			return GetPropertyNameFromLambda(expression);
		}

		public static string GetPropertyName<T>(Expression<Func<T, Object>> expression)
		{
			return GetPropertyNameFromLambda(expression);
		}

		private static string GetPropertyNameFromLambda(LambdaExpression lambda)
		{
			MemberExpression memberExpression = null;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = lambda.Body as UnaryExpression;
				if (unaryExpression != null) 
					memberExpression = unaryExpression.Operand as MemberExpression;
			}
			else
				memberExpression = lambda.Body as MemberExpression;

			if (memberExpression == null)
				throw new ArgumentException(String.Format("Property expression '{0}' did not provide a property name.", lambda));

			return memberExpression.Member.Name;
		}
	}
}
