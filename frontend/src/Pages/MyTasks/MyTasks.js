import React, { useEffect, useState } from "react";
import axios from "axios";
import SearchBar from "../../Components/SearchBar/SearchBar";
import TaskBox from "../../Components/TaskBox/TaskBox";
import MainButton from "../../Components/MainButton/MainButton";
import "./style.css";

function MyTaks(props) {
  const [tasks, setTasks] = useState([]);
  const [input, setInput] = useState("");

  function searchTask() {
    setInput(
      document.querySelector(".search-area").children[0].children[0].value
    );
    let element = document.querySelector(".task-boxes");
    let children = element.children;
    for (let i = 0; i < children.length; i++) {
      let childText = children[i].children[0].innerText;
      if (input !== "") {
        if (childText !== input) {
          children[i].style.display = "none";
        } else {
          children[i].style.display = "block";
        }
      } else {
        children[i].style.display = "block";
      }
    }
  }

  function getTask() {
    axios
      .get("https://localhost:44351/tasks")
      .then(function (response) {
        setTasks(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  useEffect(() => {
    getTask();
  }, []);
  return (
    <div className="MyTasks">
      <div
        className="mytasks-text"
        style={{
          color: props.theme.normalText,
        }}
      >
        My Tasks
      </div>
      <div className="search-area">
        <SearchBar
          placeholder={"Search..."}
          width="250px"
          theme={props.theme}
        />
        <MainButton
          backgroundColor={props.theme.mainButton}
          text={"Search"}
          handleClick={searchTask}
        />
      </div>
      <div className="task-boxes">
        {
          <>
            {tasks.map((task) => (
              <TaskBox
                text={task.name}
                theme={props.theme}
                key={task.id}
                test={task.categoryId}
              />
            ))}
          </>
        }
      </div>
    </div>
  );
}

export default MyTaks;
