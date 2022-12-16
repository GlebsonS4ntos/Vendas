﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasBack.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string EnderecoFilial { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Produto Produto { get; set; }
    }
}