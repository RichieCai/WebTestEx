using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class ToDoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? AddMid { get; set; }
        public string? UpdateUid { get; set; }
        public byte? Iscomplete { get; set; }
    }
}
