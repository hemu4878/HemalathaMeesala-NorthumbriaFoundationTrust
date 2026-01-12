# Northumbria NHS - BDD Automation Test Suite

Comprehensive BDD Functional Acceptance Automation Test Suite for Northumbria NHS Website

**Tech Stack:** .NET 8, C#, Playwright, Reqnroll

## Overview

This project implements a robust test automation framework for the Northumbria NHS Foundation Trust website, focusing on search functionality with comprehensive test coverage including edge cases and security validation.

## Features

- **BDD/Gherkin Syntax** - Human-readable test scenarios using Reqnroll
- **Page Object Model** - Clean, maintainable code structure
- **Cross-Browser Support** - Chromium, Firefox, and Edge
- **Security Testing** - XSS protection validation
- **Edge Case Coverage** - Special characters, empty search, Unicode support

## Test Coverage

### Search Functionality (11 scenarios)

1. **Basic Search** (4 tests)
   - Contact
   - Appointment
   - Services
   - Departments

2. **No Results Handling** (1 test)
   - Validates "no results" message display

3. **Empty Search** (1 test)
   - Validates helpful suggestions

4. **Special Characters** (5 tests)
   - `@contact` - Special character handling
   - `test&appointment` - Ampersand handling
   - `"emergency"` - Quotation marks
   - `<script>test` - XSS security validation (WAF blocked)
   - `£100 fee` - Unicode support

### What We Validate

- ✅ Search functionality works correctly
- ✅ Graceful error handling
- ✅ Empty search provides helpful suggestions
- ✅ Special characters don't crash the site
- ✅ XSS protection via Web Application Firewall
- ✅ Unicode character support
- ✅ User-friendly error messages

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or VS Code
- Git

## Installation

### 1. Clone the repository

```bash
git clone <repository-url>
cd NorthumbriaAutomation
```

### 2. Install dependencies

```bash
dotnet restore
```

### 3. Install Playwright browsers

```bash
playwright install
```

Or using PowerShell:

```powershell
pwsh bin/Debug/net8.0/.playwright/package/lib/cli.js install
```

## Configuration

### Browser Selection

Edit `appsettings.json` to choose your browser:

```json
{
  "Browser": "chromium"
}
```

**Available options:**
- `chromium` - Google Chrome/Chromium
- `firefox` - Mozilla Firefox
- `webkit` - Safari (WebKit)

## Running Tests

### Run all tests

**Option 1: Using the test runner script (Recommended)**

Windows Command Prompt or PowerShell:
```bash
run-tests.cmd
```

Or directly with PowerShell:
```powershell
powershell -ExecutionPolicy Bypass -File run-tests.ps1
```

**Option 2: Using dotnet CLI**
```bash
dotnet test
```

> **Note:** When using `dotnet test` directly, you may see a teardown warning message at the end. This is a known Reqnroll/NUnit compatibility issue and doesn't affect test execution. All tests will still pass. The `run-tests.cmd` script handles this automatically and returns proper exit codes.

### Run specific test tags

```bash
# Run only search tests
dotnet test --filter "Category=search"

# Run only no-results tests
dotnet test --filter "Category=no-results"

# Run special character tests
dotnet test --filter "Category=special-characters"
```

### Run with detailed output

```bash
dotnet test --logger "console;verbosity=detailed"
```

### Build and run

```bash
dotnet build
dotnet test
```

## Project Structure

```
NorthumbriaAutomation/
├── Features/
│   └── Search.feature              # BDD scenarios in Gherkin
├── StepDefinitions/
│   └── SearchSteps.cs              # Step implementations
├── Pages/
│   └── SearchPage.cs               # Page Object Model (with stable selectors)
├── Drivers/
│   └── BrowserDriver.cs            # Browser management
├── Hooks/
│   └── Hooks.cs                    # Test setup/teardown
├── appsettings.json                # Configuration
├── reqnroll.json                   # Reqnroll configuration
├── run-tests.cmd                   # Test runner script (Windows)
├── run-tests.ps1                   # PowerShell test runner
├── NorthumbriaAutomation.csproj    # Project file
└── README.md                       # This file
```

## Key Components

### Page Object Model

`SearchPage.cs` - Encapsulates search page elements and actions using **stable selectors**
- Uses `input[name='query'].search-field` selector (resilient to dynamic ID changes)
- `NavigateToHomeAsync()` - Navigate to homepage
- `EnterSearchTermAsync()` - Enter search term
- `ClickSearchButtonAsync()` - Click search button
- `ClickSearchButtonWithoutNavigationAsync()` - Click for edge cases

