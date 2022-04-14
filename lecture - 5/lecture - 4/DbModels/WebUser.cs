using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace lecture___4.DbModels
{
    public class WebUser : DbModels.TblUser
    {
        public string srSerializedModelState { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to enter your first name")]
        [StringLength(25,MinimumLength = 3, ErrorMessage = "Please enter your first name with at least 3 characters up to 25 characters")]
        [Display(Name = "First Name")]
        new public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a value for the Last Name field!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Last Name must be between 3 and 50 characters long!")]
        [Display(Name = "Last Name")]
        new public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter a value for the Mail Address field!")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address!")]
        [Display(Name = "Email")]
        new public string MailAddress { get; set; }

        public WebUser()
        {

        }
        public WebUser(TblUser myUser)
        {
            this.UserId = myUser.UserId;
            this.LastName = myUser.LastName;
            this.FirstName = myUser.FirstName;
        }

        public void setDBVAlues()
        {
            base.FirstName = this.FirstName;
            base.LastName = this.LastName;
            
        }
    }
}
