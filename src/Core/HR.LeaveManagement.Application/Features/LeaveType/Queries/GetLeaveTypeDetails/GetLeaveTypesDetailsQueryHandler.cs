using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypesDetailsQueryHandler: IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypesDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the database
        var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //convert the data objects to Dtos using AutoMapper
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);
        return data;
    }
}