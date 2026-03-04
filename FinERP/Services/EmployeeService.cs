using FinERP.Data;
using FinERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class EmployeeService
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "EmployeesCache";

    public EmployeeService(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _cache.GetOrCreateAsync(CacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5); 
            var employees = await _context.Employees.ToListAsync();
            return employees;
        });
    }
}