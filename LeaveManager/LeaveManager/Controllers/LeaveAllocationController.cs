using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManager.Contact;
using LeaveManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManager.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveType _repo;
        private readonly ILeaveAllocation _leaveAllocation;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public LeaveAllocationController(ILeaveType repo,ILeaveAllocation leaveAllocation,IMapper mapper,UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _leaveAllocation = leaveAllocation;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: LeaveAllocation
        public ActionResult Index()
        {
            var leaveTypes = _repo.FindAll().ToList();
            var mapperLeaveType = _mapper.Map<List<LeaveType>,List<LeaveTypeVM>>(leaveTypes);
            var models = new CreateLeaveAllocation()
            {
                LeaveTypeVMs = mapperLeaveType,
                NumberUpdated = 0
            };
            return View(models);
        }

        public ActionResult SetLeave(int id)
        {
            var leave = _repo.FindById(id);
            var employee = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var emp in employee) 
            {
                if (_leaveAllocation.CheckAllocation(id, emp.Id))
                    continue;
                var allocation = new LeaveAllocationVM()
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDay = leave.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var allocationMapper =_mapper.Map<LeaveAllocation>(allocation);
                _leaveAllocation.Create(allocationMapper);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        // GET: LeaveAllocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveAllocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveAllocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}