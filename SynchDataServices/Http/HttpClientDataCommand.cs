﻿using Microsoft.Extensions.Configuration;
using PlatformService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.SynchDataServices.Http
{
    public class HttpClientDataCommand : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public HttpClientDataCommand(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO plat )
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
                ) ;

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}/api/c/platforms/", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK!");
            }
            else
                Console.WriteLine("--> Sync POST to CommandService was not OK!");
        }
    }
}
