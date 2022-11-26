﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Dtos
{
    public class CategoryDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
