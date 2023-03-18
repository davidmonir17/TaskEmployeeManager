﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class AddDepDTo
    {
        [Required(ErrorMessage = "name is required field")]
        [MaxLength(60, ErrorMessage = "name Field not Exceded 60 char")]
        public string Name { get; set; }

        public int? MangerId { get; set; }
    }
}