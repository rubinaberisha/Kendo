using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Data;
using Kendo.Models;
using Kendo.Data;
using Kendo.Models;
using Microsoft.EntityFrameworkCore;

namespace Kendo.Services
{
    public class EmployeeDirectoryService : IDisposable
    {
        private readonly AppDbContext _context;

        public EmployeeDirectoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeDirectoryModel> GetAll()
        {
            return _context.EmployeeDirectories.ToList();
        }

        public void Insert(EmployeeDirectoryModel employee)
        {
            _context.EmployeeDirectories.Add(employee);
            _context.SaveChanges();
        }

        public void Update(EmployeeDirectoryModel employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(EmployeeDirectoryModel employee)
        {
            var entity = _context.EmployeeDirectories.Find(employee.EmployeeId);
            if (entity != null)
            {
                _context.EmployeeDirectories.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
