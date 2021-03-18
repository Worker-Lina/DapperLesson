﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DapperLesson.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; }
        public int Number { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
