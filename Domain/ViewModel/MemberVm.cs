﻿using System;

namespace Domain.ViewModel
{
    public class MemberVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
    }
}
