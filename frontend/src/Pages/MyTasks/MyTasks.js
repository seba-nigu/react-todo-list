import React, { useEffect, useState } from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import SearchBar from "../../Components/SearchBar/SearchBar";
import TaskBox from "../../Components/TaskBox/TaskBox";
import "./style.css";
import axios from "axios";

function MyTaks(props) {
  const [tasks, setTasks] = useState([]);
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
        <Dropdown theme={props.theme} datalistName={"categories"} />
      </div>
      <div className="task-boxes">
        {
          <>
            {tasks.map((task) => (
              <TaskBox text={task.name} category="Work" theme={props.theme} />
            ))}
          </>
        }
      </div>
    </div>
  );
}

export default MyTaks;
