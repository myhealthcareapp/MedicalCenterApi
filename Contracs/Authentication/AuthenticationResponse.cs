﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracs.Authentication
{
    public record AuthenticationResponse(
        string Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
     );

}
