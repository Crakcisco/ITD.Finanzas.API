﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA.Atributes;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class CategoriasDataPost
    {
        public string type { get; set; }
        public CategoriasAttributes attributes { get; set; }
    }
}
