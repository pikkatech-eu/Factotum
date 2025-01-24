!define /date MyTIMESTAMP "%Y-%m-%d@%H_%M"

Name "Factotum"
Icon "C:\pikkatech.eu\Resources\Images\ICO\tools.ico"

; The file to write
OutFile "Factotum-Install-${MyTIMESTAMP}.exe"

; The default installation directory
InstallDir "$DESKTOP\Factotum"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Pages
Page Directory
Page Instfiles
;--------------------------------
; The stuff to install
Section "Files" 
  ; Set output path to the installation directory.
  ; CreateDirectory "$INSTDIR"
  SetOutPath "$INSTDIR"
  
  ; Put files there
  File /r ".\Binary\Release\net8.0\*.dll"
  
SectionEnd ; end the section
