; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Minecraft Server Downloader"
#define MyAppVersion "2.0.1"
#define MyAppPublisher "Distroir"
#define MyAppURL "http://gamebanana.com/tools/5990"
#define MyAppExeName "Minecraft Server Downloader.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8D050B91-A92E-4768-8852-D4D3BECE55BE}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\Distroir\Minecraft Server Downloader
DefaultGroupName=Distroir\Minecraft Server Downloader
LicenseFile="setup-files\gpl-3.0.txt"
OutputDir=setup-files
OutputBaseFilename="Minecraft Version Downloader {#MyAppVersion} Setup"
SetupIconFile="setup-files\Setupx64.ico"
Compression=lzma2
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; 64 bit exe
Source: "Minecraft Version Downloader\bin\x64\Release\Minecraft Server Downloader.exe"; DestDir: "{app}"; Check: Is64BitInstallMode
; 32 bit exe
Source: "Minecraft Version Downloader\bin\Release\Minecraft Server Downloader.exe"; DestDir: "{app}"; Check: not Is64BitInstallMode; Flags: solidbreak
; Libraries
Source: "Minecraft Version Downloader\bin\Release\MetroFramework.dll"; DestDir: "{app}";
Source: "Minecraft Version Downloader\bin\Release\MetroFramework.Fonts.dll"; DestDir: "{app}";
Source: "Minecraft Version Downloader\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}";
; License file
Source: "setup-files\gpl-3.0.txt"; DestDir: "{app}"; Flags: solidbreak
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function UninstallNeedRestart(): Boolean;
begin
  Result := true
end;
