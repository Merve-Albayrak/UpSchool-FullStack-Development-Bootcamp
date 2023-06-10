import React, { useState } from 'react';
import { Button, Container, Header, Input, List, Icon } from 'semantic-ui-react';

interface Todo {
  id: number;
  task: string;
  isCompleted: boolean;
  createdDate: string;
}

function TodoLayout() {
  const [todos, setTodos] = useState<Todo[]>([]);
  const [newTodo, setNewTodo] = useState<string>('');

  const handleAddTodo = () => {
    if (newTodo) {
      const todo: Todo = {
        id: todos.length + 1,
        task: newTodo,
        isCompleted: false,
        createdDate: new Date().toLocaleString(),
      };
      setTodos([...todos, todo]);
      setNewTodo('');
    }
  };

  const handleToggleTodo = (id: number) => {
    const updatedTodos = todos.map((todo) => {
      if (todo.id === id) {
        return { ...todo, isCompleted: !todo.isCompleted };
      }
      return todo;
    });
    setTodos(updatedTodos);
  };

  const handleDeleteTodo = (id: number) => {
    const updatedTodos = todos.filter((todo) => todo.id !== id);
    setTodos(updatedTodos);
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewTodo(e.target.value);
  };

  return (
    <div>
      <Container
        text
        style={{
          marginTop: '2rem',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
        }}
      >
        <div>
          <Header as="h2">Todo App</Header>
          <Input
            type="text"
            placeholder="Enter a task"
            value={newTodo}
            onChange={handleInputChange}
            action={
              <Button primary disabled={!newTodo} content="Add" onClick={handleAddTodo} />
            }
          />
          <List divided relaxed>
            {todos.map((todo) => (
              <List.Item
                key={todo.id}
                style={{
                  display: 'flex',
                  alignItems: 'center',
                  textDecoration: todo.isCompleted ? 'line-through' : 'none',
                  border: '1px solid #ccc',
                  borderRadius: '4px',
                  padding: '8px',
                  marginBottom: '8px',
                  backgroundColor: '#f2f2f2',
                }}
                onDoubleClick={() => handleToggleTodo(todo.id)}
              >
                <List.Content style={{ flexGrow: 1 }}>{todo.task}</List.Content>
                <List.Content floated="right">
                  <Button color="red" onClick={() => handleDeleteTodo(todo.id)}>
                    <Icon name="trash" />
                  </Button>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </div>
      </Container>
    </div>
  );
}

export default TodoLayout;
