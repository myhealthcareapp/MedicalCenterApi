using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDoctorsRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetDoctorById(int id);
        Task<int> Create(Doctor doctor);
        Task<bool> Delete(Doctor doctor);
    }
}
