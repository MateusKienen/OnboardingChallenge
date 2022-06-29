#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnboardingChallenge.Server/OnboardingChallenge.Server.csproj", "OnboardingChallenge.Server/"]
RUN dotnet restore "OnboardingChallenge.Server/OnboardingChallenge.Server.csproj"
COPY . .
WORKDIR "/src/OnboardingChallenge.Server"
RUN dotnet build "OnboardingChallenge.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnboardingChallenge.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnboardingChallenge.Server.dll"]