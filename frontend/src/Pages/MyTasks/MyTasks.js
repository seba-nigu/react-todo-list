import React, { useEffect, useState } from "react";
import SearchBar from "../../Components/SearchBar/SearchBar";
import TaskBox from "../../Components/TaskBox/TaskBox";
import MainButton from "../../Components/MainButton/MainButton";

import "./style.css";
import axios from "axios";

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

  function getCategoryName(categoryId) {
    axios
      .get(`https://localhost:44351/categories/${categoryId}`, categoryId)
      .then(function (response) {
        return response.data.name;
      });
  }

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
                category={getCategoryName(task.categoryId)}
                theme={props.theme}
                key={task.id}
              />
            ))}
          </>
        }
      </div>
    </div>
  );
}

export default MyTaks;
