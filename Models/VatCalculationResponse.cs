﻿namespace GlobalBlue.Api.Models
{
    public class VatCalculationResponse
    {
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }
        public int VatRate { get; set; }
    }
}
