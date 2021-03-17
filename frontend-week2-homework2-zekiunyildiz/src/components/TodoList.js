import React from "react";

import Todo from "./Todo"

function TodoList({todos, setTodos}) {
  
  return (
    <div>
      <div className="todo-container">
        <ul className="todo-list">
          {todos.map((todo) => (
            <Todo todos={todos} setTodos={setTodos} key={todo.id} todo={todo}  text={todo.text}  />
          ))}
          
        </ul>
      </div>
    </div>
  );
}

export default TodoList;

