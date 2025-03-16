using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mock;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypeListQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveTypesQueryHandler> _mockAppLogger;

    public GetLeaveTypeListQueryHandlerTests()
    {
        _mockLeaveTypeRepository = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>().Object;
    }
    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypesQueryHandler(_mapper, _mockLeaveTypeRepository.Object, _mockAppLogger );
        var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(5);
    }
}