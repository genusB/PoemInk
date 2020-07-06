# PoemInk

## About project
This application provides an environment to write poems and stories. Application consists of the next parts:  
creation poems by your own from scratch, generating poems, inspiration from others creativity 
## Development Environment
- Sql Server 2019
- Node 14.3.0 & NPM 6.14.5
- .NET Core 3.1 sdk
- Vue CLI => npm install -g @vue/cli https://github.com/vuejs/vue-cli
- Vue 2.6.11
- IronPython 2.7

## Setup
To build and run the project:

### Build Vue.js application:
1. Install npm packages with `ClientApp>npm install` in the `ClientApp` directory.
2. If you nedd to start only frontend part of the application, run `ClientApp>npm run serve` in the `ClientApp` directory.

### Build and run the ASP.NET Core Web application:
1. Restore nuget packages with `PoemInk\PoemInk>dotnet restore` in the `PoemInk\PoemInk` directory.
2. Create the database with `PoemInk\PoemInk>dotnet ef database update` in the `PoemInk\PoemInk` directory.
3. You have to install IronPython locally to be able to run a python script from .net. Also, check its installation directory, it should be `C:\Program Files\IronPython 2.7\`.
4. Make sure that ports 5000 and 8080 are free.
5. Run the project with `PoemInk\PoemInk>dotnet run` in the `PoemInk\PoemInk` directory.
