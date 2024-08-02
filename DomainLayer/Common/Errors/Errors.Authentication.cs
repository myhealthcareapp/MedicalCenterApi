using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCredentails",
                description: "Invaid credentials"
               );

            public static Error DuplicateEmal => Error.Conflict(code: "User.DuplicateEmail",
               description: "Email already in use.");
        }
    }
}
