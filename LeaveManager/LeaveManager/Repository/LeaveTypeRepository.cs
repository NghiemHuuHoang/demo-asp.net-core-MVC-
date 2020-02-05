using LeaveManager.Contact;
using LeaveManager.Data;
using LeaveManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Repository
{
    public class LeaveTypeRepository : ILeaveType
    {
        private readonly ApplicationDbContext _db;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
            throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
            throw new NotImplementedException();
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
            throw new NotImplementedException();
        }

        

        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExits(int id)
        {
            var exits = _db.LeaveTypes.Any(q => q.Id == id);
            return exits;
            throw new NotImplementedException();
        }

        public bool Save()
        {

            var save = _db.SaveChanges();
            return save > 0;
            throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
            throw new NotImplementedException();
        }
    }
}