**Why stable selectors?** The search field's ID is dynamically generated (e.g., `search-query-carousel-40618`), so we use the stable `name` and `class` attributes instead.

### Step Definitions

`SearchSteps.cs` - Implements Gherkin steps
- Given: Setup conditions
- When: User actions
- Then: Assertions and validations

### Browser Driver

`BrowserDriver.cs` - Manages Playwright browser lifecycle
- Configurable browser selection
- Headless mode support
- Automatic cleanup

## Test Results

All 11 tests passing ✅

```
Test Run Successful.
Total tests: 11
     Passed: 11
     Failed: 0
  Duration: ~30-40s
```

### Test Execution Screenshots

![Test Execution](docs/screenshots/test-execution.png)
*All 11 BDD scenarios executing and passing successfully*

![Test Summary](docs/screenshots/all-tests-passing.png)
*Test run summary showing 100% pass rate (11/11)*

### Playwright Trace Files

This project automatically generates **Playwright trace files** for every test run, providing an interactive timeline of test execution.

**What's included in traces:**
- 📸 Screenshots at every step
- 🎬 DOM snapshots for time-travel debugging
- 🔍 Network activity and console logs
- 📊 Full execution timeline

**View the sample trace:**
1. Download: [Sample Trace File](docs/traces/sample-trace.zip)
2. Open: https://trace.playwright.dev/
3. Upload the trace file to view interactive execution

**Trace files are generated** in the `traces/` folder after each test run.

## Important Findings

### Security Validation ✅
The test suite discovered and validates that the Northumbria NHS website has:
- **Web Application Firewall (WAF)** protection
- **XSS attack prevention** (blocks `<script>` tags)
- Returns "Error 15 - Access Denied" for malicious input

### Edge Case Handling ✅
- Empty searches show helpful "You might also be interested in..." suggestions
- Special characters are handled gracefully without crashes
- Unicode characters (£) work correctly
- No results display appropriate messaging

## Technologies Used

- **.NET 8** - Latest .NET framework
- **C# 12** - Modern C# features
- **Playwright** - Modern browser automation
- **Reqnroll** - Free, open-source BDD framework for .NET
- **FluentAssertions** - Readable assertions
- **NUnit** - Test framework

## Best Practices Implemented

- ✅ Page Object Model pattern
- ✅ Async/await for all operations
- ✅ Explicit waits with timeouts
- ✅ Flexible assertions (handles multiple scenarios)
- ✅ Clean separation of concerns
- ✅ Readable Gherkin scenarios
- ✅ Comprehensive error handling

## Future Enhancements

Potential areas for expansion:
- Add more features (navigation, forms, etc.)
- Implement screenshot on failure
- Add HTML/Allure reporting
- CI/CD pipeline integration (GitHub Actions, Azure DevOps)
- API testing integration
- Performance testing
- Accessibility testing

## Troubleshooting

### Playwright browsers not installed
```bash
playwright install
```

### Build errors
```bash
dotnet clean
dotnet restore
dotnet build
```

### Tests failing on browser launch
Check `appsettings.json` browser configuration and ensure Playwright browsers are installed.

### PowerShell execution policy error
If you get "script cannot be loaded" error when running `run-tests.ps1`:

**Solution 1:** Use the batch file wrapper
```bash
run-tests.cmd
```

**Solution 2:** Run with bypass flag
```powershell
powershell -ExecutionPolicy Bypass -File run-tests.ps1
```

**Solution 3:** Change execution policy (permanent)
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

### Teardown warning in dotnet test output
When running `dotnet test`, you may see:
```
TearDown : System.InvalidOperationException : Only static OneTimeSetUp and OneTimeTearDown are allowed for InstancePerTestCase mode.
```

**This is expected and does not affect test execution.** All tests still pass. Use `run-tests.cmd` for clean output and proper exit codes.

## Contributing

1. Create a feature branch
2. Write tests following BDD principles
3. Ensure all tests pass
4. Submit pull request

## License

This project is for educational and testing purposes for Northumbria NHS Foundation Trust.

## Contact

For questions or issues, please contact the QA team.

---

**Last Updated:** January 2026
**Test Suite Version:** 1.0
**Status:** ✅ All Tests Passing (11/11)
