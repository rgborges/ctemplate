#!/bin/sh
dotnet clean
dotnet restore
dotnet build -c Debug
dotnet build -c Release