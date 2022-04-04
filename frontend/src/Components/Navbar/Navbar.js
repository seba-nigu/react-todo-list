import {
  AccountCircle,
  WbSunnyOutlined,
  Brightness4Outlined,
} from "@material-ui/icons";
import React from "react";

import MainButton from "../MainButton/MainButton";
import "./style.css";
import { lightTheme, darkTheme } from "../../themes/theme.js";
import { Link } from "react-router-dom";

function Navbar(props) {
  let icon = (
    <AccountCircle
      style={{
        cursor: "pointer",
        fontSize: "40px",
      }}
      onClick={changeTheme}
    />
  );
  function changeTheme() {
    if (props.theme === darkTheme) {
      props.setTheme(lightTheme);
    } else {
      props.setTheme(darkTheme);
    }
  }

  if (props.theme === lightTheme) {
    icon = (
      <WbSunnyOutlined
        style={{
          cursor: "pointer",
          fontSize: "40px",
          color: props.theme.normalText,
        }}
        onClick={changeTheme}
      />
    );
  } else {
    icon = (
      <Brightness4Outlined
        style={{
          cursor: "pointer",
          fontSize: "40px",
          color: props.theme.normalText,
        }}
        onClick={changeTheme}
      />
    );
  }

  return (
    <div className="Navbar">
      <div className="navbar-left-part">{icon}</div>
      <div className="navbar-right-part">
        <Link to="/create-task" className="custom-link-router">
          <MainButton
            text={"Create Task"}
            backgroundColor={props.theme.mainButton}
          />
        </Link>
        <Link to="/categories" className="custom-link-router">
          <div
            className="navbar-item"
            style={{
              color: props.theme.normalText,
            }}
          >
            Categories
          </div>
        </Link>
        <Link to="/" className="custom-link-router">
          <div
            className="navbar-item underlined"
            style={{
              color: props.theme.normalText,
            }}
          >
            My Tasks
          </div>
        </Link>

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
