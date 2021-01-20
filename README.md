## Sympli Technical challenge

# ![.net core 3.1](http://csharpcorner.mindcrackerinc.netdna-cdn.com/UploadFile/MinorCatImages/062632AM.png.ashx?width=64&height=64) Sympli.Search.Api API

NET Core 3.1 Web API services the request returning back the response from Google.

### Getting started

- Clone the project on [jasmine Github](https://github.com/Jasyyie/sympli.search.api) via Http/SSH and pull the repository locally to view the source code

### Building

You are required to have alteast the following to be able to run the code

- .NET Core 3.1 installed on the system
- Visual Studio 2017 with the LATEST update (at least version 15.5.3)

### Structure

The project is structured to enable extensibility and ease of development. The structure is as follows:

#### Sympli.Search.Api

- Accepts the request and calls the particular service for processing the request.
- SearchController shows dependency injection through constructor.
- Mediator is used to dispatch the SearchRequest related with the SearchHandler.

#### Sympli.Search.Api.Services

- SearchHandler using GoogleService by dependency injection.
- Search position is returned by GoogleService using GoogleSearchResultUrls method to process GET request.
- Response is returned as position of the SearchUrl in google search.
- It uses HttpClientFactory.

#### Sympli.Search.Api.Test

- NUnit tests the service and HttpFactory.
- Testing HTTPFactory by mocking HttpMessageHandler.

#### Sympli.Search.Client

- It is React App.
- Do yarn start.
- update textfields with SearchKey and SearchUrl and Google Search position will be seen.
