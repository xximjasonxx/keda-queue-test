FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /code

COPY . .
RUN dotnet restore && dotnet build --no-restore -o /output

FROM mcr.microsoft.com/dotnet/runtime:3.1 as runtime
WORKDIR /cmd

COPY --from=build /output .
CMD [ "dotnet", "PrintMessage.dll" ]