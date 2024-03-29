﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheFinalProjectMUOD.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsFavorate { get; set; }
        public int RatingValue { get; set; }
    }
}
