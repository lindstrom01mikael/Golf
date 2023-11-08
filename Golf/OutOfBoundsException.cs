using System;

namespace Golf
{
	internal class OutOfBoundsException : Exception
	{
		public OutOfBoundsException(string message) : base(message)
		{ }
	}
}
