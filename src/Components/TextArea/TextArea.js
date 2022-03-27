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
        className="textarea-input"
        style={{
          color: props.theme.normalText,
        }}
      >
        Test
      </textarea>
    </div>
  );
}

export default TextArea;
