import React, { useState, useEffect } from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import MainButton from "../../Components/MainButton/MainButton";
import TextArea from "../../Components/TextArea/TextArea";
import { Link } from "react-router-dom";
import axios from "axios";
import "./style.css";

function CreateTask(props) {
  const [categories, setCategories] = useState([]);

  function getCategories() {
    axios
      .get("https://localhost:44351/categories")
      .then(function (response) {
        setCategories(response.data.filter((x) => x.userId === 1));
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  useEffect(() => {
    getCategories();
  }, []);

  function getFormData() {
    let name, description, categoryId;
    name = document.querySelector(".t-name").children[1].children[0].value;
    description =
      document.querySelector(".t-description").children[1].children[0].value;
    categoryId = categories.find(
      (x) =>
        x.name ===
        document.querySelector(".t-categoryId").children[1].children[0].value
    ).id;
    return {
      name: name,
      description: description,
      categoryId: categoryId,
    };
  }

  function postTask() {
    let obj = getFormData();
    axios
      .post("https://localhost:44351/tasks", {
        name: obj.name,
        description: obj.description,
        categoryId: obj.categoryId,
        userId: 1,
      })
      .then(function (response) {
        console.log(response);
        window.location = "/";
      })
      .catch(function (error) {
        console.log(error);
      });
  }
  return (
    <div className="CreateTask">
      <div
        className="createtask-text"
        style={{
          color: props.theme.normalText,
        }}
      >
        Create Task
      </div>
      <div className="task-info-container">
        <div className="task-info t-name">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Name
          </div>
          <TextArea theme={props.theme} />
        </div>
        <div className="task-info t-description">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Description
          </div>
          <TextArea theme={props.theme} />
        </div>
        <div className="task-info t-categoryId">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Category
          </div>
          <Dropdown
            handleClick={getCategories}
            theme={props.theme}
            datalist={
              <datalist id="categories" className="dropdown-input">
                {categories.map((c) => (
                  <option value={c.name}></option>
                ))}
              </datalist>
            }
            datalistName={"categories"}
          />
        </div>
        <div className="create-buttons">
          <Link to="/" className="custom-link-router">
            <MainButton backgroundColor={"#E81D1D"} text={"Cancel"} />
          </Link>
          <MainButton
            backgroundColor={props.theme.mainButton}
            text={"Submit"}
            handleClick={postTask}
          />
        </div>
      </div>
    </div>
  );
}

export default CreateTask;
