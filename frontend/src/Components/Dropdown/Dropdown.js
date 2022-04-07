import React from "react";
import "./style.css";

function Dropdown(props) {
  return (
    <div
      className="Dropdown"
      style={{
        width: props.width || "130px",
        borderColor: props.theme.normalText,
      }}
    >
      <input
        onClick={props.handleClick}
        type="text"
        name="categories"
        list={props.datalistName}
        autoComplete="on"
        className="dropdown-input"
        style={{
          color: props.theme.normalText,
        }}
      />
      {props.datalist}
    </div>
  );
}

export default Dropdown;
