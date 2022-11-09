using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _InvalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _ValidCommand = new CreateTodoCommand("Titulo da Tarefa", DateTime.Now, "Felipe Carvalho");

        [TestMethod]
        public void Given_An_Invalid_Command()
        {
            _InvalidCommand.Validate();
            Assert.AreEqual(_InvalidCommand.Valid, false);
        }
    
        [TestMethod]
        public void Given_An_Valid_Command()
        {
            _ValidCommand.Validate();
            Assert.AreEqual(_ValidCommand.Valid, true);
        }
    }
}