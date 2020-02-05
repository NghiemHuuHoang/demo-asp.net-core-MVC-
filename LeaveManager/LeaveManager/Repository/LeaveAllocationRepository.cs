using LeaveManager.Contact;
using LeaveManager.Data;
using LeaveManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocation
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.LeaveTypeId == leaveTypeId && q.EmployeeId == employeeId && q.Period == period).Any();
            throw new NotImplementedException();
        }

        public bool Create(LeaveAllocation entity)
        {
             _db.leaveAllocations.Add(entity);
            return Save();
            throw new NotImplementedException();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.leaveAllocations.Remove(entity);
            return Save();
            throw new NotImplementedException();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocation = _db.leaveAllocations.ToList();
            return leaveAllocation;
            throw new NotImplementedException();
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _db.leaveAllocations.Find(id);
            return leaveAllocation;
            throw new NotImplementedException();
        }

        public bool IsExits(int id)
        {

            var exits = _db.leaveAllocations.Any(m => m.Id == id);
            return exits;
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var save=_db.SaveChanges();
            return save > 0;
            throw new NotImplementedException();
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.leaveAllocations.Update(entity);
            return Save();
            throw new NotImplementedException();
        }
    }
}
