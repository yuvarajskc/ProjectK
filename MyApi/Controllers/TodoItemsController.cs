using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoItemsController> _logger; // Add logger field

        public TodoItemsController(TodoContext context, ILogger<TodoItemsController> logger) // Inject logger
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            _logger.LogInformation("Fetching all TodoItems");
            try
            {
                var items = await _context.TodoItems.ToListAsync();
                _logger.LogInformation("Successfully fetched {Count} TodoItems", items.Count);
                return items;
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching TodoItems");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            _logger.LogInformation("Fetching TodoItem with ID {Id}", id);
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                _logger.LogWarning("TodoItem with ID {Id} not found", id);
                return NotFound();
            }

            _logger.LogInformation("Successfully fetched TodoItem with ID {Id}", id);
            return todoItem;
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            _logger.LogInformation("Updating TodoItem with ID {Id}", id);
            if (id != todoItem.Id)
            {
                _logger.LogWarning("ID mismatch: {Id} does not match TodoItem ID {TodoItemId}", id, todoItem.Id);
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully updated TodoItem with ID {Id}", id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TodoItemExists(id))
                {
                    _logger.LogWarning("TodoItem with ID {Id} not found during update", id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "Concurrency error while updating TodoItem with ID {Id}", id);
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _logger.LogInformation("Creating a new TodoItem");
            try
            {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully created TodoItem with ID {Id}", todoItem.Id);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            }
            catch (System.Exception e)
            {
            _logger.LogError(e, "An error occurred while creating a new TodoItem");
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            _logger.LogInformation("Deleting TodoItem with ID {Id}", id);
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                _logger.LogWarning("TodoItem with ID {Id} not found for deletion", id);
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted TodoItem with ID {Id}", id);
            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
