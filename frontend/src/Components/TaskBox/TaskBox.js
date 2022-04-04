import React from "react";
import "./style.css";

function TaskBox(props) {
  return (
    <div
      className="TaskBox"
      style={{
        color: props.theme.white,
        backgroundColor: props.theme.normalText,
      }}
    >
      <div className="taskbox-text">{props.text}</div>
      <div className="taskbox-category">{props.category}</div>
    </div>
  );
}

export default TaskBox;
