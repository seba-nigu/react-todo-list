import { useState } from "react";
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
    </div>
  );
}

export default App;
