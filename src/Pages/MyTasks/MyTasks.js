import React from "react";
import Dropdown from "../../Components/Dropdown/Dropdown";
import SearchBar from "../../Components/SearchBar/SearchBar";
import "./style.css";
function MyTaks(props) {
  return (
    <div className="MyTasks">
      MyTaks
      <SearchBar placeholder={"Search..."} width="200px" theme={props.theme} />
      <Dropdown theme={props.theme} />
    </div>
  );
}

export default MyTaks;
