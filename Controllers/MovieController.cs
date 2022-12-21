using System;
using Microsoft.AspNetCore.Mvc;
using Grupp1.Services;
using Grupp1.Models;

namespace Grupp1.Controllers; 

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]
public class MovieController: Controller {
    
    // Uses the mongoDBServiceMovie to run CRUD operations.
    private readonly MovieDBService _mongoDBServiceMovie;

    public MovieController(MovieDBService mongoDBService) {
        _mongoDBServiceMovie = mongoDBService;
    }

    [HttpGet("GetAll")]
    public async Task<List<Movie>> Get() { 
        return await _mongoDBServiceMovie.GetAsync();
    }

    //! Adding tripple-slash comments to an action/task makes the Swagger UI adding the text to the section header
    // the <summary></summary> element creates an innertext.

    ///<summary>Get an Movie-item with a specifik ID.</summary>
    // Creates a task in Swagger for this case it ads a GET.
    [HttpGet("GetById")]
    public async Task<Movie?> GetById(string id) {
        var movieItem = await _mongoDBServiceMovie.GetAsyncId(id);
        return movieItem;
    }

    // Add a sample request to be shown in the POST-task i SwaggerUI.
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
    ///             "Batman",
    ///             "Tom Hanks"
    ///         ],    
    ///     }
    ///
    /// </remarks>
    /// <response code = "201"> Returns the newly created item </response>
    /// <response code = "400"> The item is null </response>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie) {
        await _mongoDBServiceMovie.AddToMovieListAsync(movie); return CreatedAtAction(nameof(Get),
        new {id = movie.Id}, movie);}

    ///<summary> Update status and nr of available copies of is_for_rent.</summary>
    [HttpPut("Updates is_for_rent")]
    public async Task<IActionResult> IsAvailable(string id, int nrOfCopies, [FromBody]Movie updatedStatus) {
        await _mongoDBServiceMovie.isForRent(nrOfCopies, updatedStatus);
        // if nrOfCopies is 0 the bool available sets to false, else true
        if (nrOfCopies == 0) {
            updatedStatus.IsForRent!.Available = false;
        } else {
             updatedStatus.IsForRent!.Available = !updatedStatus.IsForRent.Available;
        }

        //Sets the NrOfCopiesAvailable of the value nrOfCopies is given
        updatedStatus.IsForRent!.NrOfCopiesAvailable = nrOfCopies;

        // Updates the movie-item after the task is done with the given id and the new values that coming in.
        await _mongoDBServiceMovie.UpdateAsync(id, updatedStatus);
        
        return NoContent();
    }

    ///<summary> Update an MovieItem.</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update (string id, [FromBody]Movie updatedMovie) { 
       var movie = await _mongoDBServiceMovie.GetAsyncId(id);
       if (movie is null) {
        // If movie is null return NotFound response code 204.
            return NotFound();
       }
       updatedMovie.Id = movie.Id;

       await _mongoDBServiceMovie.UpdateAsync(id, updatedMovie);

       return NoContent();
     }

    ///<summary>Deletes a Specifik MovieItem.</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        
        // After the task is done calls the MovieDBService, in this case here, I store it in a variable _mongoDBServiceMovie.
        // MovieDBService class have a method DeleteMovie witch delete an movie-item with a given id.
        await _mongoDBServiceMovie.DeleteMovie(id);
        return NoContent();
    }

    
}