﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vino.Core.CMS.Core.Common;

namespace Vino.Core.CMS.Data.Entity.System
{
    [Table("system_role_menu")]
    public class RoleMenu
    {
        public long RoleId { set; get; }
        public virtual Role Role { set; get; }

        public long MenuId { set; get; }
        public virtual Menu Menu { set; get; }
    }
}