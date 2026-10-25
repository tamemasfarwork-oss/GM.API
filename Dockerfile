# ==========================================
# المرحلة الأولى: بناء مشروع الـ Angular (Frontend)
# ==========================================
FROM node:18 AS ng-build
WORKDIR /app-ng

COPY frontend.gym/package*.json ./
RUN npm install

COPY frontend.gym/ ./
RUN npm run build -- --configuration production

# ==========================================
# المرحلة الثانية: بناء مشروع الـ .NET (Backend)
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
WORKDIR /src

COPY ["GM.API/GM.API.csproj", "GM.API/"]
COPY ["GM.BLL/GM.BLL.csproj", "GM.BLL/"]
COPY ["GM.DAL/GM.DAL.csproj", "GM.DAL/"]
COPY ["GM.sln", "./"]

RUN dotnet restore

COPY . .
WORKDIR "/src/GM.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ==========================================
# المرحلة الثالثة: دمج الطرفين والتشغيل النهائي
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

# نسخ الـ Backend المبني
COPY --from=dotnet-build /app/publish .

# نسخ الـ Frontend (Angular) إلى wwwroot الخاص بالباك إند
COPY --from=ng-build /app-ng/dist/GM-App/browser /app/wwwroot

ENTRYPOINT ["dotnet", "GM.API.dll"]