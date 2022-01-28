﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Designation { get; set; }
        public float Price { get; set; }
        public bool InStock { get; set; }
        public int Qauntité { get; set; }
        public Categorie categorie { get; set; }
        public string imageurl { get; set; }
    }
}
