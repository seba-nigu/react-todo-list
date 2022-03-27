import { Search } from "@material-ui/icons";
import React from "react";
import "./style.css";

function SearchBar(props) {
  return (
    <div
      className="SearchBar"
      style={{
        width: props.width,
      }}
    >
      <input
        className="search-input"
        placeholder={props.placeholder}
        type="text"
      />
      <Search />
    </div>
  );
}

export default SearchBar;
