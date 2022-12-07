using System;
using Microsoft.AspNetCore.Mvc;
using Grupp1.Services;
using Grupp1.Models;


namespace Grupp1.Controllers;

[Controller]
[Route("api/[controller]")]

public class RestaurantController: Controller {

    private readonly RestaurantDBService _restaurantDBService;

    public RestaurantController(RestaurantDBService restaurantDBService) {
        _restaurantDBService = restaurantDBService;
    }

    [HttpGet]
    public async Task<List<Restaurant>> Get() {

        return await _restaurantDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult>
    Post([FromBody] Restaurant restaurant) {
        await
        _restaurantDBService.CreateAsync(restaurant);
        return CreatedAtAction(nameof(Get), new {
            id = restaurant.Id 
        }, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>
    AddToRestaurant(string id, [FromBody] string restaurantId) {
        await

        _restaurantDBService.AddToRestaurantListAsync(id, restaurantId);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>
    Delete(string id) {

        await _restaurantDBService.DeleteAsync(id);
        return NoContent();
    }
}