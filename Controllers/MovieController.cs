using System;
using Microsoft.AspNetCore.Mvc;
using Grupp1.Services;
using Grupp1.Models;

namespace WebApi.Controllers; 

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]
public class MovieController: Controller {
    
    private readonly MovieDBService _mongoDBService;

    public MovieController(MovieDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Movie>> Get() { 
        return await _mongoDBService.GetAsync(); }

    ///<summary>Creates a new MovieItem.</summary>
    ///<remarks>
    /// Sample request:
    ///
    ///     POST /Movie
    ///     {
    ///        "id": 1,
    ///        "plot": "Janne is running in the forest and then finds something...",
    ///        "genres": [
    ///             "Action",
    ///             "Drama",        
    ///         ],
    ///        "runtime": 0,
    ///        "cast": [
    ///             "Batman"
    ///         ],    
    ///     }
    ///
    /// </remarks>
    /// <response code = "201"> Returns the newly created item</response>
    /// <response code = "400"> The item is null</response>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie) {
        await _mongoDBService.CreateAsync(movie); return CreatedAtAction(nameof(Get),
        new {id = movie.Id}, movie);}

    ///<summary> Update an MovieItem.</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) { 
        await _mongoDBService.AddToMovielistAsync(id, movieId);
        return NoContent();
     }

    ///<summary>Deletes a Specifik MovieItem.</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}