namespace Test.Infrastructure.Interfaces
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface IUpdateRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IUpdateRepository<in T> where T : class
	{
		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(T t);

		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(IEnumerable<T> t);
	}
}