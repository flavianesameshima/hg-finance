﻿namespace hg_brasil_finance.Domain.Entities
{
    public class Coinbase
    {
        public string name { get; set; }
        public List<string> format { get; set; }
        public double last { get; set; }
        public double variation { get; set; }
    }
}
