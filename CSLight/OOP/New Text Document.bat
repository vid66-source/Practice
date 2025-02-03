@echo off
setlocal enabledelayedexpansion
cd /d "F:\Studying\C#\Practice\CSLight"
for /R %%f in (*OopHWFirstTask*) do (
    if not "%%~nxf"=="%~nx0" (
        set "filename=%%~nxf"
        set "newname=!filename:OopHWFirstTask=UserClass!"
        ren "%%f" "!newname!"
    )
)
pause