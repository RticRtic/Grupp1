using System;
using Microsoft.AspNetCore.Mvc;
using Grupp1.Services;
using Grupp1.Models;

namespace Grupp1.Controllers; 

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]
public class TransactionController: Controller {
    
    private readonly TransactionMongoDBService _transactionMongoDBService;

    public TransactionController(TransactionMongoDBService transactionMongoDBService) {
        _transactionMongoDBService = transactionMongoDBService;
    }

    ///<summary>Get all transactions</summary>

    [HttpGet("GetAll")]
    public async Task<List<Transaction>> Get() {
    return await _transactionMongoDBService.GetAsync();
}

///<summary>Get a specific transaction</summary>

[HttpGet("GetById")]
     public async Task<Transaction?> GetById(string id) {
        var singleTransaction = await _transactionMongoDBService.GetAsyncId(id);
         return singleTransaction;
    }    



///<summary> Post a new transaction </summary> 
  ///<remarks>
    /// Sample request:
    ///
    ///     POST /Restaurant
    ///    
    ///     "id": remove this row, it updates automatically.
    ///     "storeLocation": "Stockholm",
    ///     "itemsBought": [
    ///     "Banana", "Apple", "Onion", "Garlic"
    ///     ],
    ///     "usedCoupon": true/false, was a coupon used?
    ///     "customer": {
    ///     "gender": "male",
    ///     "age": 35,
    ///     "email": "example@example.com",
    ///     "satisfactionRateOneToFive": 5
    ///     },
    ///     "purchaseMethod": "Online"/"Store", 
    ///     "date": "2022-12-16T15:42:44.115Z"
    ///</remarks>
    

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Transaction transaction) {
    await _transactionMongoDBService.CreateAsync(transaction);
    return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
}

///<summary> Update itemsBought with new item by ID </summary> 

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTransaction(string id, [FromBody] string movieId) {
    await _transactionMongoDBService.AddToTransactionAsync(id, movieId);
    return NoContent();
}

///<summary> Delete a transaction by ID </summary> 

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
    await _transactionMongoDBService.DeleteAsync(id);
    return NoContent();
}

}