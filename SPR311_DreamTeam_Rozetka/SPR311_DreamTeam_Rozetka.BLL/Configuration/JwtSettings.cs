﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Configuration
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public int ExpMinutes { get; set; }
    }
}
