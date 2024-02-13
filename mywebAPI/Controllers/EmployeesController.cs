﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mywebAPI.Data;
using mywebAPI.models;

namespace mywebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly WebDbContext _db;
        public EmployeesController(WebDbContext webDbContext)
        {
            _db=webDbContext;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           var employees = await _db.Employees.ToListAsync();
            
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.ID = Guid.NewGuid();
            await _db.Employees.AddAsync(employeeRequest);
            await _db.SaveChangesAsync();

            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
           var employee = await _db.Employees.FirstOrDefaultAsync(x => x.ID == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid
             id, Employee updateEmployeeRequest)
        {
           var employee= await _db.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;

            await _db.SaveChangesAsync();

            return Ok(employee);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _db.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
