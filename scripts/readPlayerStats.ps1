Param (
    [Parameter(Mandatory=$true)]
    [string] $inputFile
)

$file = Get-Content $inputFile | Out-String | ConvertFrom-Json

$rawJson = $file.Metadata.RawJson | ConvertFrom-Json

$output = "| Property Name | Description |`n| --- | --- |"

foreach ($property in $rawJson[0].PsObject.Properties)
{
    $output = "$($output)`n| $($property.Name) | |"
}

$output | Out-File -FilePath "test.md"