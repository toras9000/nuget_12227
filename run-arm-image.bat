
set examine_dir=%~dp0/examine

rem Pre-build.
rem Because it cannot be built in a container.
dotnet build "%examine_dir%/10.wrapper-class"
dotnet build "%examine_dir%/20.reflect-call"
dotnet build "%examine_dir%/30.reflect-eval"

rem Run image for ARM64
docker run ^
    -it ^
    --rm ^
    -v "%examine_dir%:/examine" ^
    mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim-arm64v8 ^
    bash

