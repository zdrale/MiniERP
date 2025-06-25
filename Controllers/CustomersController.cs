using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class CustomersController : ControllerBase {
    private readonly ICustomerRepository _repo;
    public CustomersController(ICustomerRepository repo) {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var customer = await _repo.GetByIdAsync(id);
        return customer == null ? NotFound() : Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer) {
        await _repo.AddAsync(customer);
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Customer customer) {
        if (id != customer.Id) return BadRequest();
        await _repo.UpdateAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
