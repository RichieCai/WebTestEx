using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class Menu
    {
        public Menu()
        {
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public byte? Status { get; set; }
        /// <summary>
        /// 選單類型
        /// </summary>
        public int? MenuType { get; set; }
        public string? PermissionsId { get; set; }
        public string? CustomizedUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }

        public virtual ICollection<MenuPermission> MenuPermissions { get; set; }
    }
}
