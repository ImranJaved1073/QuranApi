# Quran API - ASP.NET Core MVC
This repository contains a Quran API built using ASP.NET Core MVC. The API provides Quranic data such as Surahs, Ayahs, translations, and more. It is designed to be scalable, reliable, and easily accessible for any application that needs Quranic content. The API is published and hosted on Microsoft Azure for seamless deployment and scalability.
## API LINK
API can be accessed through this link with swagger integration
https://quranapiservice-ekfkd2dvcsbmekcq.eastus-01.azurewebsites.net/index.html

## Features
- **Surah and Ayah Retrieval:** Fetch Surah names and details of specific Ayahs.
- **Surah Retrieval:** Fetch Surah names and details of each surah and its ayaaat.
- **Parah Retrieval:** Fetch Parah names and details of of each parah and its ayaaat.
- **Ruku Retrieval:** Fetch ruku and ruku by surah.
## Technologies Used
* **ASP.NET Core MVC** for building the API and web application.
*  **Entity Framework Core** for database access and management.
*  **SQL Server** for storing Quranic data, user preferences, and history. 
*  **Azure App Services** for hosting the API on Microsoft Azure.
*  **Swagger** for API documentation.
## API Endpoints
The following endpoints are available for use:

### Surah Endpoints 
* `GET /api/surahs` - Retrieve a list of all Surahs.
* `GET /api/surahs/{id}` - Retrieve details of a specific Surah by its ID.
### Ayah Endpoints
* `GET /api/surahs/{surahId}/ayahs` - Retrieve all Ayahs from a specific Surah.
* `GET /api/ayahs/{id}` - Retrieve details of a specific Ayah by its ID.
