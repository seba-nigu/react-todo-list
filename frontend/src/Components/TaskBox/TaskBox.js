import "./style.css";
import React, { useEffect, useState } from "react";
import axios from "axios";
function TaskBox(props) {
  const [category, setCategory] = useState("");
  useEffect(() => {
    getCategoryName(props.test);
  }, []);

  function getCategoryName(categoryId) {
    axios
      .get(`https://localhost:44351/categories/${categoryId}`, categoryId)
      .then(function (response) {
        setCategory(response.data.name);
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  return (
    <div
      className="TaskBox"
      style={{
        color: props.theme.white,
        backgroundColor: props.theme.normalText,
      }}
    >
      <div className="taskbox-text">{props.text}</div>
      <div className="taskbox-category">{category}</div>
    </div>
  );
}

export default TaskBox;
