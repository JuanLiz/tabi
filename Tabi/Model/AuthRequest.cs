﻿namespace Tabi.Model
{
    public class AuthRequest
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public required string Password { get; set; }
    }
}
