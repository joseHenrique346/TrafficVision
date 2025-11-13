using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrafficVision.Application.Result;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands.User.Create;

internal record class CreateUserCommand(long UserId, string UserName, EnumUserRole UserRole, string UserEmail, string UserPassword) : IRequest<Result<ReportRegistration>>;
