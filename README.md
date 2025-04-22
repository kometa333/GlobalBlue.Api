# GlobalBlue API

Simple ASP.NET Core Web API to calculate net, VAT and gross amounts for Austrian VAT rates (10, 13, 20%).

1. Clone:
   ```bash
   git clone https://github.com/kometa333/GlobalBlue.Api.git
   cd GlobalBlue.Api
   ```

2. Run via CLI:
   ```bash
   dotnet run --launch-profile https
   ```
   (listens on https://localhost:7269 and http://localhost:5272)

   or via VS:
   - Open in VS2022
   - Pick IIS Express or https profile
   - F5 to start

3. Open:
   - Swagger: https://localhost:7269/swagger/index.html
   - Endpoint: POST https://localhost:7269/api/vat/calculate

4. Example curl:
   ```bash
   curl -k -H "Content-Type: application/json" \
     -d '{"netAmount":100.0,"vatRate":20}' \
     https://localhost:7269/api/vat/calculate
   ```

Request: JSON with one of netAmount/grossAmount/vatAmount + vatRate.
Response: JSON with netAmount, vatAmount, grossAmount, vatRate.

