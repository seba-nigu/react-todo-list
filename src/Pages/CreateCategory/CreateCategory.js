import React from "react";
import MainButton from "../../Components/MainButton/MainButton";
import SearchBar from "../../Components/SearchBar/SearchBar";
import "./style.css";

function CreateCategory(props) {
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
          <MainButton backgroundColor={"#E81D1D"} text={"Cancel"} />
          <MainButton
            backgroundColor={props.theme.mainButton}
            text={"Submit"}
          />
        </div>
      </div>
    </div>
  );
}

export default CreateCategory;
