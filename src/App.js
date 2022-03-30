import { useState } from "react";
import MyTasks from "./Pages/MyTasks/MyTasks";
import Navbar from "./Components/Navbar/Navbar";
import { darkTheme } from "./themes/theme";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CreateTask from "./Pages/CreateTask/CreateTask";
import CreateCategory from "./Pages/CreateCategory/CreateCategory";

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
          <Route
            path="/categories"
            element={<CreateCategory theme={theme} />}
          />
          <Route path="*" element={<MyTasks theme={theme} />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;