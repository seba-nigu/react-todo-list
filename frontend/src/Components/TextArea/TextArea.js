import React from "react";
import "./style.css";

function TextArea(props) {
  return (
    <div
      className="TextArea"
      style={{
        borderColor: props.theme.normalText,
      }}
    >
      <textarea
        placeholder=" Type..."
        className="textarea-input"
        style={{
          color: props.theme.normalText,
        }}
      ></textarea>
    </div>
  );
}

export default TextArea;
