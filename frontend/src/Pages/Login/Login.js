import "./style.css";
import axios from "axios";
import React from "react";
import MainButton from "../../Components/MainButton/MainButton";
import TextArea from "../../Components/TextArea/TextArea";
import { Link } from "react-router-dom";

function Login(props) {
  function getFormData() {
    let name, password;
    name = document.querySelector(".t-name").children[1].children[0].value;
    password =
      document.querySelector(".t-password").children[1].children[0].value;
    return {
      name: name,
      password: password,
    };
  }

  // din axios.get iei userid-ul cu care faci legatura intre toate
  // api callurile de la categories si task
  // da nush cum iei id response
  function getLogin() {
    let obj = getFormData();
    axios
      .get(`https://localhost:44351/users/${obj.name}/${obj.password}`, {
        name: obj.name,
        password: obj.password,
      })
      .then(function (response) {
        console.log(response);
        window.location = "/";
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  return (
    <div className="Login">
      <div
        className="login-text"
        style={{
          color: props.theme.normalText,
        }}
      >
        Login
      </div>

      <div className="login-info-container">
        <div className="login-info t-name">
          <div
            className="login-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Name
          </div>
          <TextArea theme={props.theme} />
        </div>
        <div className="login-info t-password">
          <div
            className="login-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Password
          </div>
          <TextArea theme={props.theme} />
        </div>

        <div className="create-buttons">
          <Link to="/register" className="custom-link-router">
            <MainButton backgroundColor={"#E81D1D"} text={"Go to register"} />
          </Link>
          <MainButton
            backgroundColor={props.theme.mainButton}
            text={"Submit"}
            handleClick={getLogin}
          />
        </div>
      </div>
    </div>
  );
}

export default Login;
