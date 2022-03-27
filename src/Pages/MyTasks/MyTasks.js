import React from "react";
import SearchBar from "../../Components/SearchBar/SearchBar";
import "./style.css";
function MyTaks(props) {
  return (
    <div className="MyTasks">
      MyTaks
      <SearchBar placeholder={"Search..."} width="200px" theme={props.theme} />
    </div>
  );
}

export default MyTaks;
