import React from 'react'

const Form = ({setInputText, todos, setTodos, inputText}) => {

    //!Javascript kodumu buraya yazacağım.
    const inputTextHandler = (e) => {
        console.log(e.target.value);
        setInputText(e.target.value);
        
    };

    const submitTodoHandler = (e) => {
        e.preventDefault();
        setTodos([
            ...todos, {text: inputText, id:Math.random() * 1000}
        ]);
        setInputText("");
    };

    return(

        <form>
            <input value={inputText} onChange={inputTextHandler} type="text" className="todo-input"/>
            <button onClick={submitTodoHandler} className="todo-button" type="submit">
                <i className="fas fa-folder-plus"></i>
            </button>
            
        </form>

    );
}
export default Form;