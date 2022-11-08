using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;

using Flunt.Notifications;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Por favor, verifique os dados da sua nova tarefa.", command.Notifications);
            var todo = new TodoItem(command.Title, command.Date, command.User);
            _repository.Create(todo);
            return new GenericCommandResult(true, "Tarefa criada.", todo);
        }
    }
}