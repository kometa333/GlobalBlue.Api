# GlobalBlue API

Simple ASP.NET Core Web API to calculate net, VAT and gross amounts for Austrian VAT rates (10%, 13%, 20%).

---

## How to run locally

### 1. Clone the repository

```bash
git clone https://github.com/kometa333/GlobalBlue.Api.git
```

### 2. Change directory

```bash
cd GlobalBlue.Api
```

### 3. Run the API

You have two main ways to start the application:

#### a) Using the .NET CLI with a launch profile

- **HTTPS + HTTP** (uses the `https` profile):
  ```bash
  dotnet run --launch-profile "https"
  ```
  This will bind to:
  - HTTPS: `https://localhost:7269`
  - HTTP:  `http://localhost:5272`

- **HTTP only** (uses the `http` profile):
  ```bash
  dotnet run --launch-profile "http"
  ```
  This will bind to:
  - HTTP: `http://localhost:5272`

#### b) Using Visual Studio

1. Open `GlobalBlue.Api.sln` in Visual Studio 2022.
2. Select the **IIS Express** or **https** profile from the debug target dropdown.
3. Press **F5** to debug or **Ctrl+F5** to run without debugging.


### 4. Open Swagger UI

Once the API is running, open your browser at:

```
https://localhost:7269/swagger/index.html
```

The Swagger UI lets you explore and execute the `POST /api/vat/calculate` endpoint.


### 5. Calling the endpoint

- **Note:** `GET /api/vat/calculate` will return 404—this endpoint only accepts **POST**.

- **Example `curl`** (HTTPS):
  ```bash
  curl -k \
    -H "Content-Type: application/json" \
    -d '{"netAmount":100.0,"vatRate":20}' \
    https://localhost:7269/api/vat/calculate
  ```

- **Example `curl`** (HTTP):
  ```bash
  curl \
    -H "Content-Type: application/json" \
    -d '{"grossAmount":120.0,"vatRate":20}' \
    http://localhost:5272/api/vat/calculate
  ```

---

## Request & Response

- **Request** (`VatCalculationRequest`): provide **exactly one** of `netAmount`, `grossAmount`, or `vatAmount`, plus a valid `vatRate` (`10`, `13`, `20`).

  ```json
  {
    "netAmount": 100.0,
    "vatRate": 20
  }
  ```

- **Response** (`VatCalculationResponse`): all three amounts plus the rate.

  ```json
  {
    "netAmount": 100.00,
    "vatAmount": 20.00,
    "grossAmount": 120.00,
    "vatRate": 20
  }
  ```



