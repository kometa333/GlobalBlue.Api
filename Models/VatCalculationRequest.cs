namespace GlobalBlue.Api.Models
{
    public class VatCalculationRequest
    {
        public decimal? NetAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? VatAmount { get; set; }

        // Must be one of 10, 13, 20
        public int VatRate { get; set; }
    }
}
