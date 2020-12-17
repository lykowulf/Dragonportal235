using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dragonportal235.Enum
{
    public enum PortalRole
    {
        Admin,
        [Display(Name ="Head of Household")]
        HOH,
        Member
    }
}
