using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Profiles
{
    public class PlatformProfiles: Profile
    {
        public PlatformProfiles()
        {
            //Source --> Target

            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO,Platform>();
        }
    }
}
