namespace Test.Infrastructure.Interfaces
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface IRemoveRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRemoveRepository<in T> where T : class
	{
		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Remove(T t);

		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Remove(IEnumerable<T> t);
	}
}