import React from "react";
import "./style.css";
function MainButton(props) {
  return (
    <div
      className="MainButton"
      style={{
        backgroundColor: props.backgroundColor,
      }}
      onClick={props.handleClick}
    >
      {props.text}
    </div>
  );
}

export default MainButton;
