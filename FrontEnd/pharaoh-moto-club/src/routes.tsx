import App from "../src/App.tsx";
import { Routes, Route } from "react-router";
import { Dashboard } from "./pages/Dashboard.tsx";
import { useState } from "react";
import { TokenContext } from "./components/TokenContext.tsx";
import {ProtectedRoutes} from "./components/ProtectedRoutes.tsx"


export function MyRoutes() {
  const [token, setToken] = useState<string>("");


  return (
    <TokenContext value={token}>
      <Routes>
        <Route path="/" element={<App insertTokenToContext={setToken}/>} />
        <Route element={<ProtectedRoutes/>}/>
          <Route path="/dashboard" element={<Dashboard />} />
        <Route/>
      </Routes>
    </TokenContext>
  );
}
