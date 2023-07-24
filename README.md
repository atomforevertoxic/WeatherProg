Hello everyone!
--------------------------------------------------------------------------------------------------------------------------------------------
WeatherProg is easily done weather forecast programm which consists of 2 pages.

First page is searching page. Here you can enter a city(on any languages) that you want to get weather information.
If the name of the city was entered incorrectly or there is no such city then the input fiels turn in red and the text from this field will be deleted

Button <"Поиск"> is command "Search" and sending request to the server OpenWeather then goes to the second page.

Second page is "Answer page". It gives us the received response from the server in a convenient form:
	* Picture of the sky shows us the state of the sky and clouds
	* Name of the city below is city for which the search was carried out
	* Value of the temperature and "feels like" temperature
	* Value of the pressure in current city
	* Time of the sunrise
	* Time of the sunset

Button <"Назад"> is command that takes to the first page and thereby allows you to re-send a request with a search for weather vales in the city
