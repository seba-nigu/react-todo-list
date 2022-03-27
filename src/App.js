import { useState } from "react";
import MyTasks from "./Pages/MyTasks/MyTasks";
import Navbar from "./Components/Navbar/Navbar";
import { darkTheme } from "./themes/theme";

function App() {
  const [theme, setTheme] = useState(darkTheme);

  return (
    <div
      className="App"
      style={{
        backgroundColor: theme.background,
      }}
    >
      <Navbar theme={theme} setTheme={setTheme} />
      <MyTasks theme={theme} />
    </div>
  );
}

export default App;
