using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class DbPatientRepository : IPatientRepository
    {

        private FysioDbContext _context { get; set; }

        public DbPatientRepository(FysioDbContext fysioContext)
        {
            _context = fysioContext;
        }
        public void Add(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Patients.Count();
        }

        public void Delete(Patient patient)
        {
            _context.Remove(patient);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient ReadByID(int id)
        {
            return _context.Patients.Find(id);
        }
    }
}
