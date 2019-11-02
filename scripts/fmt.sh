#!/bin/sh

# fmt.sh uses for format .cs source code in this project.

dotnet-format -w $(dirname $0)/../Assembly-CSharp.csproj
