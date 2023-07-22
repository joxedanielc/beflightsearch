using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

public class FlightTests : TestCase
{
    private readonly HttpClient _client;

    public EndpointsTests()
    {
        _client = new HttpClient();
    }

    [TestMethod]
    public void CanGetAllFlights()
    {
        // Arrange
        var url = "http://localhost:5000/api/flights";

        // Act
        var response = _client.GetAsync(url).Result;

        // Assert
        Assert.IsSuccessStatusCode(response);
        Assert.Equal(200, response.StatusCode);
    }

    [TestMethod]
    public void CanGetFlightById()
    {
        // Arrange
        var url = "http://localhost:5000/api/flights/1";

        // Act
        var response = _client.GetAsync(url).Result;

        // Assert
        Assert.IsSuccessStatusCode(response);
        Assert.Equal(200, response.StatusCode);
    }

    [TestMethod]
    public void CanCreateFlight()
    {
        // Arrange
        var url = "http://localhost:5000/api/flights";
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair("Origin", "New York"),
            new KeyValuePair("Destination", "Los Angeles")
        });

        // Act
        var response = _client.PostAsync(url, content).Result;

        // Assert
        Assert.IsSuccessStatusCode(response);
        Assert.Equal(201, response.StatusCode);
    }
}
