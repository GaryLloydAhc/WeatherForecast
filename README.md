# WeatherForecast
#Story 103456 – Add Daylight Report To The Weather Forecast

As a weather forecaster <br />
I want to know the daylight report for the next 7 days

So that I can report the weather better

#Scenarios
Given a request for a weather forecast
When I access the 7 seven forecast
Then I received a daylight report which will show cloudy/sunny conditions for the next 7 days

Example"Cloudy", "Sunny", "Cloudy", "Cloudy", "Sunny", "Sunny", "Sunny"

Given a request for a weather forecast
When I access the 7 seven forecastThen an overall daylight report will show as follows.
-If there are more "Cloudy" days than "Sunny" then the overall daylight report is "Mostly Cloudy"
-If there are more "Sunny" days than "Cloudy" then the overall daylight report is "Mostly Sunny"

#Implementation
Extend the SevenDayForecast model to include the daylight report.
Add a dependency to get the daylight report (do not use "new").
This will be similar to ISevenDayTemperatures.
Update all required tests.
