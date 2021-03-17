import React from "react"

const Todo = ({text, todos, todo, setTodos}) => {

    const deleteHandler = () => {
        setTodos(todos.filter((el) => el.id !== todo.id));
        
    };
    return(
        <div className="todo">
            <li className="todo-item">{text}</li>
            
            <button onClick={deleteHandler} className="trash-btn">
                <i className="fas fa-trash-alt"></i>
            </button>
        </div>
    );
}
export default Todo;