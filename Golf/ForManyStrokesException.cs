using System;

namespace Golf
{
	internal class ForManyStrokesException : Exception
	{
		public ForManyStrokesException(string message) : base(message)
		{ }
	}
}
