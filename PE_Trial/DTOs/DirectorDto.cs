namespace PE_Trial.DTOs
{
	public class DirectorDto
	{
		public int Id { get; set; }

		public string FullName { get; set; } = null!;

		public string Gender { get; set; }

		public DateTime Dob { get; set; }

		public string DobString { get; set; }

		public string Nationality { get; set; } = null!;

		public string Description { get; set; } = null!;
	}
}
