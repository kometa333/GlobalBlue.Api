using GlobalBlue.Api.Models;
using GlobalBlue.Api.Services.Interfaces;
using System;

namespace GlobalBlue.Api.Services
{
    public class VatCalculator : IVatCalculator
    {
        public VatCalculationResponse Calculate(VatCalculationRequest req)
        {
            // Validate rate
            if (req.VatRate != 10 && req.VatRate != 13 && req.VatRate != 20)
                throw new ArgumentException("VAT rate must be 10, 13, or 20.");

            // Count how many amount inputs provided
            var provided = new[] { req.NetAmount, req.GrossAmount, req.VatAmount }
                .Count(x => x.HasValue);
            if (provided == 0)
                throw new ArgumentException("Please provide one amount (net, gross, or VAT).");
            if (provided > 1)
                throw new ArgumentException("Please provide only one amount.");

            decimal net, gross, vat;
            var rateFactor = req.VatRate / 100m;

            if (req.NetAmount.HasValue)
            {
                net = req.NetAmount.Value;
                vat = Math.Round(net * rateFactor, 2);
                gross = net + vat;
            }
            else if (req.GrossAmount.HasValue)
            {
                gross = req.GrossAmount.Value;
                net = Math.Round(gross / (1 + rateFactor), 2);
                vat = gross - net;
            }
            else // VAT provided
            {
                vat = req.VatAmount.Value;
                net = Math.Round(vat / rateFactor, 2);
                gross = net + vat;
            }

            return new VatCalculationResponse
            {
                NetAmount = net,
                VatAmount = vat,
                GrossAmount = gross,
                VatRate = req.VatRate
            };
        }
    }
}
