# GlobalBlue VAT API

Simple ASP.NET Core Web API to calculate net, VAT and gross amounts for Austrian VAT rates (10%, 13%, 20%).

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download) (or later) installed
- Visual Studio 2022 (or VS Code) for editing (optional)

## How to run locally

1. **Clone the repository**
   ```bash
   git clone https://github.com/kometa333/GlobalBlue.Api.git
   ```

2. **Change directory**
   ```bash
   cd GlobalBlue.Api
   ```

3. **Build and run**
   ```bash
   dotnet run
   ```

   By default, the API will listen on ports **7269** (HTTPS) and **5269** (HTTP).

4. **Open Swagger UI**

   Navigate in your browser to:
   ```
   https://localhost:7269/swagger/index.html
   ```
   You can explore and test the `POST /api/vat/calculate` endpoint interactively.

5. **Call the endpoint**

   - The VAT API only supports **POST** requests. Sending a **GET** to `/api/vat/calculate` will return 404 (Not Found).
   - Example `curl` invocation:
     ```bash
     curl -k \
       -H "Content-Type: application/json" \
       -d '{"netAmount":100.0,"vatRate":20}' \
       https://localhost:7269/api/vat/calculate
     ```

## Request & Response

- **Request** (`VatCalculationRequest` JSON): exactly one of `netAmount`, `grossAmount`, or `vatAmount`, plus a valid `vatRate` (10, 13 or 20).

  ```json
  {
    "netAmount": 100.0,
    "vatRate": 20
  }
  ```

- **Response** (`VatCalculationResponse` JSON): all three amounts plus the rate.

  ```json
  {
    "netAmount": 100.00,
    "vatAmount": 20.00,
    "grossAmount": 120.00,
    "vatRate": 20
  }
  ```

## Logging

Uses the built-in `ILogger<T>` with console output by default. To change log level (e.g. to see `Debug`), edit `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Warning"
    }
  }
}
```

