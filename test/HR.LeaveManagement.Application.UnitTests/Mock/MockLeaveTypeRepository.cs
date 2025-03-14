using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mock;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
    {
        var mockLeaveTypes = new List<LeaveType>
        {
            new LeaveType { Id = 1, Name = "Test Annual Leave", DefaultDays = 10 },
            new LeaveType { Id = 2, Name = "Test Sick Leave", DefaultDays = 10 },
            new LeaveType { Id = 3, Name = "Test Maternity Leave", DefaultDays = 10 },
            new LeaveType { Id = 4, Name = "Test Paternity Leave", DefaultDays = 10 },
            new LeaveType { Id = 5, Name = "Test Unpaid Leave", DefaultDays = 10 }
        };
        var mockLeaveTypeRepository = new Mock<ILeaveTypeRepository>();
        mockLeaveTypeRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(mockLeaveTypes);

        mockLeaveTypeRepository.Setup(repo => repo.CreateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType mockLeaveTypeToAdd) =>
            {
                mockLeaveTypes.Add(mockLeaveTypeToAdd);
                return Task.CompletedTask;
            });


        return mockLeaveTypeRepository;
    }
}