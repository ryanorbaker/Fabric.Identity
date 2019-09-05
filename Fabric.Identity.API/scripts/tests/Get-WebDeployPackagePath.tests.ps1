param(
    [string] $targetFilePath = "$PSScriptRoot\..\Install-Identity-Utilities.psm1"
)

Write-Host $targetFilePath
# Force re-import to pick up latest changes
Import-Module $targetFilePath -Force

Describe 'Get-WebDeployPackagePath'{
    Context 'Standalone'{
        InModuleScope Install-Discovery-Utilities{
            It 'Should return the standalone path'{
                # Arrange
                $standAlonePath = ".\Catalyst.DiscoveryService.zip"
                $resolvedPath = "C:\Installer\Catalyst.DiscoveryService.zip"
                Mock Resolve-Path { return $resolvedPath }
                Mock Test-Path -ParameterFilter { $Path -eq $standAlonePath } { return $true }

                # Act
                $path = Get-WebDeployPackagePath

                # Assert
                $path | Should -Be $resolvedPath
            }
        }
    }
    Context 'Standalone'{
        InModuleScope Install-Discovery-Utilities{
            It 'Should return the installer path'{
                # Arrange
                $installerPath = "..\WebDeployPackages\Catalyst.DiscoveryService.zip"
                $resolvedPath = "C:\Installer\WebDeployPackages\Catalyst.DiscoveryService.zip"
                Mock Resolve-Path { return $resolvedPath }
                Mock Test-Path -ParameterFilter { $Path -eq $installerPath } { return $true }

                # Act
                $path = Get-WebDeployPackagePath

                # Assert
                $path | Should -Be $resolvedPath
            }
        }
    }
    Context 'Failure'{
        InModuleScope Install-Discovery-Utilities{
            It 'Should throw an exception'{
                # Arrange
                Mock Test-Path { return $false }

                # Act/Assert
                { Get-WebDeployPackagePath } | Should -Throw
            }
        }
    }
}