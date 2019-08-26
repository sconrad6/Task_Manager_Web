using System;
using System.Collections.Generic;

namespace Task_List_Manager.Models
{
    public partial class UserInformation
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserId { get; set; }
    }
}
