 
using System.Text.Json;

namespace Test.Domain.DTO
{
	/// <summary>
	/// Class MessageError.
	/// </summary>
	public class MessageErrorDto
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }
		/// <summary>
		/// Gets or sets the property.
		/// </summary>
		/// <value>The property.</value>
		public string Property { get; set; }

		public override string ToString()
		{
			return JsonSerializer.Serialize(this);

		}
	}
}