FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY PricingService.Api/*.csproj PricingService.Api/
COPY PricingService/*.csproj PricingService/
RUN dotnet restore PricingService/PricingService.csproj
COPY PricingService.Api/ PricingService.Api/
COPY PricingService/ PricingService/
RUN dotnet publish PricingService/PricingService.csproj -c Release -o /out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5040
ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "PricingService.dll"]
