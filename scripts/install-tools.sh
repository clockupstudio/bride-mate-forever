#!/bin/sh

# install-tools.sh uses for install required tools for this project.

if [ -z $(which dotnet) ]
then
    echo "dotnet-sdk is not install. If you're macos, please try 'brew cask install dotnet-sdk'"
    exit 1
fi
echo "dotnet-sdk was installed."

if [ ! -f "$HOME/.dotnet/tools/dotnet-format" ]
then
    echo "Install dotnet-format."
    dotnet tool install -g dotnet-format
else
    echo "dotnet-format was installed. Try updating it."
    dotnet tool update -g dotnet-format
fi
