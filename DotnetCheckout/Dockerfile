FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotnetCheckout/DotnetCheckout.csproj", "DotnetCheckout/"]
RUN dotnet restore "DotnetCheckout/DotnetCheckout.csproj"
COPY . .
WORKDIR "/src/DotnetCheckout"
RUN dotnet build "DotnetCheckout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetCheckout.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetCheckout.dll"]
