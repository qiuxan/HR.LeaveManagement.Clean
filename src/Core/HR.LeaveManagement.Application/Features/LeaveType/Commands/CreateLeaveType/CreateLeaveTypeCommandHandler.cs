using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private static ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validation inComing request :TODO


            // convert the request to a LeaveType object

            var leaveType = _mapper.Map<LeaveManagment.Domain.LeaveType>(request);
            // save the LeaveType object to the database

            leaveType = await _leaveTypeRepository.CreateAsync(leaveType);

            //return the id of the newly created LeaveType

            return leaveType.Id;
        }
    }
}
