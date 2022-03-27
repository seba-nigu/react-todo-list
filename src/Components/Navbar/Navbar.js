import React from "react";
import MainButton from "../MainButton/MainButton";
import "./style.css";

function Navbar() {
  return (
    <div className="Navbar">
      <MainButton text={"Create Task"} />
      <div className="navbar-item">Categories</div>
      <div className="navbar-item">My Tasks</div>
    </div>
  );
}

export default Navbar;
