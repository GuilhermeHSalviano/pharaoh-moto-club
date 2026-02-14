import App from "../src/App.tsx";
import { Routes, Route } from "react-router";

export function MyRoutes() {
  return (
    <Routes>
      <Route path="/" element={<App/>} />
    </Routes>
  );
}
