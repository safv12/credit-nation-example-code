FROM microsoft/aspnetcore-build:2.0 AS build-env

WORKDIR /app

COPY . .
WORKDIR ./src/Api/Application

RUN dotnet restore

RUN dotnet publish . -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/src/Api/Application/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "LoanService.Api.Application.dll"]