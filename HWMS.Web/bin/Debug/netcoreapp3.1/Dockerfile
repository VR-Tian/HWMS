#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HWMS.Web/HWMS.Web.csproj", "HWMS.Web/"]
COPY ["HWMS.DoMain/HWMS.DoMain.csproj", "HWMS.DoMain/"]
COPY ["HWMS.DoMain.Core/HWMS.DoMain.Core.csproj", "HWMS.DoMain.Core/"]
COPY ["HWMS.Infrastructure/HWMS.Infrastructure.csproj", "HWMS.Infrastructure/"]
COPY ["HWMS.Application/HWMS.Application.csproj", "HWMS.Application/"]
RUN dotnet restore "HWMS.Web/HWMS.Web.csproj"
COPY . .
WORKDIR "/src/HWMS.Web"
RUN dotnet build "HWMS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HWMS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HWMS.Web.dll"]