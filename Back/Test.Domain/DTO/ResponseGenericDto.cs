namespace Test.Domain.DTO
{
	/// <summary>
	/// Class ResponseGeneric.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ResponseGenericDto<T>
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ResponseGenericDto{T}"/> is success.
		/// </summary>
		/// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; } = string.Empty;
		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>The result.</value>
		public T Result { get; set; }
	}
}