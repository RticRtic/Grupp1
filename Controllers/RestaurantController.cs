using System;
using Microsoft.AspNetCore.Mvc;
using Grupp1.Services;
using Grupp1.Models;


namespace Grupp1.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]

public class RestaurantController: Controller {

    private readonly RestaurantDBService _restaurantDBService;

    public RestaurantController(RestaurantDBService restaurantDBService) {
        _restaurantDBService = restaurantDBService;
    }

    ///<summary>Get all RestaurantItems</summary>
    
    [HttpGet("GetAll")]
    public async Task<List<Restaurant>> Get() {
        return await _restaurantDBService.GetAsync();
    }

      

     ///<summary> Get RestaurantItem by ID </summary> 
    
     [HttpGet("GetById")]
     public async Task<Restaurant?> GetById(string id) {
        var restaurantItem = await _restaurantDBService.GetAsyncId(id);
         return restaurantItem;
    }    



    ///<summary> Creates a RestaurantItem.</summary>
      ///<remarks>
    /// Sample request:
    ///
    ///     POST /Restaurant
    ///    
    ///     "id": "123456789123456789456123",
    ///     "address": {
    ///       "building": "321",
    ///       "coord": [
    ///         12.12313, 12.13542
    ///       ],
    ///       "street": "Drottninggatan"
    ///      "zipcode": "11163"
    ///     },   
    ///     "borough": "T-centralen",
    ///     "cuisine": "Mexican",
    ///     "grades": [
    ///       {
    ///         "date": "2022-12-07T13:34:48.486Z",
    ///         "grade": "56",
    ///         "score": 10
    ///      }
    ///     ],
    ///     "name": "Taco Bar",
    ///     "restaurant_id": "4532"
    ///   
    ///
    /// </remarks>
    /// <response code = "201"> Returns the newly created item</response>
    /// <response code = "400"> The item is null</response>
    
    [HttpPost]
    public async Task<IActionResult>
    Post([FromBody] Restaurant restaurant) {
        await
        _restaurantDBService.CreateAsync(restaurant);
         return CreatedAtAction(nameof(Get), new {
            id = restaurant.Id 
        }, restaurant);
    }



    ///<summary> Update a RestaurantItem.</summary>

    [HttpPut("{id}")]
    public async Task<IActionResult>

    AddToRestaurant(string id, [FromBody] string restaurantId) {
        await
        _restaurantDBService.AddToRestaurantListAsync(id, restaurantId);
        return NoContent();
    }


    ///<summary>Deletes a Specific RestaurantItem.</summary>

     [HttpDelete("{id}")]
    public async Task<IActionResult>

    Delete(string id) {

        await _restaurantDBService.DeleteAsync(id);
        return NoContent();
    }



}