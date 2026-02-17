import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router";
import { MyRoutes } from "./routes.tsx";
import { MyGlobalStyle } from "./components/GlobalStyle.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <MyGlobalStyle></MyGlobalStyle>
    <BrowserRouter>
      <MyRoutes></MyRoutes>
    </BrowserRouter>
  </StrictMode>,
);
