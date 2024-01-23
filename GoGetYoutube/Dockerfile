#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update -y
RUN apt-get upgrade -y
RUN apt-get install -y python3.10 curl
RUN ln -s /usr/bin/python3.10 /usr/bin/python
RUN curl -L https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp -o /usr/local/bin/yt-dlp
RUN chmod a+rx /usr/local/bin/yt-dlp
RUN apt install ffmpeg -y
RUN apt install cifs-utils -y
RUN mkdir /mnt/NAS

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GoGetYoutube.csproj", "./"]
RUN dotnet restore "GoGetYoutube.csproj"
COPY . ./

WORKDIR /src/.
RUN dotnet build "GoGetYoutube.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoGetYoutube.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoGetYoutube.dll"]