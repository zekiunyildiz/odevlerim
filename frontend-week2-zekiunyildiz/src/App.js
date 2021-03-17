import React, { useState } from "react";
import TodoList from "./components/TodoList";
import Form from "./components/Form";
import "./index.css";
import Title from "./components/Title";

function App() {
  const [inputText, setInputText] = useState("");
  const [todos, setTodos] = useState([]);
  return (
    <div className="App">
      <Title/>
      <Form 
      todos={todos} 
      setTodos={setTodos} 
      setInputText={setInputText} 
      inputText={inputText}
      />
      <TodoList setTodos={setTodos} todos={todos} />
    </div>
  );
}
export default App;
