<<<<<<< HEAD
# HemalathaMeesala-NorthumbriaFoundationTrust
BDD Functional Acceptance Automation Test Suite for Northumbria NHS Website using .NET 8, C#, Playwright and SpecFlow
=======
﻿# Northumbria NHS - Search Automation Suite

Using .NET 8, C#, Playwright & SpecFlow BDD

## Requirements

- .NET 8 SDK
- Playwright (installed via: `playwright install`)
- Visual Studio 2022

## How to Run the Tests

### 1. Install dependencies

```bash
dotnet restore
playwright install
```

### 2. Choose browser

Edit **appsettings.json**:

```json
{
  "Browser": "chromium"
}
```

Options:
- chromium (Chrome)
- firefox (Firefox)
- edge (Microsoft Edge)

### 3. Run tests

```bash
dotnet test
```

## Test Structure

- BDD using SpecFlow
- Page Object Model
- Cross-browser support
- Fully command-line runnable

## Scenario Tested

- Navigate to NHS website
- Enter search term
- Submit search
- Validate search results

This suite satisfies all requirements in the technical exercise.
>>>>>>> dcf035a (Initial commit: BDD automation test suite for Northumbria NHS website using Playwright, SpecFlow and C#)
