import React from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import MainButton from "../../Components/MainButton/MainButton";
import TextArea from "../../Components/TextArea/TextArea";
import { Link } from "react-router-dom";
import axios from "axios";
import "./style.css";

function CreateTask(props) {
  function getFormData() {
    let name, description;
    name = document.querySelector(".t-name").children[1].children[0].value;
    description =
      document.querySelector(".t-description").children[1].children[0].value;
    return {
      name: name,
      description: description,
    };
  }
  // somehow must take data from input and use it here
  // also make backend and frontend more alike in regards to fields
  function postTask() {
    let obj = getFormData();
    axios
      .post("https://localhost:44351/tasks", {
        name: obj.name,
        description: obj.description,
        userId: 1,
      })
      .then(function (response) {
        console.log(response);
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
        <div className="task-info">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Category
          </div>
          <Dropdown
            theme={props.theme}
            datalist={
              <datalist id="categories" className="dropdown-input">
                <option>Work</option>
                <option>Homework</option>
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
