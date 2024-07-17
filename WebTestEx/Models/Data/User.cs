using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class User
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? AddDate { get; set; }
        public byte? Status { get; set; }
        public int? PermissionsId { get; set; }

        public virtual Permission? Permissions { get; set; }
    }
}
