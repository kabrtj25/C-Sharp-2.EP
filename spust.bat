@echo off
chcp 65001 >nul
title C-Sharp-2_EP - menu

:menu
cls
echo ==============================
echo   C-Sharp-2_EP - vyber program
echo ==============================
echo   1  Papousek
echo   2  Kamen-nuzky-papir
echo   3  Piskvorky
echo   4  Sibenice
echo   5  Volna disciplina
echo   0  Konec
echo ==============================
set /p volba=Tvoje volba: 

if "%volba%"=="0" exit /b
set projekt=
if "%volba%"=="1" set projekt=Papousek
if "%volba%"=="2" set projekt=KamenNuzkyPapir
if "%volba%"=="3" set projekt=Piskvorky
if "%volba%"=="4" set projekt=Sibenice
if "%volba%"=="5" set projekt=VolnaDisciplina
if not defined projekt goto menu

cls
dotnet run --project "%~dp0%projekt%"
echo.
pause
goto menu
