function Get-GitDescription() {
    $tag = Invoke-Expression "git describe --long --tags --always"

    return [Hashtable]@{
        Tag = $tag.ToString()
        VersionAbove = ([regex]"v\d+(\.\d+)-\d+").Match($tag).ToString()
        Version = ([regex]"v\d+(\.\d+)+").Match($tag).ToString().Substring(1)
    }
}

function Set-ContentToReplace([string]$fileName, [string]$source, [string]$destination) {
    $content = Get-Content -Path $fileName -Raw
    $content = $content -replace $source,$destination
    Out-File $content -FilePath $fileName -Encoding UTF8
}

function Install-GitDescription([string]$fileName, [string]$version) {
    Set-ContentToReplace $fileName 'Version("0.0.0.0")' $version
}

function Install-GitNightlyDescription([string]$fileName, [Hashtable]$tagDescription) {
    Install-GitDescription $fileName $tagDescription.Tag
}

function Install-GitPreviewDescription([string]$fileName, [Hashtable]$tagDescription) {
    Install-GitDescription $fileName ($tagDescription.VersionAbove + "-pre")
}

function Install-GitReleaseDescription([string]$fileName, [Hashtable]$tagDescription) {
    Install-GitDescription $fileName $tagDescription.Version
}

function Uninstall-GitDescription([string]$fileName) {
    (Invoke-Expression "git reset " $fileName) | Out-Null
}

$assemblyDescFileName = "./KH02.SaveEditor/Properties/AssemblyInfo.cs"

$tagDesc = Get-GitDescription
Install-GitNightlyDescription -FileName $assemblyDescFileName -TagDescription $tagDesc