using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa2", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa3", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa4", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa5", "usuarioA", DateTime.Now));
        }

        [TestMethod]
        public void Deve_retornar_todas_as_tarefas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioA"));
            Assert.AreEqual(3, result.Count());
        }
    }
}