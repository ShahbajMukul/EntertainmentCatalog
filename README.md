# Entertainment Catalog 🎬

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A multi-platform app for tracking and reviewing movies and TV shows, available on Android, iOS, Windows, and Web.

## 📱 Features

- **Multi-Platform Support**: Android, iOS, Windows, and Web through Blazor Hybrid Maui
- **Comprehensive Tracking**: Log and organize your watched content
- **Personal Reviews**: Write and save detailed reviews
- **Rating System**: Rate your watched content
- **Cross-Device Sync**: Access your catalog anywhere
- **User-Friendly Interface**: Intuitive design for film enthusiasts

## 🚀 Tech Stack

- **Blazor Hybrid Maui**
- **.NET**
- **MudBlazor**
- **Entity Framework**

## 🛠️ Getting Started

### Prerequisites

- .NET SDK
- Android SDK / iOS Development tools (for mobile development)
- OMDB API key

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/shahbajmukul/entertainment-catalog.git
   cd entertainment-catalog
   ```

2. **Install dependencies**

   ```bash
   dotnet restore
   ```

3. **Configure OMDB API**

   - Get an API key from [OMDB API](http://www.omdbapi.com/)
   - Create `appsettings.json`:
     ```json
     {
       "OmdbApiKey": "your_api_key_here"
     }
     ```

4. **Run the application**

   ```bash
   dotnet run
   ```

   For web specifically:

   ```bash
   dotnet run --project EntertainmentCatalog.Web
   ```

## 🎨 Usage

1. Search for movies and TV shows
2. Add titles to your catalog
3. Rate and review content
4. Access your library across devices

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Commit changes
   ```bash
   git commit -m "Add YourFeature"
   ```
4. Push to branch
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a Pull Request

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 📬 Contact

- **Developer**: Shahbaj Mukul
- **GitHub Issues**: [Report a bug](https://github.com/shahbajmukul/entertainment-catalog/issues)

---

Happy watching! 🎥🍿
