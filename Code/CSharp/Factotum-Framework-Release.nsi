!define /date MyTIMESTAMP "%Y-%m-%d@%H_%M"

Name "Factotum"

; The file to write
OutFile "Factotum-Framework-Install-${MyTIMESTAMP}.exe"

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
  File /r ".\Binary\Release\net48\*.dll"
  
SectionEnd ; end the section
