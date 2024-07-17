using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class MenuPermission
    {
        public int MenuPermissionsId { get; set; }
        public int? MenuId { get; set; }
        /// <summary>
        /// 權限類型(1:for Premissions,2:for UserId)
        /// </summary>
        public byte? MenuPermissionsType { get; set; }
        public int? PermissionsId { get; set; }
        public string? UserId { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
