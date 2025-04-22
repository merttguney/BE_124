using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        static private readonly List<TodoItem> _todoItems = new();

        // CRUD İşlemleri

        [HttpGet]
        public IEnumerable<TodoItem> GetList() // bütün listeyi döndüren action
        {
            return _todoItems;
        }

        [HttpGet("{id}")]
        public TodoItem? GetItem(int id) // tek bir TodoItem döndüren action
        {
            return _todoItems.Find(x => x.Id == id);
        }

        [HttpPost]
        public void AddItem(string description) // eleman eklemen için kullanılan action
        {
            var item = new TodoItem
            {
                Id = _todoItems.Count + 1,
                Description = description
            };

            _todoItems.Add(item);
        }

        [HttpPut("{id}")]
        public void UpdateItem(int id, string description) // bir elemanı güncellemek için kullanılan action
        {
            var index = _todoItems.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return; // early return
            }
            _todoItems[index].Description = description;

        }

        [HttpDelete("{id}")]
        public void DeleteItem(int id) // bir elemanı silmek için kullanılan action
        {
            var index = _todoItems.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return; // early return
            }
            _todoItems.RemoveAt(index);
        }


    }
}
