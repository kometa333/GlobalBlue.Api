using GlobalBlue.Api.Models;

namespace GlobalBlue.Api.Services.Interfaces
{
    public interface IVatCalculator
    {
        VatCalculationResponse Calculate(VatCalculationRequest request);
    }
}
