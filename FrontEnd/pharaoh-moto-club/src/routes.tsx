import { Routes, Route } from "react-router";
import { Dashboard } from "./pages/Dashboard.tsx";
import { useState } from "react";
import { TokenContext } from "./components/TokenContext.tsx";
import {ProtectedRoutes} from "./components/ProtectedRoutes.tsx"
import { Events } from "./pages/Events.tsx";
import Login from "./pages/Login.tsx";
import SelectedCity from "./pages/SelectedCity.tsx";
import SelectedEvent from "./pages/SelectedEvent.tsx";
import CreateEvent from "./pages/CreateEvent.tsx";


export function MyRoutes() {
  const [token, setToken] = useState<string>("");


  return (
    <TokenContext value={token}>
      <Routes>
        <Route path="/" element={<Login insertTokenToContext={setToken} />} />
        <Route element={<ProtectedRoutes />} />
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/events" element={<Events />} />
        <Route path="/CreateEvent" element={<CreateEvent />} />
        <Route path="/cityEvents/:city" element={<SelectedCity />} />
        <Route path="/event/:eventId" element={<SelectedEvent />} />
        <Route />
      </Routes>
    </TokenContext>
  );
}
