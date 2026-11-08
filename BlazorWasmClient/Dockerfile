FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY BlazorWasmClient/BlazorWasmClient.csproj BlazorWasmClient/
COPY DashboardService.Api/*.csproj DashboardService.Api/
COPY PolicySearchService.Api/*.csproj PolicySearchService.Api/
COPY PolicyService.Api/*.csproj PolicyService.Api/
COPY PricingService.Api/*.csproj PricingService.Api/
COPY ProductService.Api/*.csproj ProductService.Api/
RUN dotnet restore BlazorWasmClient/BlazorWasmClient.csproj
COPY BlazorWasmClient/ BlazorWasmClient/
COPY DashboardService.Api/ DashboardService.Api/
COPY PolicySearchService.Api/ PolicySearchService.Api/
COPY PolicyService.Api/ PolicyService.Api/
COPY PricingService.Api/ PricingService.Api/
COPY ProductService.Api/ ProductService.Api/
RUN dotnet publish BlazorWasmClient/BlazorWasmClient.csproj -c Release -o /out --no-restore

FROM nginx:stable-perl
COPY BlazorWasmClient/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /out/wwwroot/ /usr/share/nginx/html/
EXPOSE 80
