import { CalendarToday } from "@material-ui/icons";
import React from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import MainButton from "../../Components/MainButton/MainButton";
import SearchBar from "../../Components/SearchBar/SearchBar";
import TextArea from "../../Components/TextArea/TextArea";
import { Link } from "react-router-dom";
import axios from "axios";
import "./style.css";

function CreateTask(props) {
  // somehow must take data from input and use it here
  // also make backend and frontend more alike in regards to fields
  function postTask() {
    axios
      .post("https://localhost:44351/tasks", {
        name: "fourth react",
        description: "fourth did something",
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
        <div className="task-info">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Author
          </div>
          <Dropdown
            theme={props.theme}
            datalist={
              <datalist id="authors" className="dropdown-input">
                <option>Seba</option>
                <option>Radu</option>
              </datalist>
            }
            datalistName={"authors"}
          />
        </div>

        <div className="task-info">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Date
          </div>
          <SearchBar theme={props.theme} icon={<CalendarToday />} />
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

        <div className="task-info">
          <div
            className="task-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Task
          </div>
          <TextArea theme={props.theme} />
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
