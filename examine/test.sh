#!/usr/bin/env bash

script_dir=$(cd $(dirname $0); pwd)

dotnet "$script_dir/10.wrapper-class/bin/Debug/net7.0/wrapper-class.dll"
echo ""
dotnet "$script_dir/20.reflect-call/bin/Debug/net7.0/reflect-call.dll"
echo ""
dotnet "$script_dir/30.reflect-eval/bin/Debug/net7.0/reflect-eval.dll"

