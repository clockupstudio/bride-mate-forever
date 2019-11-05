#!/bin/sh

# fmt.sh uses for format .cs source code in this project.

for proj in $(ls $(dirname $0)/../*.csproj)
do
    dotnet-format -w $proj
done
