import React from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import SearchBar from "../../Components/SearchBar/SearchBar";
import TaskBox from "../../Components/TaskBox/TaskBox";
import "./style.css";
function MyTaks(props) {
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
        <TaskBox
          text="Lorem ipsum dolor sit amet, consectetur adipiscing elit ut aliquam"
          category="Work"
          theme={props.theme}
        />
        <TaskBox
          text="Lorem ipsum dolor sit amet, consectetur adipiscing elit ut aliquam"
          category="Homework"
          theme={props.theme}
        />
        <TaskBox
          text="Lorem ipsum dolor sit amet, consectetur adipiscing elit ut aliquam"
          category="Homework"
          theme={props.theme}
        />
        <TaskBox
          text="Lorem ipsum dolor sit amet, consectetur adipiscing elit ut aliquam"
          category="Homework"
          theme={props.theme}
        />
      </div>
    </div>
  );
}

export default MyTaks;
