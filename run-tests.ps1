# Run tests and capture output
$output = dotnet test --logger "console;verbosity=normal" 2>&1 | Out-String

# Display the output
Write-Host $output

# Check if tests passed by looking for the pass/fail summary
if ($output -match "Total tests:\s+(\d+)\s+Passed:\s+(\d+)") {
    $totalTests = [int]$Matches[1]
    $passedTests = [int]$Matches[2]

    if ($passedTests -eq $totalTests -and $totalTests -gt 0) {
        Write-Host "`n========================================" -ForegroundColor Green
        Write-Host "SUCCESS: All $totalTests tests passed!" -ForegroundColor Green
        Write-Host "========================================" -ForegroundColor Green
        exit 0
    } else {
        $failedTests = $totalTests - $passedTests
        Write-Host "`n========================================" -ForegroundColor Red
        Write-Host "FAILED: $failedTests out of $totalTests tests failed!" -ForegroundColor Red
        Write-Host "========================================" -ForegroundColor Red
        exit 1
    }
} else {
    Write-Host "`nCould not determine test results" -ForegroundColor Yellow
    exit 1
}
