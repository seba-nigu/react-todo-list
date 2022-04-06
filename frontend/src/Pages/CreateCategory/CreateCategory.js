import axios from "axios";
import React from "react";
import MainButton from "../../Components/MainButton/MainButton";
import SearchBar from "../../Components/SearchBar/SearchBar";
import { Link } from "react-router-dom";
import "./style.css";

function CreateCategory(props) {
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
  // when login is done, dont hardcode id
  function postCategory() {
    let obj = getFormData();
    axios
      .post("https://localhost:44351/categories", {
        name: obj.name,
        description: obj.description,
        userId: 2,
      })
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
  }
  return (
    <div className="CreateCategory">
      <div
        className="createcategory-text"
        style={{
          color: props.theme.normalText,
        }}
      >
        Create Category
      </div>

      <div className="category-info-container">
        <div className="category-info t-name">
          <div
            className="category-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Name
          </div>
          <SearchBar theme={props.theme} />
        </div>
        <div className="category-info t-description">
          <div
            className="category-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Description
          </div>
          <SearchBar theme={props.theme} />
        </div>

        <div className="create-buttons">
          <Link to="/" className="custom-link-router">
            <MainButton backgroundColor={"#E81D1D"} text={"Cancel"} />
          </Link>
          <MainButton
            backgroundColor={props.theme.mainButton}
            text={"Submit"}
            handleClick={postCategory}
          />
        </div>
      </div>
    </div>
  );
}

export default CreateCategory;
