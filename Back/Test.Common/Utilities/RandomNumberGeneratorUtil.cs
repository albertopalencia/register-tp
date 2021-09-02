using System;

namespace Test.Common.Utilities
{
	public class RandomNumberGeneratorUtil
	{
		public static int Create()
		{
			var random = new Random();
			return random.Next(1, 100000000);
		}
	}
}