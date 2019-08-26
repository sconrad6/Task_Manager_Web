using System;
using System.Collections.Generic;

namespace Task_List_Manager.Models
{
    public partial class Task
    {
        public int UserId { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool TaskStatus { get; set; }
    }
}
