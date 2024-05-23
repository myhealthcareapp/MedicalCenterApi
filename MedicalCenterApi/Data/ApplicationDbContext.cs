using MedicalCenterApi.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenterApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }
        
    }
}
