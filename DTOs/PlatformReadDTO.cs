﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.DTOs
{
    public class PlatformReadDTO
    {
      
        public int Id { get; set; }

       
        public string Name { get; set; }

     
        public string Publisher { get; set; }

        
        public string Cost { get; set; }
    }
}
