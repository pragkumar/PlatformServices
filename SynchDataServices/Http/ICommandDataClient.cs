using PlatformService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.SynchDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO plat);
    }
}
