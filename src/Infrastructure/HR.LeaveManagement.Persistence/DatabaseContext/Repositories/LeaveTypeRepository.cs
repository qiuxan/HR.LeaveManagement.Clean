using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{

    public LeaveTypeRepository(HrDatabaseContext context) : base(context)
    {
          
    }

    public async Task<bool> IsLeaveTypeUnique(string leaveTypeName)
    {
        return await _context.LeaveTypes.AnyAsync(lt => lt.Name == leaveTypeName) is false;
    }
}