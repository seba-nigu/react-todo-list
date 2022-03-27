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
        type="text"
        name="categories"
        list="categories"
        autocomplete="on"
        className="dropdown-input"
        style={{
          color: props.theme.normalText,
        }}
      />
      <datalist id="categories" className="dropdown-input">
        <option>Work</option>
        <option>Homework</option>
      </datalist>
    </div>
  );
}

export default Dropdown;
