import { Search } from "@material-ui/icons";
import React from "react";
import "./style.css";

function SearchBar(props) {
  return (
    <div
      className="SearchBar"
      style={{
        width: props.width,
        color: props.theme.normalText,
        borderColor: props.theme.normalText,
        height: props.height,
      }}
    >
      <input
        className="search-input"
        placeholder={props.placeholder}
        type="text"
        style={{
          color: props.theme.normalText,
        }}
      />
      {props.icon || <Search />}
    </div>
  );
}

export default SearchBar;
