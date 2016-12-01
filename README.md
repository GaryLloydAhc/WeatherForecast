# Weather Forecast - Dependency Injection Example
#Story 103456 – Add Daylight Report To The Weather Forecast

As a weather forecaster <br />
I want to know the daylight report for the next 7 days <br />
So that I can report the weather better <br />

#Scenarios
Given a request for a weather forecast<br />
When I access the 7 seven forecast<br />
Then I received a daylight report which will show cloudy/sunny conditions for the next 7 days<br />

Example - "Cloudy", "Sunny", "Cloudy", "Cloudy", "Sunny", "Sunny", "Sunny"<br />

Given a request for a weather forecast<br />
When I access the 7 seven forecastThen an overall daylight report will show as follows.<br />
-If there are more "Cloudy" days than "Sunny" then the overall daylight report is "Mostly Cloudy"<br />
-If there are more "Sunny" days than "Cloudy" then the overall daylight report is "Mostly Sunny"<br />

#Implementation
Extend the SevenDayForecast model to include the daylight report.<br />
Add a dependency to get the daylight report (do not use "new").<br />
This will be similar to ISevenDayTemperatures.<br />
Update all required tests.<br />
