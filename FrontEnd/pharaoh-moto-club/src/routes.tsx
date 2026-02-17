import App from "../src/App.tsx";
import { Routes, Route } from "react-router";
import { Dashboard } from "./pages/Dashboard.tsx";

export function MyRoutes() {
  return (
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/dashboard" element={<Dashboard />} />
    </Routes>
  );
}
