using System;
using System.Collections.Generic;

namespace lecture___4.DbModels
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
