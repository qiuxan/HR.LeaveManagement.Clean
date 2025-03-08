using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{

    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {

    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(l => l.LeaveType)
            .FirstOrDefaultAsync(l => l.Id == id);
        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests // _context is a protected field in the GenericRepository class, so it is accessible here
            .Include(l => l.LeaveType)
            .ToListAsync();
        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestByEmployeeId(string userId)
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(l => l.LeaveType)
            .Where(l => l.RequestingEmployeeId == userId) 
            .ToListAsync();
        return leaveRequests;
    }
}