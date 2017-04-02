SetCompressor /SOLID /FINAL lzma

!define APPNAME "Protogame"

;Include Modern UI

!include "Sections.nsh"
!include "MUI2.nsh"
!include "InstallOptions.nsh"

!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "..\protogame.bmp"
!define MUI_ABORTWARNING

!define MUI_WELCOMEFINISHPAGE_BITMAP "..\panel.bmp"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_FUNCTION "StartProtogameWorkbench"
!define MUI_FINISHPAGE_RUN_TEXT "Open the Protogame Workbench"

!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_LANGUAGE "English"

Name 'Protogame'
OutFile 'ProtogameInstall.exe'

InstallDir '$PROGRAMFILES\${APPNAME}'
VIProductVersion "1.0.0.0"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "Protogame"
VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyName" "Redpoint Games"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "1.0.0.0"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductVersion" "1.0.0.0"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "Protogame Installer"
VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "Copyright Redpoint Games Pty Ltd"

RequestExecutionLevel admin

; The stuff to install
Section "All Components" CoreComponents ;No components page, name is not important
  SectionIn RO
  
  SetOutPath '$INSTDIR'
  File '..\..\Protobuild.exe'
  
  nsExec::ExecToLog "Protobuild.exe --install https-nuget-v3://api.nuget.org/v3/index.json|Protogame.Workbench"
  
SectionEnd

Function StartProtobuildManager

  SetOutPath '$INSTDIR'
  ExecShell "open" "$STARTMENU\Protobuild Manager.url"

FunctionEnd