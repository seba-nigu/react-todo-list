import { AccountCircle, WbSunnyOutlined } from "@material-ui/icons";
import React from "react";
import MainButton from "../MainButton/MainButton";
import "./style.css";
import { lightTheme, darkTheme } from "../../themes/theme.js";

function Navbar(props) {
  function changeTheme() {
    if (props.theme === darkTheme) props.setTheme(lightTheme);
    else props.setTheme(darkTheme);
  }

  return (
    <div className="Navbar">
      <div className="navbar-left-part">
        <WbSunnyOutlined
          style={{
            cursor: "pointer",
            fontSize: "40px",
          }}
          onClick={changeTheme}
        />
      </div>
      <div className="navbar-right-part">
        <MainButton
          text={"Create Task"}
          backgroundColor={props.theme.mainButton}
        />
        <div
          className="navbar-item"
          style={{
            color: props.theme.normalText,
          }}
        >
          Categories
        </div>
        <div
          className="navbar-item"
          style={{
            color: props.theme.normalText,
          }}
        >
          My Tasks
        </div>
        <AccountCircle
          style={{
            fontSize: "40px",
            cursor: "pointer",
            color: props.theme.normalText,
          }}
        />
      </div>
    </div>
  );
}

export default Navbar;
