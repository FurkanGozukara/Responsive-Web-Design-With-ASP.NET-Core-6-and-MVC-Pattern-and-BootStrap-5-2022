namespace lecture___4.DbModels
{
    public class WebUser : DbModels.TblUser
    {
        public WebUser()
        {

        }
        public WebUser(TblUser myUser)
        {
            this.UserId = myUser.UserId;
            this.LastName = myUser.LastName;
            this.FirstName = myUser.FirstName;
        }
    }
}
