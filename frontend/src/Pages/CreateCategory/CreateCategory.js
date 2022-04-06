import axios from "axios";
import React from "react";
import MainButton from "../../Components/MainButton/MainButton";
import SearchBar from "../../Components/SearchBar/SearchBar";
import { Link } from "react-router-dom";
import "./style.css";

function CreateCategory(props) {
  function postCategory() {
    axios
      .post("https://localhost:44351/categories", {
        name: "react_category",
        description: "this is a category posted from react.",
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
        <div className="category-info">
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
        <div className="category-info">
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
