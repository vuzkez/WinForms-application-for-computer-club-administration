# rename-solution.ps1
# Run from: F:\coursework\WinForms-application-for-computer-club-administration

$oldSolutionName = "AdminPanelComputerClub"
$newSolutionName = "GameClub"

$oldGuiProject = "AdminPanelComputerClub"
$newGuiProject = "GameClub.GUI"

$oldLibProject = "AdminPanelLibrary"
$newLibProject = "GameClub.Library"

Write-Host "=== Renaming solution ===" -ForegroundColor Cyan

# 1. Rename .sln file
Write-Host "1. Renaming $oldSolutionName.sln -> $newSolutionName.sln"
Rename-Item "$oldSolutionName.sln" "$newSolutionName.sln"

# 2. Update .sln content
Write-Host "2. Updating references in .sln"
$slnContent = [System.IO.File]::ReadAllText("$PWD\$newSolutionName.sln")
$slnContent = $slnContent -replace [regex]::Escape($oldGuiProject), $newGuiProject
$slnContent = $slnContent -replace [regex]::Escape($oldLibProject), $newLibProject
[System.IO.File]::WriteAllText("$PWD\$newSolutionName.sln", $slnContent)

# 3. Rename project folders
Write-Host "3. Renaming folders"
Rename-Item $oldGuiProject $newGuiProject
Rename-Item $oldLibProject $newLibProject

# 4. Rename .csproj files
Write-Host "4. Renaming .csproj files"
Rename-Item "$newGuiProject\$oldGuiProject.csproj" "$newGuiProject\$newGuiProject.csproj"
Rename-Item "$newLibProject\$oldLibProject.csproj" "$newLibProject\$newLibProject.csproj"

# 5. Update GUI .csproj
Write-Host "5. Updating references in .csproj"
$guiCsprojPath = "$newGuiProject\$newGuiProject.csproj"
$guiCsproj = [System.IO.File]::ReadAllText("$PWD\$guiCsprojPath")
$guiCsproj = $guiCsproj -replace [regex]::Escape("$oldLibProject.csproj"), "$newLibProject.csproj"
$guiCsproj = $guiCsproj -replace [regex]::Escape("<RootNamespace>$oldGuiProject</RootNamespace>"), "<RootNamespace>$newGuiProject</RootNamespace>"
$guiCsproj = $guiCsproj -replace [regex]::Escape("<AssemblyName>$oldGuiProject</AssemblyName>"), "<AssemblyName>$newGuiProject</AssemblyName>"
[System.IO.File]::WriteAllText("$PWD\$guiCsprojPath", $guiCsproj)

# Update Library .csproj
$libCsprojPath = "$newLibProject\$newLibProject.csproj"
$libCsproj = [System.IO.File]::ReadAllText("$PWD\$libCsprojPath")
$libCsproj = $libCsproj -replace [regex]::Escape("<RootNamespace>$oldLibProject</RootNamespace>"), "<RootNamespace>$newLibProject</RootNamespace>"
$libCsproj = $libCsproj -replace [regex]::Escape("<AssemblyName>$oldLibProject</AssemblyName>"), "<AssemblyName>$newLibProject</AssemblyName>"
[System.IO.File]::WriteAllText("$PWD\$libCsprojPath", $libCsproj)

# 6. Replace namespace and using in all .cs files
Write-Host "6. Updating namespace and using in .cs files..."
$files = Get-ChildItem -Path $newGuiProject, $newLibProject -Filter *.cs -Recurse

foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    $changed = $false
    
    if ($content -match [regex]::Escape("namespace $oldGuiProject")) {
        $content = $content -replace [regex]::Escape("namespace $oldGuiProject"), "namespace $newGuiProject"
        $changed = $true
    }
    if ($content -match [regex]::Escape("namespace $oldLibProject")) {
        $content = $content -replace [regex]::Escape("namespace $oldLibProject"), "namespace $newLibProject"
        $changed = $true
    }
    if ($content -match [regex]::Escape("using $oldLibProject")) {
        $content = $content -replace [regex]::Escape("using $oldLibProject"), "using $newLibProject"
        $changed = $true
    }
    
    if ($changed) {
        [System.IO.File]::WriteAllText($file.FullName, $content)
        Write-Host "  Updated: $($file.Name)" -ForegroundColor Green
    }
}

# 7. Clean old builds
Write-Host "7. Cleaning old build files..."
Remove-Item -Path "$newGuiProject\bin", "$newGuiProject\obj", "$newLibProject\bin", "$newLibProject\obj" -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "=== Done! Open GameClub.sln ===" -ForegroundColor Green