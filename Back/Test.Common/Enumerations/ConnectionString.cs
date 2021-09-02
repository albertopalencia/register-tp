namespace Test.Common.Enumerations
{

	/// <summary>
	/// Class ConnectionStringEnum.
	/// Implements the <see cref="Test.Common.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="Test.Common.Enumerations.Enumeration" />
	public class ConnectionString : Enumeration
	{
		/// <summary>
		/// The prueba tecnica
		/// </summary>
		private static readonly ConnectionString _connectionString = new (1, "ConnectionStrings:Test");

		/// <summary>
		/// Gets the prueba tecnica.
		/// </summary>
		/// <value>The prueba tecnica.</value>
		public static ConnectionString Test => _connectionString;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionString" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public ConnectionString(int id, string name) : base(id, name)
		{
		}
	}
}