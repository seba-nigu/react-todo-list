import { useState } from "react";
import MyTasks from "./Pages/MyTasks/MyTasks";
import Navbar from "./Components/Navbar/Navbar";
import { darkTheme } from "./themes/theme";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import CreateTask from "./Pages/CreateTask/CreateTask";

function App() {
  const [theme, setTheme] = useState(darkTheme);

  return (
    <div
      className="App"
      style={{
        backgroundColor: theme.background,
      }}
    >
      <Router>
        <Navbar theme={theme} setTheme={setTheme} />
        <Routes>
          <Route path="/" element={<MyTasks theme={theme} />} />
          <Route path="/create-task" element={<CreateTask theme={theme} />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
