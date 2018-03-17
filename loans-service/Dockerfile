FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

COPY ./src/Api/Application/*.csproj ./

RUN dotnet restore && \
    dotnet ef migrations add InitialCreate && \
    dotnet ef database update

COPY . ./
RUN dotnet publish ./src/Api/Application -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/src/Api/Application/out .
ENTRYPOINT ["dotnet", "LoanService.Api.Application.dll"]