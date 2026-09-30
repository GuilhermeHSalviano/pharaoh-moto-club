import { Routes, Route } from "react-router";
import { Dashboard } from "./pages/Dashboard.tsx";
import { useState } from "react";
import { ClaimsContext } from "./components/ClaimsContext.tsx";
import {ProtectedRoutes} from "./components/ProtectedRoutes.tsx"
import { Events } from "./pages/Events.tsx";
import Login from "./pages/Login.tsx";
import SelectedCity from "./pages/SelectedCity.tsx";
import SelectedEvent from "./pages/SelectedEvent.tsx";
import CreateEvent from "./pages/CreateEvent.tsx";
import type { Claims } from "./types/globalTypes.tsx";
import SelectEventForEdition from "./pages/SelectEventForEdition.tsx";


export function MyRoutes() {
  const [claims, setClaims] = useState<Claims>();


  return (
    <ClaimsContext value={claims?claims:undefined}>
      <Routes>
        <Route path="/" element={<Login insertClaimsToContext={setClaims} />} />
        <Route element={<ProtectedRoutes />} />
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/events" element={<Events />} />
        <Route path="/CreateEvent" element={<CreateEvent />} />
        <Route path="/cityEvents/:city" element={<SelectedCity />} />
        <Route path="/event/:eventId" element={<SelectedEvent />} />
        <Route path="/eventsByAuthor" element={<SelectEventForEdition />} />
        <Route />
      </Routes>
    </ClaimsContext>
  );
}
