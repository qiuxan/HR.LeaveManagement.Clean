using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{

    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {

    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(la => la.Id == id);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Where(la => la.EmployeeId == userId)
            .Include(la => la.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations
            .AnyAsync(la => la.EmployeeId == userId
                           && la.LeaveTypeId == leaveTypeId
                           && la.Period == period);
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.LeaveAllocations.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations
            .FirstOrDefaultAsync(la => la.EmployeeId == userId
                                      && la.LeaveTypeId == leaveTypeId);
    }
}