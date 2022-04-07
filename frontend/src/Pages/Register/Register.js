import "./style.css";
import axios from "axios";
import React from "react";
import MainButton from "../../Components/MainButton/MainButton";
import TextArea from "../../Components/TextArea/TextArea";
import { Link } from "react-router-dom";

function Register(props) {
  function getFormData() {
    let name, password, password2;
    name = document.querySelector(".t-name").children[1].children[0].value;
    password =
      document.querySelector(".t-password").children[1].children[0].value;
    password2 =
      document.querySelector(".t-password2").children[1].children[0].value;

    if (password === password2) {
      alert("Registration was successful!");
      return {
        name: name,
        password: password,
      };
    } else return null;
  }
  function postRegister() {
    let obj = getFormData();
    if (obj === null) {
      alert("Passwords do not match!");
      return;
    }
    axios
      .post("https://localhost:44351/users", {
        name: obj.name,
        password: obj.password,
        userId: 2,
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
    <div className="Register">
      <div
        className="register-text"
        style={{
          color: props.theme.normalText,
        }}
      >
        Register
      </div>
      <div className="register-info-container">
        <div className="register-info t-name">
          <div
            className="register-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Name
          </div>
          <TextArea theme={props.theme} />
        </div>
        <div className="register-info t-password">
          <div
            className="register-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Password
          </div>
          <TextArea theme={props.theme} />
        </div>

        <div className="register-info t-password2">
          <div
            className="register-info-name"
            style={{
              color: props.theme.normalText,
            }}
          >
            Confirm password
          </div>
          <TextArea theme={props.theme} />
        </div>

        <div className="create-buttons">
          <Link to="/login" className="custom-link-router">
            <MainButton backgroundColor={"#E81D1D"} text={"Go to login"} />
          </Link>
          <MainButton
            backgroundColor={props.theme.mainButton}
            text={"Submit"}
            handleClick={postRegister}
          />
        </div>
      </div>
    </div>
  );
}

export default Register;
