import { BrowserRouter } from "react-router";
import { MyRoutes } from "./routes.tsx";

function App() {
  return (
    <>
      <BrowserRouter>
        <MyRoutes></MyRoutes>
      </BrowserRouter>
    </>
  );
}

export default App;
