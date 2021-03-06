﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fabric.Identity.API.Services.PrincipalQuery
{
    public interface IPrincipalQuery
    {
        string QueryText(string searchText, FabricIdentityEnums.PrincipalType principalType);
    }
}
