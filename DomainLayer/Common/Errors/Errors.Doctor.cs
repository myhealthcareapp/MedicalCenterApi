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
        public static class Doctor
        {
            public static Error DoctorDoesNotExist => Error.NotFound(code: "Doctor.NotFound",
                 description: "The doctor with the provided ID does not exist in the database.");
        }
    }
}
