using Microsoft.AspNetCore.Identity;

namespace MULTI.Areas.Identity.Data
{
	public class ApplicationUser : IdentityUser
	{
		[PersonalData]
		public int DepartamentID { get; set; }
		[PersonalData]
		public string FirstName { get; set; }
		
		[PersonalData]
		public string LastName { get; set; }
	}
}
