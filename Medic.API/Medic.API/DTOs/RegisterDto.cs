﻿namespace Medic.API.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
    }
}