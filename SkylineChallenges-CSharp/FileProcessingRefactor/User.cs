﻿using System;

namespace SkylineChallenges_CSharp.FileProcessingRefactor
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get;set; }
        public string Generation { get; set; }
        public Color ProfileColor { get; set; }
        public string CreditCardInfo { get; set; }
    }
}
